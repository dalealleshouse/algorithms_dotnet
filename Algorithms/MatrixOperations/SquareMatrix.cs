namespace Algorithms.MatrixOperations
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    // WARNING: Avoid using the indexer inside this class to improve performance
    public abstract class SquareMatrix<T> where T : notnull
    {
        protected readonly int size;
        protected readonly IBinaryOps<T> ops;
        protected T[] data;

        protected SquareMatrix(int size, IBinaryOps<T> ops)
        {
            if (!this.IsPowerOfTwo(size))
                throw new ArgumentOutOfRangeException(
                        $"The size of a square matrix must be a power of 2: you passed in {size}");
            this.ops = ops ?? throw new ArgumentNullException(nameof(ops));

            this.size = size;
            this.data = new T[size * size];
        }

        protected SquareMatrix(IBinaryOps<T> ops, IEnumerable<T> startingData)
        {
            if (startingData is null)
                throw new ArgumentNullException(nameof(startingData));
            this.ops = ops ?? throw new ArgumentNullException(nameof(ops));

            var length = startingData.Count();

            if (Math.Sqrt(length) % 1 != 0 || !this.IsPowerOfTwo(length))
                throw new ArgumentOutOfRangeException(
                        $"The size of a square matrix must be a power of 2: you sent an array of {length}");


            size = (int)Math.Sqrt(length);
            this.data = new T[length];
            startingData.ToArray().CopyTo(this.data, 0);
        }

        //**********************************************************************
        // Private
        //**********************************************************************
        private bool IsPowerOfTwo(int x) { return (x & (x - 1)) == 0; }

        //**********************************************************************
        // Abstract
        //**********************************************************************
        protected abstract SquareMatrix<T> Empty(int size);
        protected abstract SquareMatrix<T> Multiply(SquareMatrix<T> b);

        //**********************************************************************
        // Protected
        //**********************************************************************
        protected SquareMatrix<T> Empty() => this.Empty(size);

        // This is used by many of the algorithms
        protected SquareMatrix<T> NaiveMultiply(SquareMatrix<T> a, SquareMatrix<T> b)
        {
            var result = this.Empty(a.Size);

            for (var i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    for (int k = 0; k < this.size; k++)
                    {
                        /* result[i, j] = this.ops.Add(result[i, j], */
                        /*         this.ops.Multiply(this[i, k], b[k, j])); */
                        result.data[i * size + j] = this.ops.Add(
                                result.data[i * size + j],
                                this.ops.Multiply(this.data[i * size + k],
                                    b.data[k * size + j]));
                    }
                }
            }

            return result;
        }

        //**********************************************************************
        // Public
        //**********************************************************************
        public int Size => size;
        public T[] Data => data;

        public SquareMatrix<T> Transpose()
        {
            var result = this.Empty();

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    result.data[j * size + i] = this.data[i * size + j];
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
                    q1.data[i * newSize + j] = this.data[i * size + j];
                    q2.data[i * newSize + j] = this.data[i * size + newSize + j];
                    q3.data[i * newSize + j] = this.data[(newSize + i) * size + j];
                    q4.data[i * newSize + j] = this.data[(newSize + i) * size + newSize + j];
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
            if (q1.size != q2.size || q2.size != q3.size || q3.size != q4.size)
                throw new ArgumentOutOfRangeException("All matracies must  be the same size");

            int size = q1.size;
            int newSize = q1.size * 2;
            var result = this.Empty(newSize);

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    result.data[i * newSize + j] = q1.data[i * size + j];
                    result.data[i * newSize + size + j] = q2.data[i * size + j];
                    result.data[(size + i) * newSize + j] = q3.data[i * size + j];
                    result.data[(q1.size + i) * newSize + size + j] = q4.data[i * size + j];
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is SquareMatrix<T> matrix &&
                size == matrix.size &&
                Enumerable.SequenceEqual(data, matrix.data);
        }

        public override int GetHashCode() => HashCode.Combine(size, data);

        public override string ToString()
        {
            var matrix = new StringBuilder("\n");

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

        //**********************************************************************
        // Operators
        //**********************************************************************
        public T this[int x, int y]
        {
            get => this.data[x * this.size + y];
            set => this.data[x * this.size + y] = value;
        }

        public static SquareMatrix<T> operator +(SquareMatrix<T> a, SquareMatrix<T> b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentOutOfRangeException("matrices must be the same size");

            var result = a.Empty();
            var size = a.size;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result.data[i * size + j] = a.ops.Add(
                            a.data[i * size + j], b.data[i * size + j]);
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
            var size = a.size;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result.data[i * size + j] = a.ops.Subtract(
                            a.data[i * size + j], b.data[i * size + j]);
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

            return a.Multiply(b);
        }
    }
}
