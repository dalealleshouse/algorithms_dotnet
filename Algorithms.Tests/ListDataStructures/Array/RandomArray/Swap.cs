namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Swap
{
    [Fact]
    public void RejectValuesHigherThanLength()
    {
        var sut = SutFactory.RandomArray(10);
        Assert.Throws<IndexOutOfRangeException>(() => sut.Swap(10, 11));
    }

    [Fact]
    public void SwapValue()
    {
        var sut = new RandomArray<int>();
        sut.Insert(138);
        sut.Insert(831);

        Assert.Equal(831, sut[0]);
        Assert.Equal(138, sut[1]);

        sut.Swap(0, 1);

        Assert.Equal(831, sut[1]);
        Assert.Equal(138, sut[0]);
    }
}
