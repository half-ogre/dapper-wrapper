using System;
using System.Collections.Generic;

namespace DbExecutor
{
    public interface IDbExecutor : IDisposable
    {
        int Execute(string sql, object param = null);

        IEnumerable<T> Query<T>(string sql, object param = null);
    }
}