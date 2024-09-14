using MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.LoggingBuilder
{
    public interface ILoggingBuilder
    {
        IServiceCollection Service { get; }
    }
}
