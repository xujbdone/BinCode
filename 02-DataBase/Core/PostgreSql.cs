using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataBase.Core
{
    internal class PostgreSql : IDbConnect
    {
        private static string _connectionString { get; set; }

        /// <summary>
        /// 构造数据库连接
        /// </summary>
        /// <param name="connectionString"></param>
        public PostgreSql(string connectionString)
        {
            _connectionString = connectionString;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(string sql, DynamicParameters? model)
        {

            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    sql = ChangeSQLStatement(sql);
                    var rsult = dbConnection.Execute(sql, model);
                    if (rsult > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int Execute(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.Execute(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                
                return 0;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 事务操作
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool Transaction(List<string> list, ref string msg)
        {
            int row = 0;
            string nowsql = "";
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    IDbTransaction transaction = dbConnection.BeginTransaction();
                    foreach (string sql in list)
                    {
                        nowsql = ChangeSQLStatement(sql);
                        dbConnection.Execute(nowsql, null, transaction);
                        row++;
                    }
                    transaction.Commit();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString() + "语句开始：" + nowsql + "语句结束";
                row = 0;
            }
            return row > 0;
        }


        /// <summary>
        /// 事务操作
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<bool> TransactionAsync(List<string> list)
        {
            int row = 0;
            string nowsql = "";
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    IDbTransaction transaction = dbConnection.BeginTransaction();
                    foreach (string sql in list)
                    {
                        nowsql = ChangeSQLStatement(sql);
                        await dbConnection.ExecuteAsync(nowsql, null, transaction);
                        row++;
                    }
                    transaction.Commit();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                row = 0;
            }
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 事务操作
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<bool> TransactionAllSuccessAsync(List<string> list)
        {
            int row = 0;
            string nowsql = "";
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    IDbTransaction transaction = dbConnection.BeginTransaction();
                    var temprow = 0;
                    foreach (string sql in list)
                    {
                        nowsql = ChangeSQLStatement(sql);
                        temprow = await dbConnection.ExecuteAsync(nowsql, null, transaction);
                        if (temprow > 0)
                        {
                            row++;
                        }
                        else
                        {
                            throw new Exception($"执行的sql结果为空,{nowsql}");
                        }
                    }
                    transaction.Commit();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                row = 0;
            }
            return row > 0;
        }


        /// <summary>
        /// 事务操作
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool TransactionAllSuccess(List<string> list)
        {
            int row = 0;
            string nowsql = "";
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    IDbTransaction transaction = dbConnection.BeginTransaction();
                    var temprow = 0;
                    foreach (string sql in list)
                    {
                        nowsql = ChangeSQLStatement(sql);
                        temprow = dbConnection.Execute(nowsql, null, transaction);
                        if (temprow > 0)
                        {
                            row++;
                        }
                        else
                        {
                            throw new Exception($"执行的sql结果为空,{nowsql}");
                        }
                    }
                    transaction.Commit();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                row = 0;
            }
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Execute(string sql, DynamicParameters? model)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                
                
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.Execute(sql, model);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, DynamicParameters? model)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                
                
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.ExecuteAsync(sql, model);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 事务操作
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool Transaction(List<(string sql, object obj)> list, ref string msg)
        {
            int row = 0;
            string nowsql = "";
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    IDbTransaction transaction = dbConnection.BeginTransaction();
                    foreach (var item in list)
                    {
                        nowsql = ChangeSQLStatement(item.sql); ;
                        dbConnection.Execute(nowsql, item.obj, transaction);
                        row++;
                    }
                    transaction.Commit();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                msg = ex.ToString() + "语句开始：" + nowsql + "语句结束";
                row = 0;
            }
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 事务操作
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<bool> TransactionAsync(List<(string sql, object obj)> list)
        {
            int row = 0;
            string nowsql = "";
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    IDbTransaction transaction = dbConnection.BeginTransaction();
                    foreach (var item in list)
                    {
                        nowsql = ChangeSQLStatement(item.sql); ;
                        await dbConnection.ExecuteAsync(nowsql, item.obj, transaction);
                        row++;
                    }
                    transaction.Commit();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                row = 0;
            }
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 事务操作 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool Transaction(List<(string sql, DynamicParameters model)> list, ref string msg)
        {
            int row = 0;
            string nowsql = "";
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    IDbTransaction transaction = dbConnection.BeginTransaction();
                    foreach (var item in list)
                    {
                        nowsql = ChangeSQLStatement(item.sql); ;
                        dbConnection.Execute(nowsql, item.model, transaction);
                        row++;
                    }
                    transaction.Commit();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString() + "语句开始：" + nowsql + "语句结束";
                row = 0;
            }
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 事务操作
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<bool> TransactionAsync(List<(string sql, DynamicParameters model)> list)
        {
            int row = 0;
            string nowsql = "";
            try
            {
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    dbConnection.Open();
                    IDbTransaction transaction = dbConnection.BeginTransaction();
                    foreach (var item in list)
                    {
                        nowsql = ChangeSQLStatement(item.sql); ;
                        
                        
                        await dbConnection.ExecuteAsync(nowsql, item.model, transaction);
                        row++;
                    }
                    transaction.Commit();
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                row = 0;
            }
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 记录请求日志的sql不写入日志文件 瘦身日志
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<int> ExecuteActionAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        /// 
        public T ExecuteScalar<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class, new()
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.ExecuteScalar<T?>(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public object ExecuteScalar(CommandDefinition command)
        {
            try
            {

                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.ExecuteScalar(command);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.ExecuteScalar(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询多行数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询多行数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询一行数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public T QueryFirstOrDefault<T>(string sql, DynamicParameters? model) where T : class, new()
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                
                
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.QueryFirstOrDefault<T?>(sql, model);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询多行数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters? model) where T : class, new()
        {
            try
            {
                sql = ChangeSQLStatement(sql);

                
                
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.QueryAsync<T>(sql, model);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询多行数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, DynamicParameters? model) where T : class, new()
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                
                
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.Query<T>(sql, model);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        public object? ExecuteScalar(string sql, DynamicParameters? model)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                
                
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.ExecuteScalar(sql, model);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        public async Task<object?> ExecuteScalarAsync(string sql, DynamicParameters? model)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.ExecuteScalarAsync(sql, model);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>

        public T? ExecuteScalar<T>(string sql, DynamicParameters? model) where T : class, new()
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.ExecuteScalar<T?>(sql, model);
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<T?> ExecuteScalarAsync<T>(string sql, DynamicParameters? model) where T : class, new()
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.ExecuteScalarAsync<T?>(sql, model);
                }
            }
            catch (Exception ex)
            {

                return default;
            }
        }


        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<object?> ExecuteScalarAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        /// <summary>
        /// 查询第一行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, DynamicParameters? model) where T : class, new()
        {
            try
            {
                sql = ChangeSQLStatement(sql);

                
                
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.QueryFirstOrDefaultAsync<T?>(sql, model);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 查询第一行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public T? QueryFirstOrDefault<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return dbConnection.QueryFirstOrDefault<T?>(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }


        /// <summary>
        /// 查询第一行第一列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);
                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.QueryFirstOrDefaultAsync<T?>(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }

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
        public async Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                sql = ChangeSQLStatement(sql);

                using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
                {
                    return await dbConnection.ExecuteScalarAsync<T?>(sql, param, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }


        /// <summary>
        /// 进行sql转换  将oracle的sql转成pg可以兼容的语句
        /// </summary>
        /// <param name="as_sqlstr"></param>
        /// <returns></returns>
        private string ChangeSQLStatement(string as_sqlstr)
        {
            string ls_newSqlStr;

            ls_newSqlStr = as_sqlstr;

            //ls_newSqlStr = CheckSQLSubSelect(ls_newSqlStr);
            ls_newSqlStr = Checkstring_agg(ls_newSqlStr);

            if (!ls_newSqlStr.Contains("replace("))
            {
                //PostgreSql 不支持空字符自动转数字或日期
                ls_newSqlStr = ls_newSqlStr.Replace(",''", ",null ");
            }


            ls_newSqlStr = ls_newSqlStr.Replace("to_date(sysdate)", "CURRENT_DATE");
            ls_newSqlStr = ls_newSqlStr.Replace("to_date(", "to_timestamp(");
            ls_newSqlStr = ls_newSqlStr.Replace("trunc(sysdate,'MONTH')", "CURRENT_DATE");
            ls_newSqlStr = ls_newSqlStr.Replace("trunc(sysdate)", "CURRENT_DATE");
            //ls_newSqlStr = ls_newSqlStr.Replace("sysdate", "CURRENT_DATE");
            ls_newSqlStr = ls_newSqlStr.Replace("sysdate", "now()");

            ls_newSqlStr = ls_newSqlStr.Replace("nvl(", "coalesce(");
            ls_newSqlStr = ls_newSqlStr.Replace("nvl2(", "coalesce(");
            ls_newSqlStr = ls_newSqlStr.Replace("NVL(", "coalesce(");

            ls_newSqlStr = ls_newSqlStr.Replace("where rownum <= 30", "LIMIT 30 OFFSET 0");
            ls_newSqlStr = ls_newSqlStr.Replace("and rownum <= 30", "LIMIT 30 OFFSET 0");
            ls_newSqlStr = ls_newSqlStr.Replace("where rownum <= 50", "LIMIT 50 OFFSET 0");
            ls_newSqlStr = ls_newSqlStr.Replace("and rownum <= 50", "LIMIT 50 OFFSET 0");
            ls_newSqlStr = ls_newSqlStr.Replace("where rownum <= 100", "LIMIT 100 OFFSET 0");
            ls_newSqlStr = ls_newSqlStr.Replace("and rownum <= 100", "LIMIT 100 OFFSET 0");
            ls_newSqlStr = ls_newSqlStr.Replace("where rownum <= 10 ", "LIMIT 10 OFFSET 0 ");
            ls_newSqlStr = ls_newSqlStr.Replace("where rownum=10 ", "LIMIT 10 OFFSET 0 ");

            ls_newSqlStr = ls_newSqlStr.Replace("where rownum <= 1 ", "LIMIT 1 OFFSET 0 ");
            ls_newSqlStr = ls_newSqlStr.Replace("where rownum=1 ", "LIMIT 1 OFFSET 0 ");
            ls_newSqlStr = ls_newSqlStr.Replace("and rownum=1", "LIMIT 1");
            if (!ls_newSqlStr.Contains("row_number()"))
            {
                ls_newSqlStr = ls_newSqlStr.Replace("rownum", "row_number() over() ");

            }

            ls_newSqlStr = ls_newSqlStr.Replace("from dual", " ");


            return ls_newSqlStr;
        }

        private string CheckSQLSubSelect(string as_sqlstr)
        {
            //在子查询语句后面加上别名，oracle支持子查询语句没有别名，其他数据库不支持
            string ls_newSqlStr;

            ls_newSqlStr = as_sqlstr;

            int li_pos1 = ls_newSqlStr.ToLower().IndexOf("from (");

            if (li_pos1 > 0)
            {
                int li_pos2 = ls_newSqlStr.Substring(0, li_pos1).LastIndexOf("(");
                int li_pos3 = -1;

                if (li_pos2 >= 0)
                {
                    string ls_subStr = ls_newSqlStr;

                    for (int i = 0; i < li_pos2; i++)
                    {
                        li_pos3 = ls_subStr.LastIndexOf(")");

                        if (li_pos3 > 0)
                        {
                            ls_subStr = ls_subStr.Substring(0, li_pos3);
                        }
                    }
                }
                else
                {
                    li_pos3 = ls_newSqlStr.LastIndexOf(")");
                }

                if (li_pos3 > 0)
                {
                    if (ls_newSqlStr.Substring(li_pos3 + 1, 3) != " t " && ls_newSqlStr.Substring(li_pos3 + 1, 3) != " t1")
                    {
                        ls_newSqlStr = ls_newSqlStr.Substring(0, li_pos3 + 1) + " t1 " + ls_newSqlStr.Substring(li_pos3 + 1);
                    }
                }
            }

            return ls_newSqlStr;
        }

        private string Checkstring_agg(string as_sqlstr)
        {

            string ls_newSqlStr = as_sqlstr;
            int li_pos1 = ls_newSqlStr.ToLower().IndexOf("string_agg(");
            if (li_pos1 > 0)
            {
                string ls_subStr = as_sqlstr.Substring(li_pos1, ls_newSqlStr.Length - li_pos1);
                int point2 = ls_subStr.IndexOf(")");
                string ls_start = ls_newSqlStr.Substring(0, li_pos1);
                string ls_end = ls_subStr.Substring(point2 + 1, ls_subStr.Length - (point2 + 1));
                string between = ls_subStr.Substring(0, point2 + 1).Replace(")", ",',')");
                string newstr = ls_start + between + ls_end;
                return newstr;

            }
            else
            {
                return ls_newSqlStr;
            }

        }

       
    }
}
