using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject
{
    public class MyServiceCollection : IServiceCollection
    {
        private readonly List<ServiceDescriptor> _descripors = new List<ServiceDescriptor>();

        public ServiceDescriptor this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => _descripors.Count;

        public bool IsReadOnly => false;


        public void Add(ServiceDescriptor item)
        {
            _descripors.Add(item);
        }

        public void Clear()
        {
            _descripors.Clear();
        }

        public bool Contains(ServiceDescriptor item)
        {
            return _descripors.Contains(item);
        }

        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            return _descripors.GetEnumerator();
        }

        public int IndexOf(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
