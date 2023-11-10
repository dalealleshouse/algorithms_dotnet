namespace Algorithms.Tests.ListDataStructures.SortedArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Predecessor
{
    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        var sut2 = new SortedArray<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut2.Predecessor(null));
    }

    [Fact]
    public void ReturnNotFoundForEmptyArray()
    {
        var sut = new SortedArray<ComparableStruct>();
        var result = sut.Predecessor(new(1));
        Assert.False(result.HasValue);
    }

    [Fact]
    public void ReturnPredecessor()
    {
        var expected = new Array<int>.ArrayResult(137, 137);
        var sut = SutFactory.SortedIntArray(200);
        var result = sut.Predecessor(138);

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnPredecessorWithReverseCompare()
    {
        var expected = new Array<int>.ArrayResult(61, 139);
        var sut = SutFactory.SortedIntArray(200, (x, y) => y.CompareTo(x));
        Console.WriteLine(sut[139]);
        var result = sut.Predecessor(138);

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnNotFoundWhenValueLowerThanItem()
    {
        var sut = SutFactory.SortedIntArray(200);
        var result = sut.Predecessor(-1);
        Assert.False(result.HasValue);
    }
}
