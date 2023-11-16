namespace Algorithms.Tests.ListDataStructures.ListInterface;

using Xunit;

public partial class Max
{
    [Fact]
    public void ReturnNullMabyeForEmptyList()
    {
        SutFactory
            .AllLists<int>()
            .ForEach(sut =>
        {
            Assert.False(sut.Max().HasValue);
        });
    }

    [Fact]
    public void ReturnMaxValueInList()
    {
        SutFactory
            .AllLists<int>(new int[] { 1, 2, 138, 3, 4, 5 })
            .ForEach(sut =>
        {
            Assert.Equal(138, sut.Max().Value);
        });
    }

    [Fact]
    public void ReturnMaxValueForNonDefaultComparater()
    {
        SutFactory
            .AllLists<int>(
                new int[] { 1, 2, 138, 3, 4, 5 },
                (x, y) => y.CompareTo(x))
            .ForEach(sut =>
        {
            Assert.Equal(1, sut.Max().Value);
        });
    }

    [Fact]
    public void ReturnMaxOfOneItem()
    {
        SutFactory
            .AllLists<int>(new int[] { 138 })
            .ForEach(sut =>
        {
            Assert.Equal(138, sut.Max().Value);
        });
    }
}
