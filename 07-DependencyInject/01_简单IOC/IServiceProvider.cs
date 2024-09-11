using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject
{
    /// <summary>
    /// 提供容器对象的访问
    /// </summary>
    public interface IServiceProvider : IDisposable
    {
        T GetService<T>() where T : class;
    }
}
