using Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alipay
{
    public class Pay : IPay
    {
        public void Paying()
        {
            Console.WriteLine("支付宝付款。。。");
        }

        public void Refund()
        {
            Console.WriteLine("支付宝退款===");
        }
    }
}
