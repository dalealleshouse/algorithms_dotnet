namespace Algorithms.Tests.MatrixOperations.StrassenSquareMatrix
{
    using System;
    using Xunit;
    using Algorithms.MatrixOperations;
    using System.Collections.Generic;

    public class Multiply
    {
        private StrassenSquareMatrix<int> SutFactory(IEnumerable<int> data)
        {
            return new StrassenSquareMatrix<int>(BinaryOps<int>.Int, data);
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
            var size = 128;
            var n1 = MatrixGenerator.CreateMatrix<NaiveSquareMatrix<long>>(size);
            var n2 = MatrixGenerator.CreateMatrix<NaiveSquareMatrix<long>>(size);

            var expected = n1 * n2;

            var r1 = new StrassenSquareMatrix<long>(BinaryOps<long>.Long, n1.Data);
            var r2 = new StrassenSquareMatrix<long>(BinaryOps<long>.Long, n2.Data);

            Assert.Equal(expected, r1 * r2);
        }
    }
}
