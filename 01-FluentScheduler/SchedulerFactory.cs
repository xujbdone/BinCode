using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FluentScheduler
{
    internal class SchedulerFactory: Registry
    {
        public SchedulerFactory() 
        {
            //每5秒执行一次，同步任务
            Schedule<RunJob>().NonReentrant().ToRunNow().AndEvery(3).Seconds();

            //每月第一个星期23:00执行异步任务
            //Schedule<RunJob>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(18, 0);
        }
    }
}
