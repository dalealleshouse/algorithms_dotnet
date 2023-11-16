namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using Xunit;

public class Insert
{
    [Fact]
    public void ThrowForNullInput()
    {
        SutFactory
            .AllLists<ComparableObject>()
            .ForEach(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Insert(null));
        });
    }
}
