namespace Algorithms.Tests
{
    using Algorithms.MatrixOperations;

    public class TestMatrix : SquareMatrix<int>
    {
        public TestMatrix(int size, BinaryOps<int> ops)
            : base(size, ops)
        {
        }

        public TestMatrix(int size)
            : base(size, new BinaryOps<int>(
                        (x, y) => checked(x + y), (x, y) => checked(x - y),
                        (x, y) => checked(x * y)))
        {
        }

        public TestMatrix(BinaryOps<int> ops, int[] startingData)
            : base(ops, startingData)
        {
        }

        public TestMatrix(int[] startingData)
            : base(new BinaryOps<int>(
                        (x, y) => checked(x + y), (x, y) => checked(x - y),
                        (x, y) => checked(x * y)),
                    startingData)
        {
        }

        protected override SquareMatrix<int> Empty()
        {
            return new TestMatrix(size, ops);
        }
    }


}
