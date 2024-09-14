﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.LoggingProvider
{
    public interface ILoggerProvider
    {
        ILogger CreateLogger(string categoryName);
    }
}
