using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class ConnectionOption
    {
        public string DbType { get; set; }

        public string Name { get; set; }

        public string Connection { get; set; }
    }

    public class DbTypeConst
    {
        public const string PostgreSql = "PostgreSql";
    }
}
