namespace Algorithms.Tests.MatrixOperations
{
    using System;
    using System.Linq;
    using Algorithms.MatrixOperations;

    public static class MatrixGenerator
    {
        public static T CreateMatrix<T>(int size)
            where T : SquareMatrix<long>
        {
            var rand = new Random();

            var data = Enumerable.Range(0, size * size)
                .Select(r => (long)rand.Next(100))
                .ToList();

            return (T)Activator.CreateInstance(typeof(T), BinaryOps.Long, data);
        }
    }
}
