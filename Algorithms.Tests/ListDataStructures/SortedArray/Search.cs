namespace Algorithms.Tests.ListDataStructures.SortedArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Search
{
    [Fact]
    public void RejectNull()
    {
        var sut = new SortedArray<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut.Search(null));
    }

    [Fact]
    public void ReturnFirstEqualItem()
    {
        var expected = 5;
        var exptectedResult = new Array<int>.ArrayResult(expected, expected);

        var sut = SutFactory.SortedIntArray(10);
        var result = sut.Search(expected);

        Assert.Equal(exptectedResult, result.Value);
    }

    [Fact]
    public void ReturnFalseSearchResultWhenNoPredicateMatch()
    {
        var sut = SutFactory.SortedIntArray(10);
        var result = sut.Search(20);

        Assert.False(result.HasValue);
    }

    [Fact]
    public void FindMiddleItem()
    {
        var sut = new SortedArray<char>(
                new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' });
        var exptectedResult = new Array<char>.ArrayResult(4, 'e');
        var result = sut.Search('e');

        Assert.Equal(exptectedResult, result.Value);
    }

    [Fact]
    public void FindFirstItem()
    {
        var exptectedResult = new Array<int>.ArrayResult(0, 0);
        var sut = SutFactory.SortedIntArray(10);
        var result = sut.Search(0);

        Assert.Equal(exptectedResult, result.Value);
    }

    [Fact]
    public void FindLastItem()
    {
        var exptectedResult = new Array<int>.ArrayResult(10, 10);
        var sut = SutFactory.SortedIntArray(10);
        var result = sut.Search(10);

        Assert.Equal(exptectedResult, result.Value);
    }
}
