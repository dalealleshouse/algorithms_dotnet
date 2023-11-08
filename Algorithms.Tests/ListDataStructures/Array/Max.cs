namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Max
{
    [Fact]
    public void FindMaxBasedOnComparer()
    {
        const int max = 10;
        var sut = SutFactory.IntArray(max);

        var result = sut.Max((x, y) => x.CompareTo(y));
        Assert.True(result.HasValue);
        Assert.Equal(max, result.Value.Index);
        Assert.Equal(max, result.Value.Item);
    }

    [Fact]
    public void FindMinBasedOnComparer()
    {
        const int max = 10;
        var sut = SutFactory.IntArray(max);

        var result = sut.Max((x, y) => y.CompareTo(x));
        Assert.True(result.HasValue);
        Assert.Equal(0, result.Value.Index);
        Assert.Equal(0, result.Value.Item);
    }

    [Fact]
    public void ReturnNotFoundForEmptyArray()
    {
        var sut = new Array<int>();
        var result = sut.Max((x, y) => x.CompareTo(y));
        Assert.False(result.HasValue);
    }

    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        var sut = SutFactory.IntArray(10);
        Assert.Throws<ArgumentNullException>(() => sut.Max(null));
    }
}
