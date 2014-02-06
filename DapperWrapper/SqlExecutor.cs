using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace DapperWrapper
{
    public class SqlExecutor : IDbExecutor
    {
        private readonly IDbConnection _dbConnection;
        
        public SqlExecutor(IDbConnection dbConnection)
        {
            if (dbConnection == null)
            {
                throw new ArgumentNullException();
            }

            _dbConnection = dbConnection;
        }

        public int Execute(
            string sql, 
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = default(int?),
            CommandType? commandType = default(CommandType?))
        {
            return _dbConnection.Execute(
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
            return _dbConnection.Query(
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
            return _dbConnection.Query<T>(
                sql, 
                param,
                transaction,
                buffered,
                commandTimeout,
                commandType);
        }

        /// <summary>
        /// Opens a database connection with the setting specified by the ConnectionString property of the provider-specific Connection object.
        /// </summary>
        public void Open()
        {
            _dbConnection.Open();
        }

        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public void Close()
        {
            _dbConnection.Close();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}