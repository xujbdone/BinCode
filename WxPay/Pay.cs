using Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxPay
{
    public class Pay : IPay
    {
        public void Paying()
        {
            Console.WriteLine("微信付款。。。");
        }

        public void Refund()
        {
            Console.WriteLine("微信退款。。。");
        }
    }
}
