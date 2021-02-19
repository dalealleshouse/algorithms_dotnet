namespace Algorithms.Tests.DataStructures.Heap
{
    using System;
    using Xunit;
    using Algorithms.DataStructures;

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
            var sut = SutFactory.MaxHeap(1);
            sut.Insert(5);
            sut.Insert(10);

            Assert.Equal(2U, sut.ItemCount);
        }

        [Fact]
        public void RejectsDuplicates()
        {
            var sut = SutFactory.MaxHeap(10);
            sut.Insert(5);
            sut.Insert(10);

            Assert.Throws<InvalidOperationException>(() => sut.Insert(5));
        }
    }
}
