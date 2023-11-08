namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Search
{
    [Fact]
    public void RejectNull()
    {
        var sut = new Array<object>();
        Assert.Throws<ArgumentNullException>(() => sut.Search(null));

        var sut2 = new Array<int>();
        Assert.Throws<ArgumentNullException>(() => sut.Search(null));
    }

    [Fact]
    public void ReturnFirstItemThatMatchesPredicate()
    {
        var expected = 5;

        var sut = SutFactory.IntArray(10);
        var result = sut.Search(x => x == expected);

        Assert.True(result.Found);
        Assert.Equal(expected, result.Index);
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnFalseSearchResultWhenNoPredicateMatch()
    {
        var sut = SutFactory.IntArray(10);
        var result = sut.Search(x => x == 20);

        Assert.False(result.Found);
        Assert.Equal(-1, result.Index);
        Assert.Equal(default(int), result.Value);
    }
}
