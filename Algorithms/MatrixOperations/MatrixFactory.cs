namespace Algorithms.MatrixOperations
{
    using System;
    using System.Collections.Generic;

    public static class MatrixFactory
    {
        public static T CreateMatrix<T, U>(IEnumerable<U> data)
            where T : SquareMatrix<U>
        {
            return (T)Activator.CreateInstance(typeof(T), data);
        }


        public static T CreateMatrix<T, U>(int size)
            where T : SquareMatrix<U>
        {
            return (T)Activator.CreateInstance(typeof(T), size);
        }
    }
}
