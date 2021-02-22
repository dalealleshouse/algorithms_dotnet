using Algorithms;
using System;
using Xunit;

namespace Algorithms.Tests.RunningMedian
{
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
