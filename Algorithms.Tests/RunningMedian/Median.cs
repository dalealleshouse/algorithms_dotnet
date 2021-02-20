namespace Algorithms.Tests.RunningMedian
{
    using System;
    using Xunit;

    public class Median
    {
        [Fact]
        public void ThrowsWhenEmpty()
        {
            var sut = SutFactory.Create();
            Assert.Throws<InvalidOperationException>(() => sut.Median());
        }

        [Fact]
        public void ReturnsMedianWithOnlyOneNumber()
        {
            var sut = SutFactory.Create();
            sut.Track(1);

            Assert.Equal(1, sut.Median());
        }

        [Fact]
        public void ReturnsAverageOfTwoNumbers()
        {
            var sut = SutFactory.Create();
            sut.Track(1);
            sut.Track(10);

            Assert.Equal(5, sut.Median());
        }

        [Fact]
        public void ReturnsMidOfThreeNumbers()
        {
            var sut = SutFactory.Create();
            sut.Track(10);
            sut.Track(5);
            sut.Track(15);

            Assert.Equal(10, sut.Median());
        }

        [Fact]
        public void ReturnsAverageOfMiddleTwo()
        {
            var sut = SutFactory.Create();
            sut.Track(10);
            sut.Track(5);
            sut.Track(15);
            sut.Track(20);

            Assert.Equal(12, sut.Median());
        }
    }
}
