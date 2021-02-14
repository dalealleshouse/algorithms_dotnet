namespace Algorithms.MatrixOperations
{
    using System.Collections.Generic;

    public class NaiveSquareMatrix<T> : SquareMatrix<T>
    {
        public NaiveSquareMatrix(BinaryOps<T> ops, IEnumerable<T> startingData)
            : base(ops, startingData)
        {
        }

        public NaiveSquareMatrix(int size, BinaryOps<T> ops) : base(size, ops)
        {
        }

        protected override SquareMatrix<T> Empty(int size) =>
            new NaiveSquareMatrix<T>(size, ops);

        protected override SquareMatrix<T> Multiply(SquareMatrix<T> b) =>
            this.NaiveMultiply(this, b);
    }
}
