using System;

namespace AnglicanGeek.DbExecutor
{
    public interface ITransactionScope : IDisposable
    {
        void Complete();
    }
}
