using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_TestHelper.WX.Model
{
    public class TenPayV3POpenCarModel
    {
        /// <summary>
        /// 变更前的用户的积分值
        /// </summary>
        public int before_bonus_value { get; set; }

        /// <summary>
        /// 更后的用户最新积分值，该值会展示在会员卡详页上
        /// </summary>
        public int bonus_value { get; set; }

        /// <summary>
        /// 本次变更的积分值，等于bonus_value-before_bonus_value，正数表示增加，负数表示减小
        /// </summary>
        public int add_bonus_value { get; set; }

        /// <summary>
        /// 商户凭据号。商户自定义，注意保持唯一性，仅供参考的格式：商户id+日期+流水号。可包含英文字母，数字，｜，_，*，-等内容，不允许出现其他不合法符号。
        /// </summary>
        public string out_request_no { get; set; }
    }
}
