using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject
{
    /// <summary>
    /// 定义容器集合
    /// </summary>
    public interface IServiceCollection : IList<ServiceDescriptor>
    {
    }
}
