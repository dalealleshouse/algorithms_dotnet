namespace Algorithms.Tests.MatrixOperations
{
    using System;
    using Xunit;
    using Algorithms.MatrixOperations;
    using System.Collections.Generic;

    public class RecursiveSquareMatrix_Multiply
    {
        private RecursiveSquareMatrix<int> SutFactory(IEnumerable<int> data)
        {
            return new RecursiveSquareMatrix<int>(BinaryOps<int>.Int(), data);
        }

        [Fact]
        public void Multiply_Overflow()
        {
            var a = SutFactory(new int[] { int.MaxValue, 8, 3, 7 });
            var b = SutFactory(new int[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a * b);
        }

        [Fact]
        public void Multiply_MatchesNaive()
        {
            var size = 32;
            var n1 = MatrixGenerator.NaiveMatrixGenerator(size);
            var n2 = MatrixGenerator.NaiveMatrixGenerator(size);

            var expected = n1 * n2;

            var r1 = new RecursiveSquareMatrix<int>(
                    BinaryOps<int>.Int(), n1.Data);
            var r2 = new RecursiveSquareMatrix<int>(
                    BinaryOps<int>.Int(), n2.Data);

            Assert.Equal(expected, r1 * r2);
        }
    }
}
