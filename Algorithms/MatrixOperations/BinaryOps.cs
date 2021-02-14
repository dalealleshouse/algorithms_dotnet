namespace Algorithms.MatrixOperations
{
    using System;

    public class BinaryOps<T>
    {
        public BinaryOps(Func<T, T, T> add, Func<T, T, T> subtract,
                Func<T, T, T> multiply)
        {
            Add = (x, y) => add(x, y) ?? throw new ArgumentNullException(nameof(add));
            Subtract = subtract ?? throw new ArgumentNullException(nameof(subtract));
            Multiply = multiply ?? throw new ArgumentNullException(nameof(multiply));
        }

        public Func<T, T, T> Add { get; }
        public Func<T, T, T> Subtract { get; }
        public Func<T, T, T> Multiply { get; }

        public static BinaryOps<int> Int()
        {
            return new BinaryOps<int>(
                    (x, y) => checked(x + y),
                    (x, y) => checked(x - y),
                    (x, y) => checked(x * y));
        }

        public static BinaryOps<decimal> Decimal()
        {
            return new BinaryOps<decimal>(
                    (x, y) => checked(x + y),
                    (x, y) => checked(x - y),
                    (x, y) => checked(x * y));
        }

        public static BinaryOps<double> Double()
        {
            return new BinaryOps<double>(
                    (x, y) => checked(x + y),
                    (x, y) => checked(x - y),
                    (x, y) => checked(x * y));
        }

        public static BinaryOps<float> Float()
        {
            return new BinaryOps<float>(
                    (x, y) => checked(x + y),
                    (x, y) => checked(x - y),
                    (x, y) => checked(x * y));
        }

        // TODO: Add many more...
    }
}
