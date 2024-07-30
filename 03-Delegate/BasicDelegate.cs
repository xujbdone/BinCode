using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03_Delegate
{
    public static class BasicDelegate
    {
        public delegate void AnimalSayHi(string name);

        public static void RunTest()
        {
            //直接传方法，作为参数
            SayHi("小狗", DogCall);
            SayHi("小猫", CatCall);

            var list = new List<string>() { "a", "abc", "bb", "eee", "fds", "ba" };

            //Lambda表达式
            var msxStr = GetMaxString("0100", "101", (p1, p2) => Convert.ToInt32(p1) > Convert.ToInt32(p2));

            //Action、Func委托的简化写法，Func最后一个参数作为返回值
            list = list.FilterString(f => f.Contains("b"));

            Console.ReadKey();
        }

        public static void SayHi(string name, AnimalSayHi sayHi)
        {
            //调用委托方法
            sayHi.Invoke(name);
            //提供了另一种简化写法
            sayHi(name);
        }

        /// <summary>
        /// 委托：C#实现回调函数的一种机制
        /// 定义了委托的格式，包括参数、返回值
        /// 委托可定义在类外面、内部
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        public delegate bool Comapare(string number1, string number2);


        public static string GetMaxString(string str1, string str2, Comapare comapare)
        {
            var isMax = comapare(str1, str2);
            return isMax ? str1 : str2;
        }

        /// <summary>
        /// Func有返回值，最后一个参数作为返回值
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<string> FilterString(this List<string> strings, Func<string, bool> func)
        {
            var list = new List<string>();
            foreach (string s in strings)
            {
                if(func(s))
                {
                    list.Add(s);
                }
            }
            return list;
        }



        public static void DogCall(string name)
        {
            Console.WriteLine($"狗：你好啊-{name}");
        }

        public static void CatCall(string name)
        {
            Console.WriteLine($"猫：你好啊-{name}");
        }
    }
}
