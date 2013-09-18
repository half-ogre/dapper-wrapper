using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

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
            
            SqlMapper.GridReader QueryMultiple(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?));
    }
}
