using _07_DependencyInject.IService;
using _07_DependencyInject.Service;

namespace _07_DependencyInject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services= new MyServiceCollection();
            services.AddSingleton<IPay, Pay>();

            IServiceProvider provider = services.BuildProvider();

            var pay = (IPay)provider.GetService(typeof(IPay));

            pay.CreateOrder();
            pay.Paying();
            pay.Refund();
        }
    }
}
