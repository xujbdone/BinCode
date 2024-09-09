using _07_DependencyInject.IService;
using _07_DependencyInject.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _07_DependencyInject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddScoped<IPay, Pay>();
            }).Build();
            host.Run();
        }


        public void RunTest(IPay pay)
        {
            pay.Pay();
        }
    }
}
