using _07_DependencyInject._03_Autofac.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject._03_Autofac.Serivce
{
    internal class DbContext : IDbContext
    {
        public void Desc()
        {
            Console.WriteLine("我是DbContext的Desc");
        }
    }
}
