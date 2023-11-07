namespace Algorithms.Tests.ListDataStructures.Array
{
    using System;
    using Algorithms.ListDataStructures;
    using Xunit;

    public class Enumerate
    {
        [Fact]
        public void RejectNull()
        {
            var sut = new Array<object>();
            Assert.Throws<ArgumentNullException>(() => sut.Enumerate(null));

            var sut2 = new Array<int>();
            Assert.Throws<ArgumentNullException>(() => sut.Enumerate(null));
        }

        [Fact]
        public void InvokeAnActionForEachItem()
        {
            const int max = 10;
            var sut = SutFactory.IntArray(max);

            var expected = 0;
            sut.Enumerate(x =>
            {
                Assert.Equal(expected++, x);
            });
        }

        [Fact]
        public void DoesNotFailOnEmptyArray()
        {
            var sut = new Array<int>();

            sut.Enumerate(x => Assert.True(false, "Should not be called"));
        }
    }
}
