namespace Algorithms.Tests.ListDataStructures.RandomArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Rank
{
    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        var sut2 = new RandomArray<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut2.Rank(null));
    }

    [Fact]
    public void ReturnZeroForEmptyArray()
    {
        var sut = new RandomArray<ComparableStruct>();
        var result = sut.Rank(new(1));
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void ReturnRank()
    {
        var sut = SutFactory.IntArray(200);
        var result = sut.Rank(138);
        Assert.True(result.HasValue);
        Assert.Equal(138, result.Value);
    }

    [Fact]
    public void ReturnRankWithRandom()
    {
        var sut = new RandomArray<char>(new[] { 'a', 'h', 'f', 'd', 'e', 'c', 'g', 'b' });
        var result = sut.Rank('b');
        Assert.True(result.HasValue);
        Assert.Equal(1, result.Value);
    }

    [Fact]
    public void ReturnRankWithReverseCompare()
    {
        var sut = SutFactory.IntArray(200, (x, y) => y.CompareTo(x));
        var result = sut.Rank(138);
        Assert.True(result.HasValue);
        Assert.Equal(200 - 138, result.Value);
    }

    [Fact]
    public void ReturnArrayLengthPlusOneWhenItemHigherThanAll()
    {
        const int expected = 201;
        var sut = SutFactory.IntArray(expected - 1);
        var result = sut.Rank(expected * 2);
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
    }
}
