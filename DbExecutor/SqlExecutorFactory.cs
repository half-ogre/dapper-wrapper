using System;
using System.Data.SqlClient;
using System.Transactions;

namespace DbExecutor
{ 
    public class SqlExecutorFactory : IDbExecutorFactory
    {
        readonly string connectionString;
        
        public SqlExecutorFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString");
            
            this.connectionString = connectionString;
        }
        
        public IDbExecutor CreateExecutor()
        {
            var dbConnection = new SqlConnection(connectionString);
            
            dbConnection.Open();

            return new SqlExecutor(dbConnection);
        }


        public ITransactionScope CreateTransactionScope()
        {
            return new TransactionScopeWrapper(new TransactionScope());
        }
    }
}