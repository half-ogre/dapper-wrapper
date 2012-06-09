using System;

namespace DbExecutor
{
    public interface ITransactionScope : IDisposable
    {
        void Complete();
    }
}
