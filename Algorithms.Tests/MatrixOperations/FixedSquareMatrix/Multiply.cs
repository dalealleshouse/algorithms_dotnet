namespace Algorithms.Tests.MatrixOperations.FixedSquareMatrix
{
    using Algorithms.MatrixOperations;
    using System;
    using Xunit;

    public class Multiply
    {
        [Fact]
        public void Multiply_Overflow()
        {
            var a = new FixedSquareMatrix(new long[] { long.MaxValue, 8, 3, 7 });
            var b = new FixedSquareMatrix(new long[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a * b);
        }

        [Fact]
        public void Multiply_MatchesNaive()
        {
            TestHelpers.MultiplyMatchesNaive<FixedSquareMatrix>();
        }
    }
}
