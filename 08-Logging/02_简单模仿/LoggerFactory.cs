using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Logging._02_简单模仿
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly Dictionary<string, Logger> _loggers = new Dictionary<string, Logger>(StringComparer.Ordinal);

        private readonly object _sync = new object();

        public ILogger CreateLogger(string categoryName)
        {
            Logger logger;
            lock (_sync)
            {
                if (!_loggers.TryGetValue(categoryName, out logger))
                {
                    logger = new Logger(this, categoryName);
                    _loggers[categoryName] = logger;
                }
            }
            return logger;
        }
    }
}
