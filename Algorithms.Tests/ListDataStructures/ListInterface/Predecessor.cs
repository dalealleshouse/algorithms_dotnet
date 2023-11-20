namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using System.Linq;
using Xunit;

public class Predecessor
{
    private readonly int[] data = new int[] { 1, 2, 137, 4, 5, 6, 7, 8, 139 };

    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        SutFactory
            .AllLists<ComparableObject>()
            .Select(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Predecessor(null));
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnNotFoundForEmpty()
    {
        SutFactory
            .AllLists<ComparableStruct>()
            .Select(sut =>
        {
            var result = sut.Predecessor(new(1));
            Assert.False(result.HasValue);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnPredecessor()
    {
        var expected = 137;
        SutFactory
            .AllLists<int>(this.data)
            .Select(sut =>
        {
            var result = sut.Predecessor(138);
            Assert.Equal(expected, result.Value);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnPredecessorWithReverseCompare()
    {
        var expected = 139;
        SutFactory
           .AllLists<int>(this.data, (x, y) => y.CompareTo(x))
           .Select(sut =>
       {
           var result = sut.Predecessor(138);
           Assert.Equal(expected, result.Value);
           return sut;
       })
       .Select(InvariantValidatorFactory.CreateValidator)
       .Validate();
    }

    [Fact]
    public void ReturnNotFoundWhenValueLowerThanItem()
    {
        SutFactory
            .AllLists<int>(this.data)
            .Select(sut =>
        {
            var result = sut.Predecessor(-1);
            Assert.False(result.HasValue);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
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

        SutFactory
            .AllLists<char>(new[] { 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l' })
            .Select(sut =>
        {
            var result = sut.Predecessor(value);
            Assert.Equal(expectedResult, result);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }
}
