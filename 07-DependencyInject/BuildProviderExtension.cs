using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject
{
    public static class BuildProviderExtension
    {
        public static IServiceProvider BuildProvider(this IServiceCollection services)
        {
            return new MyServiceProvider(services);
        }
    }
}
