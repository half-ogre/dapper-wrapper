
namespace DbExecutor
{
    public interface IDbExecutorFactory
    {
        IDbExecutor CreateExecutor();
        ITransactionScope CreateTransactionScope();
    }
}