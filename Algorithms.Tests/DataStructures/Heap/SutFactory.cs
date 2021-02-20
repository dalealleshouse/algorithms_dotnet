namespace Algorithms.Tests.DataStructures.Heap
{
    using Algorithms.DataStructures;

    public static class SutFactory
    {
        public static Heap<int> MaxHeap(uint size)
        {
            return new Heap<int>((x, y) => x - y, size);
        }

        public static Heap<int> MaxHeap(uint size, int[] data)
        {
            var sut = MaxHeap(size);
            foreach (var i in data)
                sut.Insert(i);

            return sut;
        }

        public static Heap<int> MinHeap(uint size)
        {
            return new Heap<int>((x, y) => y - x, size);
        }

        public static Heap<int> MinHeap(uint size, int[] data)
        {
            var sut = MinHeap(size);
            foreach (var i in data)
                sut.Insert(i);

            return sut;
        }
    }
}
