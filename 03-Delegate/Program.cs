
namespace _03_Delegate
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var ls = new int[] { 13, 52, 53, 94, 3, 5, 77 };
            var ls1 = Sort(ls.ToList(), (f1, f2) => f1 < f2);
            //委托
            //BasicDelegate.RunTest();

            //事件
            EventTest.Run();
        }

        /// <summary>
        /// 泛型冒泡排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<T> Sort<T>(List<T> data, Func<T, T, bool> func)
        {
            var is_sort = true;
            while (is_sort)
            {
                is_sort = false;
                for (var i = 0; i < data.Count - 1; i++)
                {
                    if (func(data[i], data[i + 1]))
                    {
                        is_sort = true;
                        var tem_data = data[i];
                        data[i] = data[i + 1];
                        data[i  + 1] = tem_data;
                    }
                }
            }
            return data;
        }
        
    }
}