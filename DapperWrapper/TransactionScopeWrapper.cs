using System;
using System.Transactions;

namespace DapperWrapper
{
    public class TransactionScopeWrapper : ITransactionScope
    {
        private readonly TransactionScope _transactionScope;
        
        public TransactionScopeWrapper(TransactionScope transactionScope)
        {
            if (transactionScope == null)
            {
                throw new ArgumentNullException("transactionScope");
            }

            _transactionScope = transactionScope;
            
        }
        
        /// <summary>
        /// Indicates all operations within this scope are completed successfully.
        /// </summary>
        public void Complete()
        {
            _transactionScope.Complete();
        }

        /// <summary>
        /// Ends the transaction scope.
        /// </summary>
        public void Dispose()
        {
            _transactionScope.Dispose();
        }
    }
}