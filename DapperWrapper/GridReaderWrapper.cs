using System;
using System.Collections.Generic;
using Dapper;

namespace DapperWrapper
{
    class GridReaderWrapper : IGridReaderWrapper
    {
        private SqlMapper.GridReader _gridReader;

        public GridReaderWrapper(SqlMapper.GridReader gridReader)
        {
            _gridReader = gridReader;
        }

        public IEnumerable<T> Read<T>()
        {
            return _gridReader.Read<T>();
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TReturn>(
            Func<TFirst, TSecond, TReturn> func, 
            string splitOn = "id")
        {
            return _gridReader.Read(func, splitOn);
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TReturn>(
            Func<TFirst, TSecond, TThird, TReturn> func, 
            string splitOn = "id")
        {
            return _gridReader.Read(func, splitOn);
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TReturn>(
            Func<TFirst, TSecond, TThird, TFourth, TReturn> func, 
            string splitOn = "id")
        {
            return _gridReader.Read(func, splitOn);
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> func, 
            string splitOn = "id")
        {
            return _gridReader.Read(func, splitOn);
        }

        public void Dispose()
        {
            _gridReader.Dispose();
        }
    }
}
