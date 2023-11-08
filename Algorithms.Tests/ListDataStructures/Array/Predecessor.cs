namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Predecessor
{
    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        var sut = SutFactory.IntArray(10);
        Assert.Throws<ArgumentNullException>(() => sut.Predecessor(null, 138));
    }

    [Fact]
    public void ReturnNotFoundForEmptyArray()
    {
        var sut = new Array<object>();
        var result = sut.Predecessor((x, y) => -1, new());
        Assert.False(result.HasValue);
    }

    [Fact]
    public void ReturnPredecessor()
    {
        var sut = SutFactory.IntArray(200);
        var result = sut.Predecessor((x, y) => x.CompareTo(y), 138);
        Assert.True(result.HasValue);
        Assert.Equal(137, result.Value.Index);
        Assert.Equal(137, result.Value.Item);
    }

    [Fact]
    public void ReturnPredecessorWithRandom()
    {
        var sut = new Array<char>(new[] { 'a', 'h', 'f', 'd', 'e', 'c', 'g', 'b' });
        var result = sut.Predecessor((x, y) => x.CompareTo(y), 'd');
        Assert.True(result.HasValue);
        Assert.Equal(5, result.Value.Index);
        Assert.Equal('c', result.Value.Item);
    }

    [Fact]
    public void ReturnFirstPredecessorWithRandom()
    {
        var sut = new Array<char>(new[] { 'a', 'c', 'f', 'd', 'e', 'c', 'g', 'c' });
        var result = sut.Predecessor((x, y) => x.CompareTo(y), 'd');
        Assert.True(result.HasValue);
        Assert.Equal(1, result.Value.Index);
        Assert.Equal('c', result.Value.Item);
    }

    [Fact]
    public void ReturnPredecessorWithReverseCompare()
    {
        var sut = SutFactory.IntArray(200);
        var result = sut.Predecessor((x, y) => y.CompareTo(x), 138);
        Assert.True(result.HasValue);
        Assert.Equal(139, result.Value.Index);
        Assert.Equal(139, result.Value.Item);
    }

    [Fact]
    public void ReturnNotFoundWhenValueLowerThanItem()
    {
        var sut = SutFactory.IntArray(200);
        var result = sut.Predecessor((x, y) => x.CompareTo(y), -1);
        Assert.False(result.HasValue);
    }
}
