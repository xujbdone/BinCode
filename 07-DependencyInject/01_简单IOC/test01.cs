using _07_DependencyInject.IService;
using _07_DependencyInject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject
{
    public class test01
    {
        public static void Run()
        {
            IServiceCollection services = new MyServiceCollection();
            services.AddSingleton<IPay, Pay>();

            IServiceProvider provider = services.BuildProvider();

            var pay = provider.GetService<IPay>();

            pay.CreateOrder();
            pay.Paying();
            pay.Refund();
        }
    }
}
