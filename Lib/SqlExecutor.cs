using System.Collections.Generic;
using System.Data.SqlClient;
using AnglicanGeek.Dapper;

namespace AnglicanGeek.DbExecutor
{
    public class SqlExecutor : IDbExecutor
    {
        readonly SqlConnection sqlConnection;
        
        public SqlExecutor(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public int Execute(string sql, object param = null)
        {
            return sqlConnection.Execute(sql, param);
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            return sqlConnection.Query<T>(sql, param);
        }

        public void Dispose()
        {
            sqlConnection.Dispose();
        }
    }
}