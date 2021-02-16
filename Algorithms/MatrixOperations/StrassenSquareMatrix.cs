namespace Algorithms.MatrixOperations
{
    using System.Collections.Generic;

    public class StrassenSquareMatrix<T> : SquareMatrix<T>
    {
        private const int STOP_RECURSION_SIZE = 32;

        public StrassenSquareMatrix(IBinaryOps<T> ops, IEnumerable<T> startingData)
            : base(ops, startingData)
        {
        }

        public StrassenSquareMatrix(int size, IBinaryOps<T> ops) : base(size, ops)
        {
        }

        protected override SquareMatrix<T> Empty(int size) =>
            new StrassenSquareMatrix<T>(size, ops);

        protected override SquareMatrix<T> Multiply(SquareMatrix<T> b)
        {
            if (b.Size <= STOP_RECURSION_SIZE)
                return NaiveMultiply(this, b);

            SquareMatrix<T> a1, a2, a3, a4, b1, b2, b3, b4;
            (a1, a2, a3, a4) = this.Quarter();
            (b1, b2, b3, b4) = b.Quarter();

            var p1 = a1 * (b2 - b4);
            var p2 = (a1 + a2) * b4;
            var p3 = (a3 + a4) * b1;
            var p4 = a4 * (b3 - b1);
            var p5 = (a1 + a4) * (b1 + b4);
            var p6 = (a2 - a4) * (b3 + b4);
            var p7 = (a1 - a3) * (b1 + b2);

            return this.Assemble(
                    p5 + p4 - p2 + p6, p1 + p2,
                    p3 + p4, p1 + p5 - p3 - p7);
        }
    }
}
