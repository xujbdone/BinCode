using Dapper;
using DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class DbHelper
    {
        public static IDbConnect Db { get; private set; }

        public static string DbType { get; private set; }

        static DbHelper()
        {
            var connectionStr = "{Connection:\"User ID=postgres;Password=jinbin88;Host=127.0.0.1;Port=5432;Database=postgres;Pooling=true;\",DbType:\"PostgreSql\"}";
            var options = Newtonsoft.Json.JsonConvert.DeserializeObject<ConnectionOption>(connectionStr);
            if (options?.DbType == DbTypeConst.PostgreSql)
            {
                Db = new PostgreSql(options.Connection);
                DbType = options.DbType;
            }
        }


        /// <summary>
        /// Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static IEnumerable<T> Query<T>(string sql, object? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {

            return Db.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }

        /// <summary>
        /// QueryAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {

            return await Db.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Db.ExecuteScalar(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// ExecuteScalarAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static async Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Db.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// 添加  参数化
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(string sql, DynamicParameters model)
        {
            return Db.Add(sql, model);
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Transaction(List<string> list, ref string msg)
        {
            return Db.Transaction(list, ref msg);
        }

        /// <summary>
        /// TransactionAsync
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static async Task<bool> TransactionAsync(List<string> list)
        {
            return await Db.TransactionAsync(list);
        }

        /// <summary>
        /// 执行事务,全部语句成功并且影响>0,返回true
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static async Task<bool> TransactionAllSuccessAsync(List<string> list)
        {
            return await Db.TransactionAllSuccessAsync(list);
        }

        /// <summary>
        /// 执行事务,全部语句成功并且影响>0,返回true
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool TransactionAllSuccess(List<string> list)
        {
            return Db.TransactionAllSuccess(list);
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static int Execute(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Db.Execute(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async static Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Db.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// ExecuteActionAsync
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async static Task<int> ExecuteActionAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Db.ExecuteActionAsync(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// QueryAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters model) where T : class, new()
        {
            return await Db.QueryAsync<T>(sql, model);
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IEnumerable<T> Query<T>(string sql, DynamicParameters model) where T : class, new()
        {
            return Db.Query<T>(sql, model);
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Execute(string sql, DynamicParameters model)
        {
            return Db.Execute(sql, model);
        }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<int> ExecuteAsync(string sql, DynamicParameters model)
        {
            return await Db.ExecuteAsync(sql, model);
        }

        /// <summary>
        /// 获取第一行第一列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns>object</returns>
        public static object? ExecuteScalar(string sql, DynamicParameters model)
        {
            return Db.ExecuteScalar(sql, model);
        }

        /// <summary>
        ///  获取第一行第一列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<object?> ExecuteScalarAsync(string sql, DynamicParameters model)
        {
            return await Db.ExecuteScalarAsync(sql, model);
        }

        /// <summary>
        /// 获取第一行第一列数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns>T</returns>
        public static T? ExecuteScalar<T>(string sql, DynamicParameters model) where T : class, new()
        {
            return Db.ExecuteScalar<T>(sql, model);
        }

        /// <summary>
        /// 获取第一行第一列数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<T?> ExecuteScalarAsync<T>(string sql, DynamicParameters model) where T : class, new()
        {
            return await Db.ExecuteScalarAsync<T>(sql, model);
        }

        /// <summary>
        /// 获取第一行第一列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static async Task<object?> ExecuteScalarAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Db.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// QueryFirstOrDefaultAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, DynamicParameters model) where T : class, new()
        {
            return await Db.QueryFirstOrDefaultAsync<T>(sql, model);
        }

        /// <summary>
        /// QueryFirstOrDefault
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static T? QueryFirstOrDefault<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Db.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// QueryFirstOrDefaultAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await Db.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Transaction(List<(string sql, object obj)> list, ref string msg)
        {
            return Db.Transaction(list, ref msg);
        }

        /// <summary>
        /// TransactionAsync
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static async Task<bool> TransactionAsync(List<(string sql, object obj)> list)
        {
            return await Db.TransactionAsync(list);
        }

        /// <summary>
        /// Transaction
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Transaction(List<(string sql, DynamicParameters model)> list, ref string msg)
        {
            return Db.Transaction(list, ref msg);
        }

        /// <summary>
        /// TransactionAsync
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static async Task<bool> TransactionAsync(List<(string sql, DynamicParameters model)> list)
        {
            return await Db.TransactionAsync(list);
        }
    }
}
