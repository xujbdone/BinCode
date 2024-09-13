using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Logging._02_简单模仿
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string categoryName);
    }
}
