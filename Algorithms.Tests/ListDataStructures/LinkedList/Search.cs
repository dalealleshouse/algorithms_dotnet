namespace Algorithms.Tests.ListDataStructures.LinkedList;

using Algorithms.ListDataStructures;
using Xunit;

public class Search
{
    [Fact]
    public void ReturnFirstItemThatMatchesPredicate()
    {
        var expected = 5;

        var sut = new StructuredLinkedList<int>(SutFactory.BuildArray(10));
        var result = sut.Search(x => x == expected);

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnFalseWhenNoPredicateMatch()
    {
        var sut = new StructuredLinkedList<int>(SutFactory.BuildArray(10));
        var result = sut.Search(x => x == 200);

        Assert.False(result.HasValue);
    }
}
