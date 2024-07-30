using System.Reflection.Metadata.Ecma335;

namespace _01_Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number_ls = new List<int>() { 999, 110, 11, 100, 22, 333, 32, 4, 99 };
            var S = sort(number_ls.ToList(), (f1, f2) => f1 > f2 );
            foreach (var item in S)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Hello, World!");
        }

        public static List<T> sort<T>(List<T> data, Func<T, T, bool> func)
        {
            var is_sort = true;
            var count = 0;
            while (is_sort)
            {
                is_sort = false;
                for (var i = 0; i < data.Count -1; i++)
                {
                    if (func(data[i], data[i + 1]))
                    {
                        count++;
                        is_sort = true;
                        var temp_data = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp_data;
                    }
                }
            }
            Console.WriteLine($"计算了{count}次");
            return data;
        }
    }
}
