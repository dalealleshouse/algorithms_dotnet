namespace Algorithms.Tests.ListDataStructures.Array
{
    using System;
    using Algorithms.ListDataStructures;
    using Xunit;

    public class InsertAtHead
    {
        [Fact]
        public void RejectNull()
        {
            var sut = new Array<object>();
            Assert.Throws<ArgumentNullException>(() => sut.InsertAtHead(null));

            var sut2 = new Array<int>();
            Assert.Throws<ArgumentNullException>(() => sut.InsertAtHead(null));
        }

        [Fact]
        public void InsertValueAtHeadOfArray()
        {
            var sut = new Array<int>();
            sut.InsertAtHead(1);
            sut.InsertAtHead(2);
            sut.InsertAtHead(3);

            Assert.Equal(3, sut[0]);
            Assert.Equal(2, sut[1]);
            Assert.Equal(1, sut[2]);
        }
    }
}
