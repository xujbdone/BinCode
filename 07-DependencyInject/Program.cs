using _07_DependencyInject._02_NetCore;
using _07_DependencyInject._03_AutoFac;

namespace _07_DependencyInject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1、实现简单IOC容器
            //test01.Run();

            //2、.NetCore自带注入
            RunTest02.Run();

            //3、Autofac
            //AutoTest.Runing();
        }
    }
}
