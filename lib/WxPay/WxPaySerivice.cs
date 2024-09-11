using Core.lib;

namespace WxPay
{
    public class WxPaySerivice : IPaySerivce
    {
        public void Paying()
        {
            Console.WriteLine("微信支付=====");
        }

        public void Refund()
        {
            Console.WriteLine("微信退款=====");
        }
    }
}