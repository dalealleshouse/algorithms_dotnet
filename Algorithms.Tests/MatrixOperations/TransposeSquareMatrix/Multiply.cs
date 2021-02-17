namespace Algorithms.Tests.MatrixOperations.TransposeMatrixMultiply
{
    using Algorithms.MatrixOperations;
    using System;
    using Xunit;

    public class Multiply
    {
        [Fact]
        public void Multiply_Overflow()
        {
            var a = new TransposeSquareMatrix<int>(
                    new int[] { int.MaxValue, 8, 3, 7 });
            var b = new TransposeSquareMatrix<int>(new int[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a * b);
        }

        [Fact]
        public void Multiply_HappyPath()
        {
            TestHelpers.MultiplyHappyPath<TransposeSquareMatrix<int>>();
        }

        [Fact]
        public void Multiply_MatchesNaive()
        {
            TestHelpers.MultiplyMatchesNaive<TransposeSquareMatrix<long>>();
        }
    }
}
