namespace Algorithms.MatrixOperations
{
    public interface IBinaryOps<T>
    {
        T Add(T x, T y);

        T Subtract(T x, T y);

        T Multiply(T x, T y);
    }
}
