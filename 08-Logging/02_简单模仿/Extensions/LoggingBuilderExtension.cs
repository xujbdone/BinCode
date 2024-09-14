using Logging.LoggingBuilder;
using Logging.LoggingProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Extensions
{
    /// <summary>
    /// 扩展类
    /// </summary>
    public static class LoggingBuilderExtension
    {
        /// <summary>
        /// 添加日志构造器
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddProvider(this ILoggingBuilder builder, ILoggerProvider provider) 
        {
            builder.Service.AddSingleton(provider);
            return builder;
        }
    }
}
