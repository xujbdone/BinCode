using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ObjectOriented
{
    public class Abstract
    {
        //抽象类与接口具有相似处
        //1、不能被实例化
        //2、包含未被实现的方法
        //3、派生类必须实现父类未实现的方法体
        public static void Run()
        {
            var st = new Studentt();
            st.SayHello();
            st.SayHi();
            var co = new Programer();
            co.SayHello();
            co.SayHi();
        }
    }


    public abstract class People
    {
        public abstract void SayHello();

        public void SayHi()
        {
            Console.WriteLine("abstract sayhi");
        }
    }

    public class Studentt : People
    {
        public override void SayHello()
        {
            Console.WriteLine("你好呀，我是学生");
        }
    }

    public class Programer : People
    {
        public override void SayHello()
        {
            Console.WriteLine("你好呀，我是coder");
        }

        new public void SayHi()
        {
            base.SayHi();
            Console.WriteLine("SayHi sayhi");
        }
    }
}
