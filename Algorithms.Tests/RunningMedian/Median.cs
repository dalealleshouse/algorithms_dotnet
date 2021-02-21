namespace Algorithms.Tests.RunningMedian
{
    using System;
    using Xunit;
    using Algorithms;

    public class Median
    {
        private static double AverageFunc(double x, double y)
        {
            return (x + y) / 2;
        }

        private static int MinPriorityFunc(double x, double y)
        {
            if (x == y) return 0;
            else if (y - x < 0) return -1;
            else return 1;
        }

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

        [Fact]
        public void HonorsSlidingWindow()
        {
            const uint n = 10;
            var vals = new double[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
            var expected = new double[] { 1.0, 1.5, 2.0, 2.5, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0 };
            var sut = new RunningMedian<double>(MinPriorityFunc, AverageFunc, 5);


            for (uint i = 0; i < n; i++)
            {
                sut.Track(vals[i]);
                Assert.Equal(expected[i], sut.Median());
            }
        }
    }
}
