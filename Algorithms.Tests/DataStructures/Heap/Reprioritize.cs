namespace Algorithms.Tests.DataStructures.Heap
{
    using System;
    using Xunit;
    using Algorithms.DataStructures;

    public partial class Reprioritize
    {
        [Fact]
        public void ThrowIfArgumentNull()
        {
            var sut = new Heap<object>((x, y) => 1, 5);
            Assert.Throws<ArgumentNullException>(() => sut.Reprioritize(null));
        }

        [Fact]
        public void ThrowIfItemDoesNotExist()
        {
            var sut = SutFactory.MaxHeap(10);
            Assert.Throws<ArgumentException>(() => sut.Reprioritize(5));
        }

        [Fact]
        public void RecalculatesPriority()
        {
            var sut = new Heap<TestObject>(TestObject.MaxPriorityFunc, 5);
            var one = new TestObject(1);
            var two = new TestObject(2);
            var three = new TestObject(3);
            var four = new TestObject(4);
            var five = new TestObject(5);

            sut.Insert(one);
            sut.Insert(two);
            sut.Insert(three);
            sut.Insert(four);
            sut.Insert(five);

            Assert.Equal(five, sut.Peek());

            three.Value = 10;
            sut.Reprioritize(three);

            Assert.Equal(three, sut.Peek());
        }

        [Fact]
        public void RecalculatesDuplicatePriority()
        {
            var sut = new Heap<TestObject>(TestObject.MaxPriorityFunc, 5);
            var one = new TestObject(1);
            var two = new TestObject(2);
            var three = new TestObject(3);
            var four = new TestObject(4);
            var five = new TestObject(5);

            sut.Insert(one);
            sut.Insert(two);
            sut.Insert(three);
            sut.Insert(three);
            sut.Insert(three);
            sut.Insert(four);
            sut.Insert(five);

            Assert.Equal(five, sut.Peek());

            three.Value = 10;
            sut.Reprioritize(three);

            Assert.Equal(three, sut.Extract());
            Assert.Equal(three, sut.Extract());
            Assert.Equal(three, sut.Extract());
            Assert.Equal(five, sut.Extract());
            Assert.Equal(four, sut.Extract());
            Assert.Equal(two, sut.Extract());
            Assert.Equal(one, sut.Extract());
        }
    }
}
