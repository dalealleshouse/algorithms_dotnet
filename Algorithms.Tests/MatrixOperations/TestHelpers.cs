namespace Algorithms.Tests.MatrixOperations
{
    using Algorithms.MatrixOperations;
    using System;
    using System.Linq;
    using Xunit;

    public static class TestHelpers
    {
        public static T CreateRandomMatrix<T>(int size)
            where T : SquareMatrix<long>
        {
            var rand = new Random();

            var data = Enumerable.Range(0, size * size)
                .Select(r => (long)rand.Next(100))
                .ToList();

            return (T)Activator.CreateInstance(typeof(T), data);

        }

        public static void MultiplyHappyPath<T>()
            where T : SquareMatrix<int>
        {
            var expected = MatrixFactory
                .CreateMatrix<T, int>(new int[] { 38, 17, 26, 14 });
            var a = MatrixFactory.CreateMatrix<T, int>(new int[] { 1, 7, 2, 4 });
            var b = MatrixFactory.CreateMatrix<T, int>(new int[] { 3, 3, 5, 2 });

            var result = a * b;
            Assert.Equal(expected, result);
        }

        public static void MultiplyMatchesNaive<T>()
            where T : SquareMatrix<long>
        {
            var size = 128;
            var n1 = TestHelpers.CreateRandomMatrix<NaiveSquareMatrix<long>>(size);
            var n2 = TestHelpers.CreateRandomMatrix<NaiveSquareMatrix<long>>(size);

            var expected = n1 * n2;

            var r1 = MatrixFactory.CreateMatrix<T, long>(n1.Data);
            var r2 = MatrixFactory.CreateMatrix<T, long>(n2.Data);

            Assert.Equal(expected, r1 * r2);
        }

    }
}
