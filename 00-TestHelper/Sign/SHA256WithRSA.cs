using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sign
{
    public class SHA256WithRSA
    {
        /// <summary>
        /// 生成签名,适用.net
        /// </summary>
        /// <param name="message">参与加密的字符串</param>
        /// <param name="privateKey">商户私钥（私钥不包括私钥文件起始的-----BEGIN PRIVATE KEY-----，亦不包括结尾的-----END PRIVATE KEY-----）</param>
        /// <returns></returns>
        public static string Sign(string message, string privateKey)
        {
            using (RSACryptoServiceProvider sha256 = new RSACryptoServiceProvider())
            {
                privateKey = privateKey.Replace("-----BEGIN PRIVATE KEY-----", "").Replace("-----END PRIVATE KEY-----", "").Trim();
                privateKey = Regex.Replace(privateKey, @"[\r\n]", "");
                privateKey = SignUtil.RSAPrivateKeyJava2DotNet(privateKey);
                byte[] dataInBytes = Encoding.UTF8.GetBytes(message);
                sha256.FromXmlString(privateKey);
                byte[] inArray = sha256.SignData(dataInBytes, CryptoConfig.MapNameToOID("SHA256"));
                string sign = Convert.ToBase64String(inArray);
                return sign;
            }
        }
    }
}
