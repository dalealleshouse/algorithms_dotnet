namespace Algorithms.Tests.DataStructures.Heap
{
    using System;
    using Xunit;
    using Algorithms.DataStructures;

    public class Constructor
    {
        [Fact]
        public void RejectNullPriorityFunction()
        {
            Assert.Throws<ArgumentNullException>(() => new Heap<int>(null, 5));
        }

        [Fact]
        public void RejectZeroSize()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Heap<int>((int x, int y) => 1, 0));
        }

        [Fact]
        public void SetsItemCount()
        {
            var sut = SutFactory.MaxHeap(1);
            Assert.Equal(0U, sut.ItemCount);
        }
    }
}
