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
        
            public SqlMapper.GridReader QueryMultiple(
            string sql,
            object param = null, 
            IDbTransaction transaction = null,
            int? commandTimeout = default(int?), 
            CommandType? commandType = default(CommandType?))
        {
            return _sqlConnection.QueryMultiple(
                sql,
                param,
                transaction,
                commandTimeout,
                commandType);
        }

        public void Dispose()
        {
            _sqlConnection.Dispose();
        }
    }
}
