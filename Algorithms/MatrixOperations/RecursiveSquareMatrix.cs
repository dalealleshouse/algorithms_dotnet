namespace Algorithms.MatrixOperations
{
    using System.Collections.Generic;

    public class RecursiveSquareMatrix<T> : SquareMatrix<T>
    {
        private const int STOP_RECURSION_SIZE = 16;

        public RecursiveSquareMatrix(BinaryOps<T> ops, IEnumerable<T> startingData)
            : base(ops, startingData)
        {
        }

        public RecursiveSquareMatrix(int size, BinaryOps<T> ops) : base(size, ops)
        {
        }

        protected override SquareMatrix<T> Empty(int size) =>
            new RecursiveSquareMatrix<T>(size, ops);

        protected override SquareMatrix<T> Multiply(SquareMatrix<T> b)
        {
            if (b.Size <= STOP_RECURSION_SIZE)
                return NaiveMultiply(this, b);

            SquareMatrix<T> a1, a2, a3, a4, b1, b2, b3, b4;
            (a1, a2, a3, a4) = this.Quarter();
            (b1, b2, b3, b4) = b.Quarter();

            return this.Assemble(
                    (a1 * b1) + (a2 * b3),
                    (a1 * b2) + (a2 * b4),
                    (a3 * b1) + (a4 * b3),
                    (a3 * b2) + (a4 * b4));
        }
    }
}
