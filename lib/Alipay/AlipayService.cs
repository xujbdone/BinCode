using Core.lib;
namespace Alipay
{
    public class AlipayService : IPaySerivce
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