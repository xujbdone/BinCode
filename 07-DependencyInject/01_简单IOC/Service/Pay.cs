using _07_DependencyInject.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject.Service
{
    public class Pay : IPay
    {
        public void CreateOrder()
        {
            Console.WriteLine("Pay-创建订单");
        }

        public void Refund()
        {
            Console.WriteLine("Pay-申请退款");
        }

        public void Paying()
        {
            Console.WriteLine("Pay-支付金额");
        }
    }
}
