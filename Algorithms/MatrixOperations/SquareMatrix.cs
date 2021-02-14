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
            this.data = new T[size * size];
        }

        protected SquareMatrix(BinaryOps<T> ops, IEnumerable<T> startingData)
        {
            if (startingData is null)
            {
                throw new ArgumentNullException(nameof(startingData));
            }

            var length = startingData.Count();

            if (Math.Sqrt(length) % 1 != 0)
            {
                throw new ArgumentOutOfRangeException(
                        "The size of a square matrix must be a power of 2");
            }

            size = (length == 1) ? 1 : (int)Math.Log2(length);
            this.data = new T[length];
            startingData.ToArray().CopyTo(this.data, 0);
            this.ops = ops ?? throw new ArgumentNullException(nameof(ops));
        }

        private bool IsPowerOfTwo(int x) { return (x & (x - 1)) == 0; }
        protected SquareMatrix<T> Empty() => this.Empty(size);
        protected abstract SquareMatrix<T> Empty(int size);

        public int Size => size;

        public T this[int x, int y]
        {
            get => this.data[x * this.size + y];
            set => this.data[x * this.size + y] = value;
        }

        public SquareMatrix<T> Transpose()
        {
            var result = this.Empty();

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    result[j, i] = this[i, j];
                }
            }

            return result;
        }

        public (SquareMatrix<T>, SquareMatrix<T>, SquareMatrix<T>, SquareMatrix<T>)
            Quarter()
        {
            if (size < 2)
                throw new ArgumentOutOfRangeException("size must be greater than or equal to 2");

            int newSize = size / 2;

            var q1 = this.Empty(newSize);
            var q2 = this.Empty(newSize);
            var q3 = this.Empty(newSize);
            var q4 = this.Empty(newSize);

            for (var i = 0; i < newSize; i++)
            {
                for (var j = 0; j < newSize; j++)
                {
                    q1[i, j] = this[i, j];
                    q2[i, j] = this[i, newSize + j];
                    q3[i, j] = this[newSize + i, j];
                    q4[i, j] = this[newSize + i, newSize + j];
                }
            }

            return (q1, q2, q3, q4);
        }

        public SquareMatrix<T> Assemble(SquareMatrix<T> q1, SquareMatrix<T> q2, 
                SquareMatrix<T> q3, SquareMatrix<T> q4)
        {
            if (q1 is null) throw new ArgumentNullException(nameof(q1));
            if (q2 is null) throw new ArgumentNullException(nameof(q2));
            if (q3 is null) throw new ArgumentNullException(nameof(q3));
            if (q4 is null) throw new ArgumentNullException(nameof(q4));

            int newSize = size * 2;

            var result = this.Empty(newSize);

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    result[i, j] = q1[i, j];
                    result[i, size + j] = q2[i, j];
                    result[size + i, j] = q3[i, j];
                    result[size + i, size + j] = q4[i, j];
                }
            }

            return result;
        }

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

        protected abstract SquareMatrix<T> Multiply(SquareMatrix<T> b);

        public static SquareMatrix<T> operator *(SquareMatrix<T> a, SquareMatrix<T> b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentOutOfRangeException("matrices must be the same size");

            return a.Multiply(b);
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
