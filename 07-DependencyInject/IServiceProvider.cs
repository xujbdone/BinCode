using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject
{
    public interface IServiceProvider : IDisposable
    {
        object GetService(Type serviceType);
    }
}
