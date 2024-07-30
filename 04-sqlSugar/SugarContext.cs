using _04_sqlSugar.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_sqlSugar
{
    /// <summary>
    /// sqlSugar操作类
    /// </summary>
    public class SugarContext
    {
        public static SqlSugarClient Client { get; }

        static SugarContext()
        {
            Client = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = "Data Source='127.0.0.1';database='nodejs';User Id='root';pwd='jinbin88';charset='utf8';pooling=true",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            Client.CodeFirst.InitTables<Person, Employee, Department>();
        }
    }
}
