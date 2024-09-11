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

        public T GetService<T>() where T : class 
        {
            var serviceType = typeof(T);
            var matchItem = _services.FirstOrDefault(s => s.ServiceType == serviceType);
            if (matchItem == null)
            {
                return default(T);
            }
            switch (matchItem.Lifetime)
            {
                case ServiceLifetime.Singleton:
                case ServiceLifetime.Scoped:
                    if (_objects.ContainsKey(matchItem.ServiceType))
                    {
                        return (T)_objects[matchItem.ServiceType];
                    }
                    var obj = Activator.CreateInstance(matchItem?.ImplementationType);
                    _objects.TryAdd(matchItem.ServiceType, obj);
                    return (T)obj;
                case ServiceLifetime.Transient:
                    return (T)Activator.CreateInstance(matchItem.ImplementationType);
                default:
                    return null;
            }
        }
    }
}
