namespace Algorithms.Tests.DataStructures.Heap
{
    using System;
    using Xunit;
    using Algorithms.DataStructures;

    public class Delete
    {
        [Fact]
        public void RejectNull()
        {
            var sut = new Heap<object>((x, y) => -1, 10);
            Assert.Throws<ArgumentNullException>(() => sut.Delete(null));
        }

        [Fact]
        public void ThorwIfItemDoesNotExist()
        {
            var sut = SutFactory.MaxHeap(10);
            sut.Insert(5);
            sut.Insert(10);

            Assert.Throws<ArgumentException>(() => sut.Delete(15));
        }

        [Fact]
        public void Reprioritizes()
        {
            var sut = SutFactory.MaxHeap(10);
            sut.Insert(25);
            sut.Insert(5);
            sut.Insert(15);
            sut.Insert(10);
            sut.Insert(20);

            sut.Delete(25);
            Assert.Equal(20, sut.Peek());
        }

        [Fact]
        public void DecrementsItemCount()
        {
            var sut = SutFactory.MaxHeap(10);
            sut.Insert(25);
            sut.Insert(5);
            sut.Insert(15);
            sut.Insert(10);
            sut.Insert(20);

            Assert.Equal(5U, sut.ItemCount);
            sut.Delete(5);
            Assert.Equal(4U, sut.ItemCount);
        }
    }
}
