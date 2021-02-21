namespace Algorithms.Tests.DataStructures.Heap
{
    using Algorithms.DataStructures;
    using System;
    using Xunit;

    public class Insert
    {
        [Fact]
        public void RejectNull()
        {
            var sut = new Heap<object>((x, y) => -1, 10);
            Assert.Throws<ArgumentNullException>(() => sut.Insert(null));
        }

        [Fact]
        public void AutoResize()
        {
            var sut = SutFactory.MaxHeap(1, new int[] { 5, 10 });

            Assert.Equal(2U, sut.ItemCount);
        }

        [Fact]
        public void AcceptsDuplicates()
        {
            var sut = SutFactory.MaxHeap(1, new int[] { 5, 10, 5 });

            Assert.Equal(3U, sut.ItemCount);
        }
    }
}
