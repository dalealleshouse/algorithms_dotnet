namespace Algorithms.Tests.ListDataStructures.SortedArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Rank
{
    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        var sut2 = new SortedArray<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut2.Rank(null));
    }

    [Fact]
    public void ReturnZeroForEmptyArray()
    {
        var sut = new SortedArray<ComparableStruct>();
        var result = sut.Rank(new(1));
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void ReturnRank()
    {
        var sut = SutFactory.SortedIntArray(200);
        var result = sut.Rank(138);
        Assert.True(result.HasValue);
        Assert.Equal(138, result.Value);
    }

    [Fact]
    public void ReturnRankWithReverseCompare()
    {
        var sut = SutFactory.SortedIntArray(200, (x, y) => y.CompareTo(x));
        var result = sut.Rank(138);
        Assert.True(result.HasValue);
        Assert.Equal(200 - 138, result.Value);
    }

    [Fact]
    public void ReturnArrayLengthPlusOneWhenItemHigherThanAll()
    {
        const int expected = 201;
        var sut = SutFactory.SortedIntArray(expected - 1);
        var result = sut.Rank(expected * 2);
        Assert.True(result.HasValue);
        Assert.Equal(expected, result.Value);
    }

    [Theory]
    [InlineData('a', 0)]
    [InlineData('b', 0)]
    [InlineData('c', 1)]
    [InlineData('d', 2)]
    [InlineData('e', 3)]
    [InlineData('f', 4)]
    [InlineData('g', 5)]
    [InlineData('h', 6)]
    [InlineData('i', 7)]
    [InlineData('j', 8)]
    [InlineData('k', 8)]
    [InlineData('l', 9)]
    [InlineData('m', 10)]
    public void ReturnRankAtEveryPosition(char value, int expected)
    {
        var sut = new SortedArray<char>(
                new[] { 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l' });

        var result = sut.Rank(value);
        Assert.Equal(expected, result.Value);
    }
}
