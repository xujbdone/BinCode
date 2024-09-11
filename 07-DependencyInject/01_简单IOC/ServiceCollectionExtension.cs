using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSingleton<TService, TImplService>(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplService), ServiceLifetime.Singleton));
            return services;
        }

        public static IServiceCollection AddScope<TService, TImplService>(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplService), ServiceLifetime.Scoped));
            return services;
        }

        public static IServiceCollection AddTransient<TService, TImplService>(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(TService), typeof(TImplService), ServiceLifetime.Transient));
            return services;
        }
    }
}
