using MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.LoggingBuilder
{
    public class LoggingBuilder : ILoggingBuilder
    {
        public IServiceCollection Service { get; }

        public LoggingBuilder(IServiceCollection service)
        {
            Service = service;
        }
    }
}
