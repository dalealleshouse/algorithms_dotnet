namespace Algorithms.Tests.MatrixOperations.SquareMatrix
{
    using System;
    using Xunit;

    public class Constructor
    {
        [Fact]
        public void Should_RejectNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => new TestMatrix(null));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(15)]
        [InlineData(31)]
        public void Should_RejectNonPowerOfTwo(uint size)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TestMatrix(size));
        }

        [Theory]
        [InlineData(8)]
        [InlineData(5)]
        [InlineData(15)]
        [InlineData(31)]
        public void Should_RejectDataThatIsNotSquare(int size)
        {
            int[] dummy = new int[size];
            Assert.Throws<ArgumentOutOfRangeException>(() => new TestMatrix(dummy));
        }
    }
}
