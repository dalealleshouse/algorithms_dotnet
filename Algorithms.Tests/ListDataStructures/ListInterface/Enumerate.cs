namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using Xunit;

public class Enumerate : ListTests
{
    [Fact]
    public void RejectNull()
    {
        this.RunTestOnAllLists<ComparableStruct>(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Enumerate(null));
        });
    }

    [Fact]
    public void InvokeAnActionForEachItem()
    {
        const int expected = 10;

        this.RunTestOnAllLists<int>(
            sut =>
            {
                var invokeCount = 0;
                sut.Enumerate(x =>
                {
                    invokeCount++;
                });

                Assert.Equal(expected, invokeCount);
            },
            SutFactory.BuildArray(expected - 1));
    }

    [Fact]
    public void DoesNotFailOnEmpty()
    {
        this.RunTestOnAllLists<int>(sut =>
        {
            sut.Enumerate(x => Assert.Fail("Should not be called"));
        });
    }
}
