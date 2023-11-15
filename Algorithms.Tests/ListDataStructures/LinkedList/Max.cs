namespace Algorithms.Tests.ListDataStructures.LinkedList;

using Algorithms.ListDataStructures;
using Xunit;

public partial class Max
{
    [Fact]
    public void ReturnNullMabyeForEmptyList()
    {
        var sut = new LinkedList<int>();
        Assert.False(sut.Max().HasValue);
    }

    [Fact]
    public void ReturnMaxValueInList()
    {
        var sut = new LinkedList<int>(new int[] { 1, 2, 138, 3, 4, 5 });
        Assert.Equal(138, sut.Max().Value);
    }

    [Fact]
    public void ReturnMaxValueForNonDefaultComparater()
    {
        var sut = new LinkedList<int>(
                new int[] { 1, 2, 138, 3, 4, 5 },
                (x, y) => y.CompareTo(x));

        Assert.Equal(1, sut.Max().Value);
    }

    [Fact]
    public void ReturnMaxOfOneItem()
    {
        var sut = new LinkedList<int>(new int[] { 138 });

        Assert.Equal(138, sut.Max().Value);
    }
}
