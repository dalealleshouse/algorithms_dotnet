namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using System.Linq;
using Xunit;

public class Search
{
    [Fact]
    public void RejectNull()
    {
        SutFactory
            .AllLists<ComparableObject>()
            .Select(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Search(null));
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnFirstEqualItem()
    {
        const int expected = 5;

        SutFactory
            .AllLists<int>(SutFactory.BuildArray(10))
            .Select(sut =>
        {
            var result = sut.Search(expected);
            Assert.Equal(expected, result.Value);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnFalseSearchResultWhenNoMatch()
    {
        SutFactory
            .AllLists<int>(SutFactory.BuildArray(10))
            .Select(sut =>
        {
            var result = sut.Search(20);
            Assert.False(result.HasValue);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void FindMiddleItem()
    {
        const char expected = 'e';

        SutFactory
            .AllLists<char>(new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' })
            .Select(sut =>
        {
            var result = sut.Search('e');
            Assert.Equal(expected, result.Value);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void FindFirstItem()
    {
        const int expected = 0;
        SutFactory
            .AllLists<int>(SutFactory.BuildArray(10))
            .Select(sut =>
        {
            var result = sut.Search(expected);
            Assert.Equal(expected, result.Value);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void FindLastItem()
    {
        const int expected = 10;
        SutFactory
            .AllLists<int>(SutFactory.BuildArray(10))
            .Select(sut =>
        {
            var result = sut.Search(expected);
            Assert.Equal(expected, result.Value);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }
}
