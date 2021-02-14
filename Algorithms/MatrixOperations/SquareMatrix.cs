namespace Algorithms.MatrixOperations
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public abstract class SquareMatrix<T> where T : notnull
    {
        protected readonly int size;
        protected readonly BinaryOps<T> ops;
        protected T[] data;

        protected SquareMatrix(int size, BinaryOps<T> ops)
        {
            if (!this.IsPowerOfTwo(size))
            {
                throw new ArgumentOutOfRangeException(
                        "The size of a square matrix must be a power of 2");
            }

            this.size = size;
            this.ops = ops ?? throw new ArgumentNullException(nameof(ops));
            this.data = new T[(int)Math.Pow(size, 2)];
        }

        protected SquareMatrix(BinaryOps<T> ops, IEnumerable<T> startingData)
        {
            if (startingData is null)
            {
                throw new ArgumentNullException(nameof(startingData));
            }

            var length = startingData.Count();

            if (!this.IsPowerOfTwo(length))
            {
                throw new ArgumentOutOfRangeException(
                        "The size of a square matrix must be a power of 2");
            }

            size = (int)Math.Log2(length);
            this.data = new T[(int)Math.Pow(size, 2)];
            startingData.ToArray().CopyTo(this.data, 0);
            this.ops = ops ?? throw new ArgumentNullException(nameof(ops));
        }
        private bool IsPowerOfTwo(int x) { return (x & (x - 1)) == 0; }
        protected abstract SquareMatrix<T> Empty();

        public int Size => size;

        public static SquareMatrix<T> operator +(SquareMatrix<T> a, SquareMatrix<T> b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentOutOfRangeException("matrices must be the same size");

            var result = a.Empty();

            for (int i = 0; i < a.size; i++)
            {
                for (int j = 0; j < a.size; j++)
                {
                    result[i, j] = a.ops.Add(a[i, j], b[i, j]);
                }
            }
            return result;
        }

        public static SquareMatrix<T> operator -(SquareMatrix<T> a, SquareMatrix<T> b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentOutOfRangeException("matrices must be the same size");

            var result = a.Empty();

            for (int i = 0; i < a.size; i++)
            {
                for (int j = 0; j < a.size; j++)
                {
                    result[i, j] = a.ops.Subtract(a[i, j], b[i, j]);
                }
            }
            return result;
        }

        public static SquareMatrix<T> operator *(SquareMatrix<T> a, SquareMatrix<T> b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentOutOfRangeException("matrices must be the same size");

            var result = a.Empty();

            for (int i = 0; i < a.size; i++)
            {
                for (int j = 0; j < a.size; j++)
                {
                    for (int k = 0; k < a.size; k++)
                    {
                        result[i, j] = a.ops.Add(result[i, j], a.ops.Multiply(a[i, k], b[k, j]));
                    }
                }
            }
            return result;
        }


        public T this[int x, int y]
        {
            get => this.data[x * this.size + y];
            set => this.data[x * this.size + y] = value;
        }

        public override bool Equals(object obj)
        {
            return obj is SquareMatrix<T> matrix &&
                size == matrix.size &&
                Enumerable.SequenceEqual(data, matrix.data);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(size, data);
        }

        public override string ToString()
        {
            var matrix = new StringBuilder();

            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    matrix.Append(this[i, j].ToString());
                    matrix.Append("\t");
                }
                matrix.Append("\n");
            }

            return matrix.ToString();
        }
    }
}
