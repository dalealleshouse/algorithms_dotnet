using System.Collections.Generic;

namespace Algorithms.MatrixOperations
{
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

        protected override SquareMatrix<T> Multiply(SquareMatrix<T> b)
        {
            var result = this.Empty();

            for (var i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    for (int k = 0; k < this.size; k++)
                    {
                        result[i, j] = this.ops.Add(
                                result[i, j],
                                this.ops.Multiply(this[i, k], b[k, j]));
                    }
                }
            }

            return result;
        }
    }
}
