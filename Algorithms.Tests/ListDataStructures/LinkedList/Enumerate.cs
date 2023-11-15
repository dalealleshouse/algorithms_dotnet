namespace Algorithms.Tests.ListDataStructures.LinkedList;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Enumerate
{
    [Fact]
    public void RejectNull()
    {
        var sut = new LinkedList<ComparableStruct>();
        Assert.Throws<ArgumentNullException>(() => sut.Enumerate(null));
    }

    [Fact]
    public void InvokeAnActionForEachItem()
    {
        var sut = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });

        var expected = 5;
        sut.Enumerate(x =>
        {
            Assert.Equal(expected--, x);
        });
    }

    [Fact]
    public void DoesNotFailOnEmptyArray()
    {
        var sut = new LinkedList<int>();

        sut.Enumerate(x => Assert.Fail("Should not be called"));
    }
}
