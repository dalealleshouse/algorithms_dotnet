namespace Algorithms.Tests
{
    using Algorithms.MatrixOperations;

    public class TestMatrix : SquareMatrix<int>
    {
        public TestMatrix(int size, BinaryOps<int> ops)
            : base(size, ops)
        {
        }

        public TestMatrix(int size) : base(size, BinaryOps<int>.Int())
        {
        }

        public TestMatrix(BinaryOps<int> ops, int[] startingData)
            : base(ops, startingData)
        {
        }

        public TestMatrix(int[] startingData)
            : base(BinaryOps<int>.Int(), startingData)
        {
        }

        protected override SquareMatrix<int> Empty(int size) => 
            new TestMatrix(size, ops);

        protected override SquareMatrix<int> Multiply(SquareMatrix<int> b) => b;
    }


}
