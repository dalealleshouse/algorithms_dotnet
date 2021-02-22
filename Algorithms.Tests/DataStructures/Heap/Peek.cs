using System;
using Xunit;

namespace Algorithms.Tests.DataStructures.Heap
{
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
            var sut = SutFactory.MaxHeap(10, new int[] { 5, 10, 20 });
            Assert.Equal(20, sut.Peek());
        }

        [Fact]
        public void RetursHighestPriorityFromMin()
        {
            var sut = SutFactory.MinHeap(10, new int[] { 5, 10, 20 });
            Assert.Equal(5, sut.Peek());
        }
    }
}
