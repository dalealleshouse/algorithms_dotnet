namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System.Linq;
using Xunit;

public partial class Max
{
    [Fact]
    public void ReturnNullMabyeForEmptyList()
    {
        SutFactory
            .AllLists<int>()
            .Select(sut =>
        {
            Assert.False(sut.Max().HasValue);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnMaxValueInList()
    {
        SutFactory
            .AllLists<int>(new int[] { 1, 2, 138, 3, 4, 5 })
            .Select(sut =>
        {
            Assert.Equal(138, sut.Max().Value);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnMaxValueForNonDefaultComparater()
    {
        SutFactory
            .AllLists<int>(
                new int[] { 1, 2, 138, 3, 4, 5 },
                (x, y) => y.CompareTo(x))
            .Select(sut =>
        {
            Assert.Equal(1, sut.Max().Value);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnMaxOfOneItem()
    {
        SutFactory
            .AllLists<int>(new int[] { 138 })
            .Select(sut =>
        {
            Assert.Equal(138, sut.Max().Value);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }
}
