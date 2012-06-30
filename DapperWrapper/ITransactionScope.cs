using System;

namespace DapperWrapper
{
    public interface ITransactionScope : IDisposable
    {
        void Complete();
    }
}
