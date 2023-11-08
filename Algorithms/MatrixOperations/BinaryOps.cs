namespace Algorithms.MatrixOperations;

using System;

public class BinaryOps
{
    public static readonly IBinaryOps<int> Int = new IntOps();
    public static readonly IBinaryOps<long> Long = new LongOps();

    public static IBinaryOps<T> Factory<T>()
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.Int32:
                return (IBinaryOps<T>)Int;
            case TypeCode.Int64:
                return (IBinaryOps<T>)Long;
            default:
                throw new System.NotImplementedException();
        }
    }

    // TODO: Add many more...
    private class IntOps : IBinaryOps<int>
    {
        public int Add(int x, int y) => checked(x + y);

        public int Multiply(int x, int y) => checked(x * y);

        public int Subtract(int x, int y) => checked(x - y);
    }

    private class LongOps : IBinaryOps<long>
    {
        public long Add(long x, long y) => checked(x + y);

        public long Multiply(long x, long y) => checked(x * y);

        public long Subtract(long x, long y) => checked(x - y);
    }
}
