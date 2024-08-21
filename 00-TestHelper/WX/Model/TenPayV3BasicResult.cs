using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_TestHelper.WX.Model
{
    public class TenPayV3BasicResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 失败信息
        /// </summary>
        public string message { get; set; }
    }
}
