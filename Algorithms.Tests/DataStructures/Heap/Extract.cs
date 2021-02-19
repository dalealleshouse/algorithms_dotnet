namespace Algorithms.Tests.DataStructures.Heap
{
    using System;
    using Xunit;

    public class Extract
    {
        [Fact]
        public void ThorwForEmptyHeap()
        {
            var sut = SutFactory.MaxHeap(10);
            Assert.Throws<InvalidOperationException>(() => sut.Extract());
        }

        [Fact]
        public void RetursHighestPriorityFromMax()
        {
            var sut = SutFactory.MaxHeap(10);
            sut.Insert(5);
            sut.Insert(10);
            sut.Insert(20);

            Assert.Equal(3U, sut.ItemCount);
            Assert.Equal(20, sut.Extract());

            Assert.Equal(2U, sut.ItemCount);
            Assert.Equal(10, sut.Extract());

            Assert.Equal(1U, sut.ItemCount);
            Assert.Equal(5, sut.Extract());

            Assert.Equal(0U, sut.ItemCount);
        }

        [Fact]
        public void RetursHighestPriorityFromMin()
        {
            var sut = SutFactory.MinHeap(10);
            sut.Insert(5);
            sut.Insert(10);
            sut.Insert(20);

            Assert.Equal(3U, sut.ItemCount);
            Assert.Equal(5, sut.Extract());

            Assert.Equal(2U, sut.ItemCount);
            Assert.Equal(10, sut.Extract());

            Assert.Equal(1U, sut.ItemCount);
            Assert.Equal(20, sut.Extract());

            Assert.Equal(0U, sut.ItemCount);
        }
    }
}
