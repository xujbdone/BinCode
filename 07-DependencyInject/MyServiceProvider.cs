using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject
{
    public class MyServiceProvider : IServiceProvider
    {
        private IServiceCollection _services;

        private ConcurrentDictionary<Type, object> _objects = new ConcurrentDictionary<Type, object>();

        public MyServiceProvider(IServiceCollection services)
        {
            _services = services;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            var matchItem = _services.FirstOrDefault(s => s.ServiceType == serviceType);
            if (matchItem == null)
            {
                return null;
            }
            switch (matchItem.Lifetime)
            {
                case ServiceLifetime.Singleton:
                case ServiceLifetime.Scoped:
                    if (_objects.ContainsKey(matchItem.ServiceType))
                    {
                        return _objects[matchItem.ServiceType];
                    }
                    var obj = Activator.CreateInstance(matchItem?.ImplementationType);
                    _objects.TryAdd(matchItem.ServiceType, obj);
                    return obj;
                case ServiceLifetime.Transient:
                    return Activator.CreateInstance(matchItem.ImplementationType);
                default:
                    return null;
            }
        }
    }
}
