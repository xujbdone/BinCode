using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03_Delegate
{
    public class EventTest
    {
        public static void Run()
        {
            var ev = new EventClass();

            var p1 = new LazyPerson("张三");
            var p2 = new LazyPerson("李四");
            var p3 = new LazyPerson("王五");

            //事件是一种特殊委托，事件只能由定义它的类触发，可以由其他类订阅、货取消订阅事件。
            //订阅事件，只能添加(+=)、删除(-=),不能赋值(=),并且只能由声明它的类来发布
            //error -> ev.myEvent = p1.SubscribeEv;
            //error -> ev.myEvent.();
            ev.myEvent += p1.SubscribeEv;
            ev.myEvent += p2.SubscribeEv;
            ev.myEvent += p3.SubscribeEv;

            //发布事件
            ev.IssueEvent();
        }
    }

    internal class EventClass
    {

        //声明委托
        public delegate void MyDelegate();

        //声明事件
        public event MyDelegate myEvent;

        public void IssueEvent()
        {
            Console.WriteLine("收集事件，你们可以开始订阅了");
            myEvent?.Invoke();
        }
    }


    public class LazyPerson
    {
        public string name { get; set; }

        public LazyPerson(string name)
        {
            this.name = name;
        }

        public void SubscribeEv()
        {
            Console.WriteLine($"{this.name}订阅了");
        }
    }
}
