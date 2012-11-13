using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DapperWrapper
{
    public class SqlExecutor : IDbExecutor
    {
        readonly SqlConnection _sqlConnection;
        
        public SqlExecutor(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public int Execute(
            string sql, 
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?))
        {
            return _sqlConnection.Execute(
                sql, 
                param,
                transaction,
                commandTimeout,
                commandType);
        }

        public IEnumerable<dynamic> Query(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?))
        {
            return _sqlConnection.Query(
                sql,
                param,
                transaction,
                buffered,
                commandTimeout,
                commandType);
        }

        public IEnumerable<T> Query<T>(
            string sql, 
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?))
        {
            return _sqlConnection.Query<T>(
                sql, 
                param,
                transaction,
                buffered,
                commandTimeout,
                commandType);
        }

        public IEnumerable<TReturn> Query<T1, T2, TReturn>(
            string sql,
            Func<T1, T2, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?))
        {
            return _sqlConnection.Query(
                sql,
                map,
                param,
                transaction,
                buffered,
                splitOn,
                commandTimeout,
                commandType);
        }

        public IEnumerable<TReturn> Query<T1, T2, T3, TReturn>(
            string sql,
            Func<T1, T2, T3, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?))
        {
            return _sqlConnection.Query(
                sql,
                map,
                param,
                transaction,
                buffered,
                splitOn,
                commandTimeout,
                commandType);
        }

        public IEnumerable<TReturn> Query<T1, T2, T3, T4, TReturn>(
            string sql,
            Func<T1, T2, T3, T4, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?))
        {
            return _sqlConnection.Query(
                sql,
                map,
                param,
                transaction,
                buffered,
                splitOn,
                commandTimeout,
                commandType);
        }

        public IEnumerable<TReturn> Query<T1, T2, T3, T4, T5, TReturn>(
            string sql,
            Func<T1, T2, T3, T4, T5, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?))
        {
            return _sqlConnection.Query(
                sql,
                map,
                param,
                transaction,
                buffered,
                splitOn,
                commandTimeout,
                commandType);
        }

        public IGridReaderWrapper QueryMultiple(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null)
        {
            var gridReader = _sqlConnection.QueryMultiple(
                    sql,
                    param,
                    transaction,
                    commandTimeout,
                    commandType);

            return new GridReaderWrapper(gridReader);
        }

        public void Dispose()
        {
            _sqlConnection.Dispose();
        }
    }
}