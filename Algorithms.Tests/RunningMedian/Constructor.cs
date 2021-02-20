namespace Algorithms.Tests.RunningMedian
{
    using System;
    using Xunit;
    using Algorithms;

    public class Constructor
    {
        [Fact]
        public void ThrowOnNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new RunningMedian<int>(null, null));
            Assert.Throws<ArgumentNullException>(() => new RunningMedian<int>((x, y) => -1, null));
            Assert.Throws<ArgumentNullException>(() => new RunningMedian<int>(null, (x, y) => -1));
        }
    }
}
