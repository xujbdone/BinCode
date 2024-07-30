using NetTaste;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_sqlSugar
{
    public class SugarHelper
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Add<T>(T obj) where T : class, new ()
        {
            return SugarContext.Client.Insertable(obj).ExecuteCommand();
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static int Add<T>(IEnumerable<T> objs) where T : class, new()
        {
            var sugar = SugarContext.Client.Insertable<T>(objs);
            Logger.Sql(sugar.ToSqlString());
            return sugar.ExecuteCommand();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns>返回单个实体</returns>
        public static T QueryFirst<T>(Func<T, bool> func) where T : class, new()
        {
            return SugarContext.Client.Queryable<T>().First(f => func(f));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns>返回多个实体</returns>
        public static IEnumerable<T> Query<T>() where T : class, new()
        {
            var sugar = SugarContext.Client.Queryable<T>();
            Logger.Sql(sugar.ToSqlString());
            return sugar.ToList();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns>返回多个实体</returns>
        public static IEnumerable<T> Query<T>(Func<T, bool> func) where T : class, new()
        {
            return SugarContext.Client.Queryable<T>().Where(f => func(f)).ToList();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>影响行数</returns>
        public static int Update<T>(T obj) where T : class, new()
        {
            return SugarContext.Client.Updateable<T>(obj).ExecuteCommand();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>影响行数</returns>
        public static int Dalete<T>(T obj) where T : class, new()
        {
            return SugarContext.Client.Deleteable<T>(obj).ExecuteCommand();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>影响行数</returns>
        public static int Dalete<T>(Func<T, bool> func) where T : class, new()
        {
            return SugarContext.Client.Deleteable<T>(func).ExecuteCommand();
        }
    }
}
