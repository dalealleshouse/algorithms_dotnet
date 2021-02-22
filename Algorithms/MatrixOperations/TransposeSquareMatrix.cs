namespace Algorithms.MatrixOperations
{
    using System.Collections.Generic;

    public class TransposeSquareMatrix<T> : SquareMatrix<T>
    {
        public TransposeSquareMatrix(IEnumerable<T> startingData)
            : base(startingData)
        {
        }

        public TransposeSquareMatrix(uint size)
            : base(size)
        {
        }

        protected override SquareMatrix<T> Empty(uint size) =>
            new TransposeSquareMatrix<T>(size);

        protected override SquareMatrix<T> Multiply(SquareMatrix<T> b)
        {
            var t = b.Transpose();
            var result = this.Empty();

            for (var i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    for (int k = 0; k < this.size; k++)
                    {
                        result[i, j] = this.ops.Add(
                                result[i, j],
                                this.ops.Multiply(this[i, k], t[j, k]));
                    }
                }
            }

            return result;
        }
    }
}
