namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using Xunit;

public class Delete : ListTests
{
    [Fact]
    public void RejectNull()
    {
        this.RunTestOnAllLists<ComparableObject>(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Delete(null));
        });
    }

    [Fact]
    public void DeleteRemovesValue()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                var doomed = 4;
                var deleteResult = sut.Delete(doomed);

                Assert.Equal(doomed, deleteResult.Value);
                var searchResult = sut.Search(doomed);
                Assert.False(searchResult.HasValue);
            },
            SutFactory.BuildArray(10));
    }

    [Fact]
    public void ReturnsNotFoundForNonExistantValues()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Search(100);
                Assert.False(result.HasValue);
            },
            SutFactory.BuildArray(10));
    }

    [Theory]
    [InlineData('a')]
    [InlineData('b')]
    [InlineData('c')]
    [InlineData('d')]
    [InlineData('e')]
    [InlineData('f')]
    [InlineData('g')]
    [InlineData('h')]
    [InlineData('i')]
    [InlineData('j')]
    [InlineData('k')]
    [InlineData('l')]
    [InlineData('m')]
    [InlineData('n')]
    [InlineData('o')]
    [InlineData('p')]
    [InlineData('q')]
    [InlineData('r')]
    [InlineData('s')]
    [InlineData('t')]
    [InlineData('u')]
    [InlineData('v')]
    [InlineData('w')]
    [InlineData('x')]
    [InlineData('y')]
    [InlineData('z')]
    public void DeleteAtEveryPosition(char doomed)
    {
        this.RunTestOnAllLists<char>(
            sut =>
            {
                var deleteResult = sut.Delete(doomed);

                Assert.Equal(doomed, deleteResult.Value);
                var searchResult = sut.Search(doomed);
                Assert.False(searchResult.HasValue);
            },
            new[] { 's', 'r', 'c', 'p', 'i', 'n', 'h', 'u', 'e', 'a', 'b', 'd', 'o', 'w', 't', 'y', 'l', 'q', 'v', 'j', 'f', 'z', 'm', 'k', 'x', 'g' });
    }
}
