namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using Xunit;

public class Insert : ListTests
{
    [Fact]
    public void ThrowForNullInput()
    {
        this.RunTestOnAllLists<ComparableObject>(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Insert(null));
        });
    }
}
