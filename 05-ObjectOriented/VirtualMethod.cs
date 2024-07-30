using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ObjectOriented
{
    public class VirtualMethod
    {
        public static void SayHi()
        {
            var p = new Person();
            p.SayHi();
        }
    }

    //加上virtual关键字声明，即为虚方法，
    //允许子类重写父类方法，使用关键字override
    //子类执行父类方法，使用base.method()

    public class Animal
    {
        public virtual void SayHi()
        {
            Console.WriteLine("Animal Sayhi");
        }
    }


    public class Person: Animal
    {
        public override void SayHi()
        {
            base.SayHi();//先调用方法
            Console.WriteLine("Person Sayhi");
        }
    }
}
