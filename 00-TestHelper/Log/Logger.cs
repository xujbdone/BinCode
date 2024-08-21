using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public class Logger
    {
        public static void Info(string message)
        {
            Console.WriteLine(message + "\r\n");
        }


        public static void Error(string message)
        {
            Console.WriteLine(message + "\r\n");
        }

        public static void Error(string message, Exception ex)
        {
            Console.WriteLine(message);
            Console.WriteLine(ex.ToString() + "\r\n");
        }
    }
}
