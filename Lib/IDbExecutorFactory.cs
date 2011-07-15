
namespace AnglicanGeek.DbExecutor
{
    public interface IDbExecutorFactory
    {
        IDbExecutor CreateExecutor();
        ITransactionScope CreateTransactionScope();
    }
}