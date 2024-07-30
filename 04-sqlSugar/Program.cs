using _04_sqlSugar.Model;
using SqlSugar;
using System.Linq.Expressions;

namespace _04_sqlSugar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //insert table
            //SugarContext.Client.Insertable<Person>(
            //    new List<Person> 
            //    { 
            //        new Person { Name = "小明", Age = 10 }, 
            //        new Person { Name = "小红", Age = 11 }, 
            //        new Person { Name = "小华", Age = 12 }, 
            //        new Person { Name = "小A", Age = 13 },
            //    }
            //).ExecuteCommand();

            //select table
            //var pls = SugarContext.Client.Queryable<Person>().Where(f => f.Id > 2);
            //var ps = pls.ToList();

            //update table
            //var person = SugarContext.Client.Queryable<Person>().First(f => f.Id == 4);
            //if (person != null)
            //{
            //    person.Age = 99;
            //    SugarContext.Client.Updateable<Person>(person).ExecuteCommand();
            //}

            //delete table
            //int count = SugarContext.Client.Deleteable<Person>(f => f.Id == 1).ExecuteCommand();
            //if (count > 0)
            //{
            //    Console.WriteLine($"删除id=1的数据");
            //}

            #region 多表查询
            //var count = SugarHelper.Add<Department>(new List<Department>()
            //{
            //    new Department { Name = "人力资源部" },
            //    new Department { Name = "IT技术部" },
            //    new Department { Name = "薪酬福利部" },
            //});
            //if (count > 0)
            //{
            //    Console.WriteLine($"已写入{count}条部门数据");
            //}

            //count = SugarHelper.Add<Employee>(new List<Employee>()
            //{
            //    new Employee { Name = "熊大", DepId = 1 },
            //    new Employee { Name = "王二", DepId = 1 },
            //    new Employee { Name = "张三",DepId = 1 },
            //    new Employee { Name = "李四",DepId = 2 },
            //    new Employee { Name = "赵五",DepId = 2 },
            //    new Employee { Name = "李六",DepId = 3 },
            //    new Employee { Name = "田七",DepId = 3 },
            //});
            //if (count > 0)
            //{
            //    Console.WriteLine($"已写入{count}条雇员数据");
            //}

            //var sugar = SugarContext.Client.Queryable<Employee>()
            //    .InnerJoin<Department>((em, dep) => em.DepId == dep.Id)
            //    .Where( (em, dep) => dep.Id == 1)
            //    .Select((em, dep) => new
            //    {
            //        id = em.Id,
            //        name = em.Name,
            //        depart_name = dep.Name
            //    });
            //Console.WriteLine(sugar.ToSqlString());
            //foreach (var item in sugar.ToList())
            //{
            //    Console.WriteLine($"id={item.id},name={item.name},departmentname={item.depart_name}");
            //}

            #endregion

        }
    }
}