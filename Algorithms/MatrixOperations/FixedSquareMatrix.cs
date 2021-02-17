namespace Algorithms.MatrixOperations
{
    using System;
    using System.Collections.Generic;

    // This implementation is optimized for performance:
    // - Does not use BinaryOps to eliminate function calls
    // - Does not use the indexer
    public class FixedSquareMatrix : SquareMatrix<long>
    {
        private const int STOP_RECURSION_SIZE = 32;

        public FixedSquareMatrix(IEnumerable<long> startingData) : base(startingData)
        {
        }

        public FixedSquareMatrix(int size) : base(size, null)
        {
        }

        protected override FixedSquareMatrix Empty(int size) =>
            new FixedSquareMatrix(size);

        protected (FixedSquareMatrix, FixedSquareMatrix, FixedSquareMatrix,
            FixedSquareMatrix) TypedQuarter()
        {
            return ((FixedSquareMatrix, FixedSquareMatrix,
                  FixedSquareMatrix, FixedSquareMatrix))this.Quarter();
        }

        protected override FixedSquareMatrix Multiply(SquareMatrix<long> b)
        {
            if (size <= STOP_RECURSION_SIZE)
                return FastNaiveMultiply(this, (FixedSquareMatrix)b);

            var btype = (FixedSquareMatrix)b;

            FixedSquareMatrix a1, a2, a3, a4, b1, b2, b3, b4;
            (a1, a2, a3, a4) = this.TypedQuarter();
            (b1, b2, b3, b4) = btype.TypedQuarter();

            var p1 = a1 * (b2 - b4);
            var p2 = (a1 + a2) * b4;
            var p3 = (a3 + a4) * b1;
            var p4 = a4 * (b3 - b1);
            var p5 = (a1 + a4) * (b1 + b4);
            var p6 = (a2 - a4) * (b3 + b4);
            var p7 = (a1 - a3) * (b1 + b2);


            return (FixedSquareMatrix)this.Assemble(
                                p5 + p4 - p2 + p6, p1 + p2,
                                p3 + p4, p1 + p5 - p3 - p7);
        }

        private static FixedSquareMatrix FastNaiveMultiply(FixedSquareMatrix a,
                FixedSquareMatrix b)
        {
            var size = a.size;
            var result = new FixedSquareMatrix(size);

            for (var i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    for (int k = 0; k < size; k++)
                    {
                        checked
                        {
                            result.data[i * size + j] +=
                                a.data[i * size + k] * b.data[k * size + j];
                        }
                    }

            return result;
        }

        public static FixedSquareMatrix operator +(FixedSquareMatrix a,
            FixedSquareMatrix b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentException("matrices must be the same size");

            var size = a.size;
            var result = new FixedSquareMatrix(size);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    checked
                    {
                        result.data[i * size + j] =
                            a.data[i * size + j] + b.data[i * size + j];
                    }
                }
            return result;
        }

        public static FixedSquareMatrix operator -(FixedSquareMatrix a,
            FixedSquareMatrix b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentException("matrices must be the same size");

            var result = (FixedSquareMatrix)a.Empty();
            var size = a.size;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    checked
                    {
                        result.data[i * size + j] =
                            a.data[i * size + j] - b.data[i * size + j];
                    }
                }
            return result;
        }

        public static FixedSquareMatrix operator *(FixedSquareMatrix a,
            FixedSquareMatrix b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentException("matrices must be the same size");

            return a.Multiply(b);
        }
    }
}
