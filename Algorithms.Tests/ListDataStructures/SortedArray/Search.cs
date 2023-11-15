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
        var expectedResult = new ArrayResult<int>(expected, expected);

        var sut = SutFactory.SortedIntArray(10);
        var result = sut.ArraySearch(expected);

        Assert.Equal(expectedResult, result.Value);
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
        var expectedResult = new ArrayResult<char>(4, 'e');
        var result = sut.ArraySearch('e');

        Assert.Equal(expectedResult, result.Value);
    }

    [Fact]
    public void FindFirstItem()
    {
        var expectedResult = new ArrayResult<int>(0, 0);
        var sut = SutFactory.SortedIntArray(10);
        var result = sut.ArraySearch(0);

        Assert.Equal(expectedResult, result.Value);
    }

    [Fact]
    public void FindLastItem()
    {
        var expectedResult = new ArrayResult<int>(10, 10);
        var sut = SutFactory.SortedIntArray(10);
        var result = sut.ArraySearch(10);

        Assert.Equal(expectedResult, result.Value);
    }
}