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

            Assert.Throws<ArgumentException>(() => a + b);
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

        [Fact]
        [Trait("Category", "Temp")]
        public void Should_Overflow()
        {
            var a = new TestMatrix(new int[] { int.MaxValue, 8, 3, 7 });
            var b = new TestMatrix(new int[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a + b);
        }
    }
}
