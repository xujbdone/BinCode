using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject.IService
{
    public interface IPay
    {
        public void CreateOrder();

        public void Pay();

        public void Refund();
    }
}
