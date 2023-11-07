namespace Algorithms.Tests.ListDataStructures.Array
{
    using System;
    using Algorithms.ListDataStructures;
    using Xunit;

    public class InsertAtTail
    {
        [Fact]
        public void RejectNull()
        {
            var sut = new Array<object>();
            Assert.Throws<ArgumentNullException>(() => sut.InsertAtTail(null));

            var sut2 = new Array<int>();
            Assert.Throws<ArgumentNullException>(() => sut.InsertAtTail(null));
        }

        [Fact]
        public void InsertValueAtTheTailOfArray()
        {
            var sut = new Array<int>();
            sut.InsertAtTail(1);
            sut.InsertAtTail(2);
            sut.InsertAtTail(3);

            Assert.Equal(1, sut[0]);
            Assert.Equal(2, sut[1]);
            Assert.Equal(3, sut[2]);
        }
    }
}
