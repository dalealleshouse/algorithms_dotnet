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
    }
}
