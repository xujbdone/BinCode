using _00_TestHelper.WX.Model;
using Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _00_TestHelper.WX
{
    public class WXPayHelper
    {
        private const string TenPayV3OpenCardUrl = "https://api.mch.weixin.qq.com/v3/marketing/membercard-open/cards/{card_id}/codes/{code}/rights";

        /// <summary>
        /// 商圈同步积分接口
        /// </summary>
        /// <param name="mchid">商圈商户号</param>
        /// <param name="mchserialno">api证书序列号</param>
        /// <param name="apicertprivatekey">api支付私钥</param>
        /// <param name="model"></param>
        /// https://pay.weixin.qq.com/wiki/doc/apiv3_partner/Offline/apis/chapter5_9_23.shtml
        /// <returns></returns>
        public static TenPayV3BasicResult WxPointNotify(string mchid, string mchserialno, string apicertprivatekey, TenPayV3POpenCarModel model, string cardid, string code)
        {
            try
            {
                var url = TenPayV3OpenCardUrl.Replace("{card_id}", cardid).Replace("{code}", code);
                var postData = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "PATCH";
                request.ContentType = "application/json";
                request.Timeout = 10000;
                request.Accept = "application/json";
                request.UserAgent = "Fengze/1.2.0";
                var headers = GetHeader(mchid, mchserialno, apicertprivatekey, url, "PATCH", postData);
                byte[] postdatabyte = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = postdatabyte.Length;
                foreach (var item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(postdatabyte, 0, postdatabyte.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new TenPayV3BasicResult()
                    {
                        success = true,
                        message = "同步卡包积分成功",
                    };
                }
                else
                {
                    StreamReader streamReader = new StreamReader(response.GetResponseStream());
                    string responseContent = streamReader.ReadToEnd();
                    Logger.Info(string.Format("商圈积分同步结果：{0}", responseContent));
                    return new TenPayV3BasicResult
                    {
                        success = false,
                        message = "商圈积分同步失败"
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.Error("积分同步卡包失败:" + ex);
                return new TenPayV3BasicResult()
                {
                    success = false,
                    message = "积分同步卡包异常"
                };
            }
        }

        /// <summary>
        /// 获取通用请求头
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="merchantSerialNo"></param>
        /// <param name="privatekey"></param>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetHeader(string merchantId, string merchantSerialNo, string privatekey, string url, string method, string body = "")
        {
            var uriInfo = new Uri(url);
            string uri = uriInfo.PathAndQuery;
            var timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
            string nonce = Path.GetRandomFileName();

            string message = $"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n";
            string signature = Sign.SHA256WithRSA.Sign(message, privatekey);
            string authorization = $"WECHATPAY2-SHA256-RSA2048 mchid=\"{merchantId}\",nonce_str=\"{nonce}\",timestamp=\"{timestamp}\",serial_no=\"{merchantSerialNo}\",signature=\"{signature}\"";

            var dic = new Dictionary<string, string>
            {
                { "Authorization", authorization },
            };
            return dic;
        }
    }
}
