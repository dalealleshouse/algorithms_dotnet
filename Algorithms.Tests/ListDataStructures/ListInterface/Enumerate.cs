namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using Xunit;

public class Enumerate
{
    [Fact]
    public void RejectNull()
    {
        SutFactory
            .AllLists<ComparableStruct>()
            .ForEach(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Enumerate(null));
        });
    }

    [Fact]
    public void InvokeAnActionForEachItem()
    {
        const int expected = 10;

        SutFactory
            .AllLists<int>(SutFactory.BuildArray(expected - 1))
            .ForEach(sut =>
        {
            var invokeCount = 0;
            sut.Enumerate(x =>
            {
                invokeCount++;
            });

            Assert.Equal(expected, invokeCount);
        });
    }

    [Fact]
    public void DoesNotFailOnEmpty()
    {
        SutFactory
            .AllLists<int>()
            .ForEach(sut =>
        {
            sut.Enumerate(x => Assert.Fail("Should not be called"));
        });
    }
}
