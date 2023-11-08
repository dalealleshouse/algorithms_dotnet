#nullable disable

namespace Algorithms.MatrixOperations;

using System;
using System.Collections.Generic;

public static class MatrixFactory
{
    public static T CreateMatrix<T, TU>(IEnumerable<TU> data)
        where T : SquareMatrix<TU>
    {
        return (T)Activator.CreateInstance(typeof(T), data);
    }

    public static T CreateMatrix<T, TU>(int size)
        where T : SquareMatrix<TU>
    {
        return (T)Activator.CreateInstance(typeof(T), size);
    }
}
