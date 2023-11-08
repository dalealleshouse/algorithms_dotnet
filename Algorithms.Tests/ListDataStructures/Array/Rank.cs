namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Rank
{
    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        var sut = SutFactory.IntArray(10);
        Assert.Throws<ArgumentNullException>(() => sut.Rank(138, null));

        var sut2 = new Array<object>();
        Assert.Throws<ArgumentNullException>(() => sut2.Rank(null, (x, y) => -1));
    }

    [Fact]
    public void ReturnZeroForEmptyArray()
    {
        var sut = new Array<object>();
        var result = sut.Rank(new(), (x, y) => -1);
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void ReturnRank()
    {
        var sut = SutFactory.IntArray(200);
        var result = sut.Rank(138, (x, y) => x.CompareTo(y));
        Assert.True(result.HasValue);
        Assert.Equal(138, result.Value);
    }

    [Fact]
    public void ReturnRankWithRandom()
    {
        var sut = new Array<char>(new[] { 'a', 'h', 'f', 'd', 'e', 'c', 'g', 'b' });
        var result = sut.Rank('b', (x, y) => x.CompareTo(y));
        Assert.True(result.HasValue);
        Assert.Equal(1, result.Value);
    }

    [Fact]
    public void ReturnRankPredecessorWithRandom()
    {
        var sut = new Array<char>(new[] { 'a', 'c', 'b', 'd', 'e', 'c', 'g', 'c' });
        var result = sut.Rank('d', (x, y) => x.CompareTo(y));
        Assert.True(result.HasValue);
        Assert.Equal(5, result.Value);
    }

    [Fact]
    public void ReturnRankWithReverseCompare()
    {
        var sut = SutFactory.IntArray(200);
        var result = sut.Rank(138, (x, y) => y.CompareTo(x));
        Assert.True(result.HasValue);
        Assert.Equal(200 - 138, result.Value);
    }

    [Fact]
    public void ReturnArrayLengthPlusOneWhenItemHigherThanAll()
    {
        const int expected = 201;
        var sut = SutFactory.IntArray(expected - 1);
        var result = sut.Rank(expected * 2, (x, y) => x.CompareTo(y));
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
    }
}
