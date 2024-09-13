using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Logging._02_简单模仿
{
    public class Logger : ILogger
    {
        private readonly LoggerFactory _loggerFactory;
        private readonly string _name;
        private readonly ILogger _loggers;

        public Logger(LoggerFactory factory, string name)
        {
            
        }
    }
}
