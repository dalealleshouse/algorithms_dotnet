namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using Xunit;

public class Predecessor : ListTests
{
    private readonly int[] data = new int[] { 1, 2, 137, 4, 5, 6, 7, 8, 139 };

    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        this.RunTestOnAllLists<ComparableObject>(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Predecessor(null));
        });
    }

    [Fact]
    public void ReturnNotFoundForEmpty()
    {
        this.RunTestOnAllLists<ComparableObject>(sut =>
        {
            var result = sut.Predecessor(new(1));
            Assert.False(result.HasValue);
        });
    }

    [Fact]
    public void ReturnPredecessor()
    {
        var expected = 137;
        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Predecessor(138);
                Assert.Equal(expected, result.Value);
            },
            this.data);
    }

    [Fact]
    public void ReturnPredecessorWithReverseCompare()
    {
        var expected = 139;
        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Predecessor(138);
                Assert.Equal(expected, result.Value);
            },
            this.data,
            (x, y) => y.CompareTo(x));
    }

    [Fact]
    public void ReturnNotFoundWhenValueLowerThanItem()
    {
        this.RunTestOnAllLists<int>(
            sut =>
            {
                var result = sut.Predecessor(-1);
                Assert.False(result.HasValue);
            },
            this.data);
    }

    [Theory]
    [InlineData('a', char.MinValue)]
    [InlineData('b', char.MinValue)]
    [InlineData('c', 'b')]
    [InlineData('d', 'c')]
    [InlineData('e', 'd')]
    [InlineData('f', 'e')]
    [InlineData('g', 'f')]
    [InlineData('h', 'g')]
    [InlineData('i', 'h')]
    [InlineData('j', 'i')]
    [InlineData('k', 'i')]
    [InlineData('l', 'k')]
    [InlineData('m', 'l')]
    [InlineData('z', 'l')]
    public void ReturnPredecessorAtEveryPosition(char value, char expected)
    {
        var expectedResult = (expected == char.MinValue) ?
            Maybe<char>.None :
            new(expected);

        this.RunTestOnAllLists<char>(
            sut =>
            {
                var result = sut.Predecessor(value);
                Assert.Equal(expectedResult, result);
            },
            new[] { 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l' });
    }
}
