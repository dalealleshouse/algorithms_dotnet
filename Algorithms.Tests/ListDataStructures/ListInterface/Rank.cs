namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using Xunit;

public class Rank : ListTests
{
    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        this.RunTestOnAllLists<ComparableObject>(
            sut =>
            {
                Assert.Throws<ArgumentNullException>(() => sut.Rank(null));
            });
    }

    [Fact]
    public void ReturnZeroForEmptyList()
    {
        this.RunTestOnAllLists<ComparableObject>(
            sut =>
            {
                var result = sut.Rank(new(1));
                Assert.Equal(0, result);
            });
    }

    [Fact]
    public void ReturnRank()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Rank(138);
                Assert.Equal(138, result);
            },
            SutFactory.BuildArray(200));
    }

    [Fact]
    public void ReturnRankWithRandom()
    {
        this.RunTestOnAllLists<char>(
            sut =>
            {
                var result = sut.Rank('b');
                Assert.Equal(1, result);
            },
            new[] { 'a', 'h', 'f', 'd', 'e', 'c', 'g', 'b' });
    }

    [Fact]
    public void ReturnRankWithReverseCompare()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Rank(138);
                Assert.Equal(200 - 138, result);
            },
            SutFactory.BuildArray(200),
            (x, y) => y.CompareTo(x));
    }

    [Fact]
    public void ReturnArrayLengthPlusOneWhenItemHigherThanAll()
    {
        const int expected = 201;
        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Rank(expected * 2);
                Assert.Equal(expected, result);
            },
            SutFactory.BuildArray(200));
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
        this.RunTestOnAllLists<char>(
            sut =>
            {
                var result = sut.Rank(value);
                Assert.Equal(expected, result);
            },
            new[] { 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l' });
    }
}
