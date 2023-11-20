namespace Algorithms.Tests.ListDataStructures.ListInterface;

using Xunit;

public partial class Max : ListTests
{
    [Fact]
    public void ReturnNullMabyeForEmptyList()
    {
        this.RunTestOnAllLists<int>(sut =>
        {
            Assert.False(sut.Max().HasValue);
        });
    }

    [Fact]
    public void ReturnMaxValueInList()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                Assert.Equal(138, sut.Max().Value);
            },
            new int[] { 1, 2, 138, 3, 4, 5 });
    }

    [Fact]
    public void ReturnMaxValueForNonDefaultComparater()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                Assert.Equal(1, sut.Max().Value);
            },
            new int[] { 1, 2, 138, 3, 4, 5 },
            (x, y) => y.CompareTo(x));
    }

    [Fact]
    public void ReturnMaxOfOneItem()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                Assert.Equal(138, sut.Max().Value);
            },
            new int[] { 138 });
    }
}
