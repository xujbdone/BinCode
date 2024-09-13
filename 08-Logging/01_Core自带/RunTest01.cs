using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Logging._01_Core
{
    internal class RunTest01
    {
        public static void Runing()
        {
            var builder = Host.CreateApplicationBuilder();

            //添加日志组件
            builder.Services.AddLogging(loggingBuilder =>
            {
                //去除默认添加的日志提供程序
                loggingBuilder.ClearProviders();
                //设置日志记录的level
                loggingBuilder.SetMinimumLevel(LogLevel.Debug);
                //AddProvider 添加日志提供器
                //添加控制台输出
                loggingBuilder.AddConsole();
                //调试输出
                loggingBuilder.AddDebug();
            });
        }
    }
}
