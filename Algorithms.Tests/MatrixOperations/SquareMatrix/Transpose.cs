namespace Algorithms.Tests.MatrixOperations.SquareMatrix
{
    using Xunit;

    public class Transpose
    {
        [Fact]
        public void Should_transpose()
        {
            var expected = new TestMatrix(new int[] { 4, 3, 0, 4 });
            var a = new TestMatrix(new int[] { 4, 0, 3, 4 });

            var result = a.Transpose();
            Assert.Equal(expected, result);
        }
    }
}
