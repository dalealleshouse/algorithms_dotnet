namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using Xunit;

public class Search
{
    [Fact]
    public void RejectNull()
    {
        SutFactory
            .AllLists<ComparableObject>()
            .ForEach(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Search(null));
        });
    }

    [Fact]
    public void ReturnFirstEqualItem()
    {
        const int expected = 5;

        SutFactory
            .AllLists<int>(SutFactory.BuildArray(10))
            .ForEach(sut =>
        {
            var result = sut.Search(expected);
            Assert.Equal(expected, result.Value);
        });
    }

    [Fact]
    public void ReturnFalseSearchResultWhenNoMatch()
    {
        SutFactory
            .AllLists<int>(SutFactory.BuildArray(10))
            .ForEach(sut =>
        {
            var result = sut.Search(20);
            Assert.False(result.HasValue);
        });
    }

    [Fact]
    public void FindMiddleItem()
    {
        const char expected = 'e';

        SutFactory
            .AllLists<char>(new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' })
            .ForEach(sut =>
        {
            var result = sut.Search('e');
            Assert.Equal(expected, result.Value);
        });
    }

    [Fact]
    public void FindFirstItem()
    {
        const int expected = 0;
        SutFactory
            .AllLists<int>(SutFactory.BuildArray(10))
            .ForEach(sut =>
        {
            var result = sut.Search(expected);
            Assert.Equal(expected, result.Value);
        });
    }

    [Fact]
    public void FindLastItem()
    {
        const int expected = 10;
        SutFactory
            .AllLists<int>(SutFactory.BuildArray(10))
            .ForEach(sut =>
        {
            var result = sut.Search(expected);
            Assert.Equal(expected, result.Value);
        });
    }
}
