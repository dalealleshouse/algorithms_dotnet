namespace Algorithms.Tests.MatrixOperations.SquareMatrix
{
    using System;
    using Xunit;

    public class Add
    {
        [Fact]
        public void RejectDifferntSizeMatrix()
        {
            var a = new TestMatrix(4);
            var b = new TestMatrix(8);

            Assert.Throws<ArgumentOutOfRangeException>(() => a + b);
        }

        [Fact]
        public void RejectNullInput()
        {
            var a = new TestMatrix(4);
            TestMatrix b = null;

            Assert.Throws<ArgumentNullException>(() => a + null);
            Assert.Throws<ArgumentNullException>(() => null + a);
            Assert.Throws<ArgumentNullException>(() => b + b);
        }
    }
}
