namespace Algorithms.Tests.ListDataStructures.RandomArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Enumerate
{
    [Fact]
    public void RejectNull()
    {
        var sut = new RandomArray<ComparableStruct>();
        Assert.Throws<ArgumentNullException>(() => sut.Enumerate(null));
    }

    [Fact]
    public void InvokeAnActionForEachItem()
    {
        const int max = 10;
        var sut = SutFactory.IntArray(max);

        var expected = 0;
        sut.Enumerate(x =>
        {
            Assert.Equal(expected++, x);
        });
    }

    [Fact]
    public void DoesNotFailOnEmptyArray()
    {
        var sut = new RandomArray<int>();

        sut.Enumerate(x => Assert.Fail("Should not be called"));
    }
}
