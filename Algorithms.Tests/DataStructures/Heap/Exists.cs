namespace Algorithms.Tests.DataStructures.Heap
{
    using System;
    using Xunit;
    using Algorithms.DataStructures;

    public class Exists
    {
        [Fact]
        public void RejectNull()
        {
            var sut = new Heap<object>((x, y) => -1, 10);
            Assert.Throws<ArgumentNullException>(() => sut.Exists(null));
        }

        [Fact]
        public void ReturnsTrueWhenItemExist()
        {
            var sut = SutFactory.MaxHeap(10);
            sut.Insert(5);
            sut.Insert(10);

            Assert.True(sut.Exists(5));
            Assert.True(sut.Exists(10));
        }

        [Fact]
        public void ReturnsFalseWhenItemDoesNotExist()
        {
            var sut = SutFactory.MaxHeap(10);
            sut.Insert(5);
            sut.Insert(10);

            Assert.False(sut.Exists(15));
            Assert.False(sut.Exists(100));
        }

        [Fact]
        public void ReturnsFalseAfterItemRemoved()
        {
            var sut = SutFactory.MaxHeap(10);
            sut.Insert(5);
            sut.Insert(10);

            Assert.True(sut.Exists(10));
            Assert.Equal(10, sut.Extract());
            Assert.False(sut.Exists(10));
        }
    }
}
