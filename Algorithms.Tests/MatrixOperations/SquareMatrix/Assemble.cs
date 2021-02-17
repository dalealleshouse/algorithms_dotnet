namespace Algorithms.Tests.MatrixOperations.SquareMatrix
{
    using System;
    using Xunit;

    public class Assemble
    {
        [Fact]
        public void Should_RejectNullValues()
        {
            TestMatrix q1 = null, q2 = null, q3 = null, q4 = null;
            var a = new TestMatrix(new int[] { 1, 2, 3, 4 });

            Assert.Throws<ArgumentNullException>(() =>
                    a.Assemble(q1, q2, q3, q4));
        }

        [Fact]
        public void Should_RejectDifferntSizes()
        {
            var q1 = new TestMatrix(new int[] { 1, 2, 3, 4 });
            var q2 = new TestMatrix(new int[] { 2 });
            var q3 = new TestMatrix(new int[] { 3 });
            var q4 = new TestMatrix(new int[] { 4 });

            Assert.Throws<ArgumentException>(() => q1.Assemble(q1, q2, q3, q4));
        }


        [Fact]
        public void Should_JoinSize2MatrixFromQuadrants()
        {
            var expected = new TestMatrix(new int[] { 1, 2, 3, 4 });
            var q1 = new TestMatrix(new int[] { 1 });
            var q2 = new TestMatrix(new int[] { 2 });
            var q3 = new TestMatrix(new int[] { 3 });
            var q4 = new TestMatrix(new int[] { 4 });

            var result = q1.Assemble(q1, q2, q3, q4);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Should_SplitSize4MatrixIntoQuadrants()
        {
            var expected = new TestMatrix(new int[] { 1, 2, 3, 4, 5, 6, 7, 8,
                    9, 10, 11, 12, 13, 14, 15, 16 });

            var q1 = new TestMatrix(new int[] { 1, 2, 5, 6 });
            var q2 = new TestMatrix(new int[] { 3, 4, 7, 8 });
            var q3 = new TestMatrix(new int[] { 9, 10, 13, 14 });
            var q4 = new TestMatrix(new int[] { 11, 12, 15, 16 });

            var result = q1.Assemble(q1, q2, q3, q4);

            Assert.Equal(expected, result);
        }
    }
}
