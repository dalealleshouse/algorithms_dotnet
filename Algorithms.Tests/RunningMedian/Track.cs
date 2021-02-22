using Algorithms;
using System;
using Xunit;

namespace Algorithms.Tests.RunningMedian
{
    public class Track
    {
        [Fact]
        public void RejectsNullValues()
        {
            var sut = new RunningMedian<object>((x, y) => -1, (x, y) => x);
            Assert.Throws<ArgumentNullException>(() => sut.Track(null));
        }

        [Fact]
        public void IncrementsItemCount()
        {
            var sut = SutFactory.Create();

            Assert.Equal(0U, sut.ItemCount);

            var values = new uint[] { 1U, 2U, 3U, 4U, 5U };
            foreach (var x in values)
            {
                sut.Track((int)x);
                Assert.Equal(x, sut.ItemCount);
            }
        }
    }
}
