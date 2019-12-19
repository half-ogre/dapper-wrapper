using System;
using System.Collections.Generic;
using System.Data;

namespace DapperWrapper
{
    public interface IDbExecutor : IDisposable
    {
        int Execute(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?));

        IEnumerable<dynamic> Query(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?));

        IEnumerable<T> Query<T>(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?));

        IEnumerable<TReturn> Query<T1, T2, TReturn>(
            string sql,
            Func<T1, T2, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?));

        IEnumerable<TReturn> Query<T1, T2, T3, TReturn>(
            string sql,
            Func<T1, T2, T3, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?));

        IEnumerable<TReturn> Query<T1, T2, T3, T4, TReturn>(
            string sql,
            Func<T1, T2, T3, T4, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?));

        IEnumerable<TReturn> Query<T1, T2, T3, T4, T5, TReturn>(
            string sql,
            Func<T1, T2, T3, T4, T5, TReturn> map,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            string splitOn = "Id",
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?));

        IGridReaderWrapper QueryMultiple(
            string sql,
            dynamic param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null);
    }
}