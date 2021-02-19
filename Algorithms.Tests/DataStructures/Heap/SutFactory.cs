namespace Algorithms.Tests.DataStructures.Heap
{
    using Algorithms.DataStructures;

    public static class SutFactory
    {
        public static Heap<int> MaxHeap(uint size)
        {
            return new Heap<int>((x, y) => x - y, size);
        }

        public static Heap<int> MinHeap(uint size)
        {
            return new Heap<int>((x, y) => y - x, size);
        }
    }
}
