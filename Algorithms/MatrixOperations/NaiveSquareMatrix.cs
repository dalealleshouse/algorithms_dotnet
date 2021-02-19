namespace Algorithms.MatrixOperations
{
    using System.Collections.Generic;

    public class NaiveSquareMatrix<T> : SquareMatrix<T>
    {
        public NaiveSquareMatrix(IEnumerable<T> startingData) : base(startingData)
        {
        }

        public NaiveSquareMatrix(uint size) : base(size)
        {
        }

        protected override SquareMatrix<T> Empty(uint size) =>
            new NaiveSquareMatrix<T>(size);

        protected override SquareMatrix<T> Multiply(SquareMatrix<T> b) =>
            this.NaiveMultiply(this, b);
    }
}
