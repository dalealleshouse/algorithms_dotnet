namespace Algorithms.Tests.ListDataStructures.RandomArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Predecessor
{
    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        var sut2 = new RandomArray<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut2.Predecessor(null));
    }

    [Fact]
    public void ReturnNotFoundForEmptyArray()
    {
        var sut = new RandomArray<ComparableStruct>();
        var result = sut.Predecessor(new(1));
        Assert.False(result.HasValue);
    }

    [Fact]
    public void ReturnPredecessor()
    {
        var expected = new Array<int>.ArrayResult(137, 137);
        var sut = SutFactory.IntArray(200);
        var result = sut.Predecessor(138);

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnPredecessorWithRandom()
    {
        var expected = new Array<char>.ArrayResult(5, 'c');
        var sut = new RandomArray<char>(
                new[] { 'a', 'h', 'f', 'd', 'e', 'c', 'g', 'b' },
                (x, y) => x.CompareTo(y));
        var result = sut.Predecessor('d');

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnFirstPredecessorWithRandom()
    {
        var expected = new Array<char>.ArrayResult(1, 'c');
        var sut = new RandomArray<char>(
                new[] { 'a', 'c', 'f', 'd', 'e', 'c', 'g', 'c' },
                (x, y) => x.CompareTo(y));
        var result = sut.Predecessor('d');

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnPredecessorWithReverseCompare()
    {
        var expected = new Array<int>.ArrayResult(139, 139);
        var sut = SutFactory.IntArray(200, (x, y) => y.CompareTo(x));
        var result = sut.Predecessor(138);

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnNotFoundWhenValueLowerThanItem()
    {
        var sut = SutFactory.IntArray(200);
        var result = sut.Predecessor(-1);
        Assert.False(result.HasValue);
    }
}
