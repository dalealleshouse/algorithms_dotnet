#nullable disable

namespace Algorithms.MatrixOperations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// WARNING: Avoid using the indexer inside this class to improve performance
public abstract class SquareMatrix<T>
    where T : notnull
{
#pragma warning disable SA1401 // Fields should be private, disabled for performance
    protected readonly uint size;
    protected readonly IBinaryOps<T> ops;
    protected T[] data;
#pragma warning restore SA1401 // Fields should be private

    protected SquareMatrix(uint size, IBinaryOps<T> ops)
    {
        this.ops = ops;
        if (!IsPowerOfTwo(size))
        {
            throw new ArgumentOutOfRangeException(
                nameof(size),
                $"The size of a square matrix must be a power of 2: you passed in {size}");
        }

        this.size = size;
        this.data = new T[size * size];
    }

    protected SquareMatrix(uint size)
    {
        this.ops = BinaryOps.Factory<T>();
        if (!IsPowerOfTwo(size))
        {
            throw new ArgumentOutOfRangeException(
                nameof(size),
                $"The size of a square matrix must be a power of 2: you passed in {size}");
        }

        this.size = size;
        this.data = new T[size * size];
    }

    protected SquareMatrix(IEnumerable<T> startingData)
    {
        this.ops = BinaryOps.Factory<T>();
        if (startingData is null)
        {
            throw new ArgumentNullException(nameof(startingData));
        }

        var length = startingData.Count();

        if (Math.Sqrt(length) % 1 != 0 || !IsPowerOfTwo((uint)length))
        {
            throw new ArgumentOutOfRangeException(
                nameof(startingData),
                $"The size of a square matrix must be a power of 2: you sent an array of {length}");
        }

        this.size = (uint)Math.Sqrt(length);
        this.data = new T[length];
        startingData.ToArray().CopyTo(this.data, 0);
    }

    public uint Size => this.size;

    public T[] Data => this.data;

    public T this[int x, int y]
    {
        get => this.data[(x * this.size) + y];
        set => this.data[(x * this.size) + y] = value;
    }

    public static SquareMatrix<T> operator +(SquareMatrix<T> a, SquareMatrix<T> b)
    {
        if (a is null)
        {
            throw new ArgumentNullException(nameof(a));
        }

        if (b is null)
        {
            throw new ArgumentNullException(nameof(b));
        }

        if (a.size != b.size)
        {
            throw new ArgumentException("matrices must be the same size");
        }

        var result = a.Empty();
        var size = a.size;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                result.data[(i * size) + j] = a.ops.Add(
                        a.data[(i * size) + j], b.data[(i * size) + j]);
            }
        }

        return result;
    }

    public static SquareMatrix<T> operator -(SquareMatrix<T> a, SquareMatrix<T> b)
    {
        if (a is null)
        {
            throw new ArgumentNullException(nameof(a));
        }

        if (b is null)
        {
            throw new ArgumentNullException(nameof(b));
        }

        if (a.size != b.size)
        {
            throw new ArgumentException("matrices must be the same size");
        }

        var result = a.Empty();
        var size = a.size;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                result.data[(i * size) + j] = a.ops.Subtract(
                        a.data[(i * size) + j], b.data[(i * size) + j]);
            }
        }

        return result;
    }

    public static SquareMatrix<T> operator *(SquareMatrix<T> a, SquareMatrix<T> b)
    {
        if (a is null)
        {
            throw new ArgumentNullException(nameof(a));
        }

        if (b is null)
        {
            throw new ArgumentNullException(nameof(b));
        }

        if (a.size != b.size)
        {
            throw new ArgumentException("matrices must be the same size");
        }

        return a.Multiply(b);
    }

    public SquareMatrix<T> Transpose()
    {
        var result = this.Empty();

        for (var i = 0; i < this.size; i++)
        {
            for (var j = 0; j < this.size; j++)
            {
                result.data[(j * this.size) + i] = this.data[(i * this.size) + j];
            }
        }

        return result;
    }

    public (SquareMatrix<T> QuadA, SquareMatrix<T> QuadB, SquareMatrix<T> QuadC, SquareMatrix<T> QuadD) Quarter()
    {
        if (this.size < 2)
        {
            throw new ArgumentOutOfRangeException(nameof(this.size), "size must be greater than or equal to 2");
        }

        uint newSize = this.size / 2;

        var q1 = this.Empty(newSize);
        var q2 = this.Empty(newSize);
        var q3 = this.Empty(newSize);
        var q4 = this.Empty(newSize);

        for (var i = 0; i < newSize; i++)
        {
            for (var j = 0; j < newSize; j++)
            {
                q1.data[(i * newSize) + j] = this.data[(i * this.size) + j];
                q2.data[(i * newSize) + j] = this.data[(i * this.size) + newSize + j];
                q3.data[(i * newSize) + j] = this.data[((newSize + i) * this.size) + j];
                q4.data[(i * newSize) + j] = this.data[((newSize + i) * this.size) + newSize + j];
            }
        }

        return (q1, q2, q3, q4);
    }

    public SquareMatrix<T> Assemble(SquareMatrix<T> q1, SquareMatrix<T> q2, SquareMatrix<T> q3, SquareMatrix<T> q4)
    {
        if (q1 is null)
        {
            throw new ArgumentNullException(nameof(q1));
        }

        if (q2 is null)
        {
            throw new ArgumentNullException(nameof(q2));
        }

        if (q3 is null)
        {
            throw new ArgumentNullException(nameof(q3));
        }

        if (q4 is null)
        {
            throw new ArgumentNullException(nameof(q4));
        }

        if (q1.size != q2.size || q2.size != q3.size || q3.size != q4.size)
        {
            throw new ArgumentException("All matrices must  be the same size");
        }

        uint size = q1.size;
        uint newSize = q1.size * 2;
        var result = this.Empty(newSize);

        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                result.data[(i * newSize) + j] = q1.data[(i * size) + j];
                result.data[(i * newSize) + size + j] = q2.data[(i * size) + j];
                result.data[((size + i) * newSize) + j] = q3.data[(i * size) + j];
                result.data[((q1.size + i) * newSize) + size + j] = q4.data[(i * size) + j];
            }
        }

        return result;
    }

    public override bool Equals(object obj)
    {
        return obj is SquareMatrix<T> matrix &&
            this.size == matrix.size &&
            Enumerable.SequenceEqual(this.data, matrix.data);
    }

    public override int GetHashCode() => HashCode.Combine(this.size, this.data);

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

    protected abstract SquareMatrix<T> Empty(uint size);

    protected abstract SquareMatrix<T> Multiply(SquareMatrix<T> b);

    protected SquareMatrix<T> Empty() => this.Empty(this.size);

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
                    ref T val = ref result.data[(i * this.size) + j];
                    val = this.ops.Add(val, this.ops.Multiply(
                        this.data[(i * this.size) + k],
                        b.data[(k * this.size) + j]));
                }
            }
        }

        return result;
    }

    private static bool IsPowerOfTwo(uint x)
    {
        return (x & (x - 1)) == 0;
    }
}
