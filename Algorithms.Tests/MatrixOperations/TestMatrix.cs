namespace Algorithms.Tests
{
    using Algorithms.MatrixOperations;

    public class TestMatrix : SquareMatrix<int>
    {
        public TestMatrix(int size, IBinaryOps<int> ops)
            : base(size, ops)
        {
        }

        public TestMatrix(int size) : base(size, BinaryOps.Int)
        {
        }

        public TestMatrix(IBinaryOps<int> ops, int[] startingData)
            : base(ops, startingData)
        {
        }

        public TestMatrix(int[] startingData)
            : base(BinaryOps.Int, startingData)
        {
        }

        protected override SquareMatrix<int> Empty(int size) => 
            new TestMatrix(size, ops);

        protected override SquareMatrix<int> Multiply(SquareMatrix<int> b) => b;
    }


}
