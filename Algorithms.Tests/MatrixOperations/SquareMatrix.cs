namespace Algorithms.Tests
{
    using System;
    using Xunit;

    public class SquareMatrix
    {
        [Fact]
        public void Constructor_RejectNullValue()
        {
            Assert.Throws<ArgumentNullException>(
                    () => new TestMatrix(4, null));
            Assert.Throws<ArgumentNullException>(
                    () => new TestMatrix(null, new int[4] { 1, 2, 3, 4 }));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(15)]
        [InlineData(31)]
        public void Constructor_RejectNonPowerOfTwo(int size)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => new TestMatrix(size));

            int[] dummy = new int[size];
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => new TestMatrix(dummy));
        }

        [Fact]
        public void Add_RejectDifferntSizeMatrix()
        {
            var a = new TestMatrix(4);
            var b = new TestMatrix(8);

            Assert.Throws<ArgumentOutOfRangeException>(() => a + b);
        }

        [Fact]
        public void Add_RejectNullInput()
        {
            var a = new TestMatrix(4);
            TestMatrix b = null;

            Assert.Throws<ArgumentNullException>(() => a + null);
            Assert.Throws<ArgumentNullException>(() => null + a);
            Assert.Throws<ArgumentNullException>(() => b + b);
        }

        [Fact]
        public void Add_Overflow()
        {
            var a = new TestMatrix(new int[] { int.MaxValue, 8, 3, 7 });
            var b = new TestMatrix(new int[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a + b);
        }

        [Fact]
        public void Add_HappyPath()
        {
            var expected = new TestMatrix(new int[] { 5, 8, 8, 9 });
            var a = new TestMatrix(new int[] { 4, 8, 3, 7 });
            var b = new TestMatrix(new int[] { 1, 0, 5, 2 });

            var result = a + b;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Subtract_RejectDifferntSizeMatrix()
        {
            var a = new TestMatrix(4);
            var b = new TestMatrix(8);

            Assert.Throws<ArgumentOutOfRangeException>(() => a - b);
        }

        [Fact]
        public void Subtract_RejectNullInput()
        {
            var a = new TestMatrix(4);
            TestMatrix b = null;

            Assert.Throws<ArgumentNullException>(() => a - null);
            Assert.Throws<ArgumentNullException>(() => null - a);
            Assert.Throws<ArgumentNullException>(() => b - b);
        }

        [Fact]
        public void Subtract_Overflow()
        {
            var a = new TestMatrix(new int[] { int.MinValue, 8, 3, 7 });
            var b = new TestMatrix(new int[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a - b);
        }

        [Fact]
        public void Subtract_HappyPath()
        {
            var expected = new TestMatrix(new int[] { -3, 2, -11, 6 });
            var a = new TestMatrix(new int[] { 2, 8, 0, 9 });
            var b = new TestMatrix(new int[] { 5, 6, 11, 3 });

            var result = a - b;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Multiply_RejectDifferntSizeMatrix()
        {
            var a = new TestMatrix(4);
            var b = new TestMatrix(8);

            Assert.Throws<ArgumentOutOfRangeException>(() => a * b);
        }

        [Fact]
        public void Multiply_RejectNullInput()
        {
            var a = new TestMatrix(4);
            TestMatrix b = null;

            Assert.Throws<ArgumentNullException>(() => a * null);
            Assert.Throws<ArgumentNullException>(() => null * a);
            Assert.Throws<ArgumentNullException>(() => b * b);
        }

        [Fact]
        public void Multiply_Overflow()
        {
            var a = new TestMatrix(new int[] { int.MaxValue, 8, 3, 7 });
            var b = new TestMatrix(new int[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a * b);
        }


        [Fact]
        public void Multiply_HappyPath()
        {
            var expected = new TestMatrix(new int[] { 38, 17, 26, 14 });
            var a = new TestMatrix(new int[] { 1, 7, 2, 4 });
            var b = new TestMatrix(new int[] { 3, 3, 5, 2 });

            var result = a * b;
            Assert.Equal(expected, result);
        }
    }
}
