using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Factory
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string categoryName);

        ILogger[] GetProviders();
    }
}
