using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _01_FluentScheduler
{
    internal class RunJob : IJob
    {
        void IJob.Execute()
        {
            Console.WriteLine($"\n\r线程id={Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
