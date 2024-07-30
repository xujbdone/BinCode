using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_sqlSugar.Model
{
    [SqlSugar.SugarTable("Employee")]
    public class Employee
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepId { get; set; }
    }
}
