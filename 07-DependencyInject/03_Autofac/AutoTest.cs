using _07_DependencyInject._03_Autofac.IService;
using _07_DependencyInject._03_Autofac.Serivce;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject._03_AutoFac
{
    public class AutoTest
    {
        public static void Runing()
        {
            //1、通过类来注入
            //var builder = new ContainerBuilder();
            //builder.RegisterType<DbContext>().As<IDbContext>();
            //var container = builder.Build();
            //var serviceProvider = new AutofacServiceProvider(container);
            //var iDbcontext = serviceProvider.GetService<IDbContext>();
            //iDbcontext.Desc();
            //Console.ReadKey();

            //2、通过程序集批量注入
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Module", "*.dll");
            var assemblys = Assembly.LoadFile(path);

            var builder = new ContainerBuilder();
            builder.RegisterType<WxPay.Pay>().As<Payment.IPay>();
            var container = builder.Build();
            var serviceProvider = new AutofacServiceProvider(container);
            var pay = serviceProvider.GetService<Payment.IPay>();
            pay.Paying();
            //Console.ReadKey();
        }
    } 
}
