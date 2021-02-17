namespace Algorithms.Tests
{
    using Algorithms.MatrixOperations;

    public class TestMatrix : SquareMatrix<int>
    {
        public TestMatrix(int size) : base(size)
        {
        }

        public TestMatrix(int[] startingData)
            : base(startingData)
        {
        }

        protected override SquareMatrix<int> Empty(int size) =>
            new TestMatrix(size);

        protected override SquareMatrix<int> Multiply(SquareMatrix<int> b) => b;
    }


}
