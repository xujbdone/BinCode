using Logging;
using Logging.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Logger : ILogger
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly string _name;
        private readonly ILogger[] _loggers;

        public Logger(ILoggerFactory factory, string name)
        {
            _loggerFactory = factory;
            _name = name;

            var providers = _loggerFactory.GetProviders();
            if (providers.Length > 0)
            {
                _loggers = new ILogger[providers.Length];
                for (int i = 0; i < providers.Length; i++)
                {
                    _loggers[i] = providers[i];
                }
            }
        }
    }
}
