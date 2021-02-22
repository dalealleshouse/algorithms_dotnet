using Algorithms.MatrixOperations;

namespace Algorithms.Tests
{
    public class TestMatrix : SquareMatrix<int>
    {
        public TestMatrix(uint size) : base(size)
        {
        }

        public TestMatrix(int[] startingData)
            : base(startingData)
        {
        }

        protected override SquareMatrix<int> Empty(uint size) =>
            new TestMatrix(size);

        protected override SquareMatrix<int> Multiply(SquareMatrix<int> b) => b;
    }


}
