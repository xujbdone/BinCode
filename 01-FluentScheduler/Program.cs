using FluentScheduler;

namespace _01_FluentScheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JobManager.Initialize(new SchedulerFactory());
            Console.ReadKey();
        }
    }
}