using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.lib;
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
            //builder.RegisterType<IPaySerivce>().As<IDbContext>();
            //var container = builder.Build();
            //var serviceProvider = new AutofacServiceProvider(container);
            //var iDbcontext = serviceProvider.GetService<IDbContext>();
            //iDbcontext.Desc();
            //Console.ReadKey();

            //2、通过程序集批量注入
            var builder = new ContainerBuilder();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Module");
            var dirList = Directory.GetFiles(path, "*.dll");
            foreach (var dir in dirList)
            {
                var assembly = Assembly.LoadFrom(dir);
                builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().InstancePerDependency();
            }
            var container = builder.Build();
            var serviceProvider = new AutofacServiceProvider(container);
            var pay = serviceProvider.GetService<IPaySerivce>();
            pay.Paying();
            Console.ReadKey();
        }
    } 
}
