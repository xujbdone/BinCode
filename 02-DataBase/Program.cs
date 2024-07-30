using _02_DataBase.Core;
using System.Xml.Linq;

namespace _02_DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sql = $"select * from student";
            var count = DbHelper.QueryAsync<object>(sql).Result;
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}