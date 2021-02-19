namespace Algorithms.Tests.DataStructures.Heap
{
    using System;
    using Xunit;

    public class Peek
    {
        [Fact]
        public void ThorwForEmptyHeap()
        {
            var sut = SutFactory.MaxHeap(10);
            Assert.Throws<InvalidOperationException>(() => sut.Peek());
        }

        [Fact]
        public void RetursHighestPriorityFromMax()
        {
            var sut = SutFactory.MaxHeap(10);
            sut.Insert(5);
            sut.Insert(10);
            sut.Insert(20);

            Assert.Equal(20, sut.Peek());
        }

        [Fact]
        public void RetursHighestPriorityFromMin()
        {
            var sut = SutFactory.MinHeap(10);
            sut.Insert(5);
            sut.Insert(10);
            sut.Insert(20);

            Assert.Equal(5, sut.Peek());
        }
    }
}
