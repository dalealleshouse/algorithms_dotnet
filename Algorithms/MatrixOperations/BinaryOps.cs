namespace Algorithms.MatrixOperations
{
    public class BinaryOps
    {
        public static readonly IBinaryOps<int> Int = new IntOps();
        public static readonly IBinaryOps<long> Long = new LongOps();

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


}
