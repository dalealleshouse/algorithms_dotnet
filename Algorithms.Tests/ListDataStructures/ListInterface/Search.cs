namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using Xunit;

public class Search : ListTests
{
    [Fact]
    public void RejectNull()
    {
        this.RunTestOnAllLists<ComparableObject>(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Search(null));
        });
    }

    [Fact]
    public void ReturnFirstEqualItem()
    {
        const int expected = 5;

        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Search(expected);
                Assert.Equal(expected, result.Value);
            },
            SutFactory.BuildArray(10));
    }

    [Fact]
    public void ReturnFalseSearchResultWhenNoMatch()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Search(20);
                Assert.False(result.HasValue);
            },
            SutFactory.BuildArray(10));
    }

    [Fact]
    public void FindMiddleItem()
    {
        const char expected = 'e';

        this.RunTestOnAllLists<char>(
            sut =>
            {
                var result = sut.Search(expected);
                Assert.Equal(expected, result.Value);
            },
            new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' });
    }

    [Fact]
    public void FindFirstItem()
    {
        const int expected = 0;

        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Search(expected);
                Assert.Equal(expected, result.Value);
            },
            SutFactory.BuildArray(10));
    }

    [Fact]
    public void FindLastItem()
    {
        const int expected = 10;

        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Search(expected);
                Assert.Equal(expected, result.Value);
            },
            SutFactory.BuildArray(10));
    }
}
