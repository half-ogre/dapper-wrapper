using System.Transactions;

namespace DbExecutor
{
    public class TransactionScopeWrapper : ITransactionScope
    {
        readonly TransactionScope transactionScope;
        
        public TransactionScopeWrapper(TransactionScope transactionScope)
        {
            this.transactionScope = transactionScope;
        }
        
        public void Complete()
        {
            transactionScope.Complete();
        }

        public void Dispose()
        {
            transactionScope.Dispose();
        }
    }
}
