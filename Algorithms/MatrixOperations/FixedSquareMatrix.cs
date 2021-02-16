namespace Algorithms.MatrixOperations
{
    using System;
    using System.Collections.Generic;

    public class FixedSquareMatrix : SquareMatrix<long>
    {
        private const int STOP_RECURSION_SIZE = 32;

        public FixedSquareMatrix(IBinaryOps<long> ops, IEnumerable<long> startingData)
            : base(ops, startingData)
        {
        }

        public FixedSquareMatrix(int size, IBinaryOps<long> ops)
            : base(size, ops)
        {
        }

        public FixedSquareMatrix(int size) : base(size, BinaryOps.Long)
        {
        }

        protected override SquareMatrix<long> Empty(int size) =>
            new FixedSquareMatrix(size, ops);

        protected override FixedSquareMatrix Multiply(SquareMatrix<long> b)
        {
            if (size <= STOP_RECURSION_SIZE)
            {
                var btype = (FixedSquareMatrix)b;
                var result = new FixedSquareMatrix(size);

                for (var i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        for (int k = 0; k < size; k++)
                        {
                            checked
                            {
                                result.data[i * size + j] +=
                                    this.data[i * size + k] *
                                    btype.data[k * size + j];
                            }
                        }

                return result;
            }

            SquareMatrix<long> a1, a2, a3, a4, b1, b2, b3, b4;
            (a1, a2, a3, a4) = this.Quarter();
            (b1, b2, b3, b4) = b.Quarter();


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

        public static FixedSquareMatrix operator +(FixedSquareMatrix a, FixedSquareMatrix b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentOutOfRangeException("matrices must be the same size");

            var result = (FixedSquareMatrix)a.Empty();
            var size = a.size;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    result.data[i * size + j] =
                            a.data[i * size + j] + b.data[i * size + j];
            return result;
        }

        public static FixedSquareMatrix operator -(FixedSquareMatrix a, FixedSquareMatrix b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a));
            if (b is null) throw new ArgumentNullException(nameof(b));
            if (a.size != b.size)
                throw new ArgumentOutOfRangeException("matrices must be the same size");

            var result = (FixedSquareMatrix)a.Empty();
            var size = a.size;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    result.data[i * size + j] =
                            a.data[i * size + j] - b.data[i * size + j];
            return result;
        }

    }
}
