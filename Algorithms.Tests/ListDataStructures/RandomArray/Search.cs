namespace Algorithms.Tests.ListDataStructures.RandomArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Search
{
    [Fact]
    public void RejectNull()
    {
        var sut = new RandomArray<ComparableStruct>();
        Assert.Throws<ArgumentNullException>(() => sut.Search(null));

        var sut2 = new RandomArray<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut2.Search((ComparableObject)null));
    }

    [Fact]
    public void ReturnFirstItemThatMatchesPredicate()
    {
        var expected = 5;
        var exptectedResult = new Array<int>.ArrayResult(expected, expected);

        var sut = SutFactory.IntArray(10);
        var result = sut.Search(x => x == expected);

        Assert.Equal(exptectedResult, result.Value);
    }

    [Fact]
    public void ReturnFirstEqualItem()
    {
        var expected = 5;
        var exptectedResult = new Array<int>.ArrayResult(expected, expected);

        var sut = SutFactory.IntArray(10);
        var result = sut.Search(5);

        Assert.Equal(exptectedResult, result.Value);
    }

    [Fact]
    public void ReturnFalseSearchResultWhenNoPredicateMatch()
    {
        var sut = SutFactory.IntArray(10);
        var result = sut.Search(x => x == 20);

        Assert.False(result.HasValue);
    }
}
