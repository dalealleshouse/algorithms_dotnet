using System.Collections.Generic;

namespace Algorithms.MatrixOperations
{
    public class TransposeSquareMatrix<T> : SquareMatrix<T>
    {
        public TransposeSquareMatrix(BinaryOps<T> ops, IEnumerable<T> startingData)
            : base(ops, startingData)
        {
        }

        public TransposeSquareMatrix(int size, BinaryOps<T> ops) : base(size, ops)
        {
        }

        protected override SquareMatrix<T> Empty(int size) =>
            new TransposeSquareMatrix<T>(size, ops);

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
