namespace Algorithms.Tests.ListDataStructures.RandomArray;

using Algorithms.ListDataStructures;
using Xunit;

public class Search
{
    [Fact]
    public void ReturnFirstItemThatMatchesPredicate()
    {
        var expected = 5;
        var expectedResult = new ArrayResult<int>(expected, expected);

        var sut = SutFactory.RandomArray(10);
        var result = sut.Search(x => x == expected);

        Assert.Equal(expectedResult, result.Value);
    }

    [Fact]
    public void ReturnFirstEqualItem()
    {
        var expected = 5;
        var expectedResult = new ArrayResult<int>(expected, expected);

        var sut = SutFactory.RandomArray(10);
        var result = sut.ArraySearch(5);

        Assert.Equal(expectedResult, result.Value);
    }

    [Fact]
    public void ReturnFalseSearchResultWhenNoPredicateMatch()
    {
        var sut = SutFactory.RandomArray(10);
        var result = sut.Search(x => x == 20);

        Assert.False(result.HasValue);
    }
}
