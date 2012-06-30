using System.Transactions;

namespace DapperWrapper
{
    public class TransactionScopeWrapper : ITransactionScope
    {
        readonly TransactionScope _transactionScope;
        
        public TransactionScopeWrapper(TransactionScope transactionScope)
        {
            _transactionScope = transactionScope;
        }
        
        public void Complete()
        {
            _transactionScope.Complete();
        }

        public void Dispose()
        {
            _transactionScope.Dispose();
        }
    }
}