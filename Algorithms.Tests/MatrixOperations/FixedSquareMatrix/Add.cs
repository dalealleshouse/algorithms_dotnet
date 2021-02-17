namespace Algorithms.Tests.MatrixOperations.FixedSquareMatrix
{
    using Algorithms.MatrixOperations;
    using System;
    using Xunit;

    public class Add
    {
        [Fact]
        public void RejectDifferntSizeMatrix()
        {
            var a = new FixedSquareMatrix(4);
            var b = new FixedSquareMatrix(8);

            Assert.Throws<ArgumentException>(() => a + b);
        }

        [Fact]
        public void RejectNullInput()
        {
            var a = new FixedSquareMatrix(4);
            FixedSquareMatrix b = null;

            Assert.Throws<ArgumentNullException>(() => a + null);
            Assert.Throws<ArgumentNullException>(() => null + a);
            Assert.Throws<ArgumentNullException>(() => b + b);
        }

        [Fact]
        public void Should_Overflow()
        {
            var a = new FixedSquareMatrix(new long[] { long.MaxValue, 8, 3, 7 });
            var b = new FixedSquareMatrix(new long[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a + b);
        }
    }
}
