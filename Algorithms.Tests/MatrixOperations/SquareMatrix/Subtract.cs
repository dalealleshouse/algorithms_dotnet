using System;
using Xunit;

namespace Algorithms.Tests.MatrixOperations.SquareMatrix
{
    public class Subtract
    {
        [Fact]
        public void Should_RejectDifferntSizeMatrix()
        {
            var a = new TestMatrix(4);
            var b = new TestMatrix(8);

            Assert.Throws<ArgumentException>(() => a - b);
        }

        [Fact]
        public void Should_RejectNullInput()
        {
            var a = new TestMatrix(4);
            TestMatrix b = null;

            Assert.Throws<ArgumentNullException>(() => a - null);
            Assert.Throws<ArgumentNullException>(() => null - a);
            Assert.Throws<ArgumentNullException>(() => b - b);
        }

        [Fact]
        public void Should_Overflow()
        {
            var a = new TestMatrix(new int[] { int.MinValue, 8, 3, 7 });
            var b = new TestMatrix(new int[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a - b);
        }
    }
}
