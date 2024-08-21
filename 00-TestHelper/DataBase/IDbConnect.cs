using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IDbConnect
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(string sql, DynamicParameters model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        object ExecuteScalar(CommandDefinition command);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool Transaction(List<string> list, ref string msg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<bool> TransactionAsync(List<string> list);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<bool> TransactionAllSuccessAsync(List<string> list);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool TransactionAllSuccess(List<string> list);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>

        bool Transaction(List<(string sql, object obj)> list, ref string msg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<bool> TransactionAsync(List<(string sql, object obj)> list);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>

        bool Transaction(List<(string sql, DynamicParameters model)> list, ref string msg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        Task<bool> TransactionAsync(List<(string sql, DynamicParameters model)> list);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        T? QueryFirstOrDefault<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        T QueryFirstOrDefault<T>(string sql, DynamicParameters model) where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<T?> QueryFirstOrDefaultAsync<T>(string sql, DynamicParameters model) where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        int Execute(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        int Execute(string sql, DynamicParameters model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> ExecuteAsync(string sql, DynamicParameters model);

        /// <summary>
        /// ExecuteActionAsync
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<int> ExecuteActionAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        IEnumerable<T> Query<T>(string sql, DynamicParameters model) where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters model) where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        IEnumerable<T> Query<T>(string sql, object? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        object ExecuteScalar(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<object?> ExecuteScalarAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        object? ExecuteScalar(string sql, DynamicParameters model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<object?> ExecuteScalarAsync(string sql, DynamicParameters model);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        T ExecuteScalar<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        T? ExecuteScalar<T>(string sql, DynamicParameters model) where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<T?> ExecuteScalarAsync<T>(string sql, DynamicParameters? model) where T : class, new();
    }
}
