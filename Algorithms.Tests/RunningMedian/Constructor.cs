namespace Algorithms.Tests.RunningMedian
{
    using System;
    using Algorithms;
    using Xunit;

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
