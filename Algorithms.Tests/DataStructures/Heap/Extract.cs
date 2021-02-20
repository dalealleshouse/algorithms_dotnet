namespace Algorithms.Tests.DataStructures.Heap
{
    using System;
    using Xunit;
    using Algorithms.DataStructures;

    public class Extract
    {
        private void ExtractTester<T>(Heap<T> sut, T[] expected)
        {
            var n = expected.Length;
            for (var i = 0; i < n; i++)
            {
                Assert.Equal((uint)(n - i), sut.ItemCount);
                Assert.Equal(expected[i], sut.Extract());
            }

            Assert.Equal(0U, sut.ItemCount);
        }

        [Fact]
        public void ThorwForEmptyHeap()
        {
            var sut = SutFactory.MaxHeap(10);
            Assert.Throws<InvalidOperationException>(() => sut.Extract());
        }

        [Fact]
        public void RetursHighestPriorityFromMax()
        {
            var sut = SutFactory.MaxHeap(10, new int[] { 5, 10, 20 });
            ExtractTester(sut, new int[] { 20, 10, 5 });
        }

        [Fact]
        public void RetursHighestPriorityFromMin()
        {
            var sut = SutFactory.MinHeap(10, new int[] { 5, 10, 20 });
            ExtractTester(sut, new int[] { 5, 10, 20 });
        }

        [Fact]
        public void RetursHighestPriorityGivenDuplicates()
        {
            var sut = SutFactory.MinHeap(10, new int[] { 3, 5, 10, 20, 5, 5, 5 });
            ExtractTester(sut, new int[] { 3, 5, 5, 5, 5, 10, 20 });
        }

        [Fact]
        public void RetursHighestPriorityGivenDuplicateObjects()
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

            ExtractTester(sut, new TestObject[] { five, four, three, three, three, two, one });
        }
    }
}
