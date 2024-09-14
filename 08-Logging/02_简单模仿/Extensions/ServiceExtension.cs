using Microsoft.Extensions.DependencyInjection;
using MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Extensions
{
    public static class ServiceExtension
    {
        public static MyService.IServiceCollection AddSingleton<TService, TImpService>(this MyService.IServiceCollection services)
        {
            services.Add(
            new ServiceDescriptor(typeof(TService), typeof(TImpService), ServiceLifetime.Singleton));
            return services;
        }

        public static MyService.IServiceCollection AddSingleton<TService>(this MyService.IServiceCollection services, TService implementationInstance) where TService : class
        {
            services.Add(new ServiceDescriptor(typeof(TService), implementationInstance.GetType(), ServiceLifetime.Singleton));
            return services;
        }
    }
}
