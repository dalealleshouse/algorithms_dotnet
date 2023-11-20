namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using System.Linq;
using Xunit;

public class Rank
{
    [Fact]
    public void ThrowsNullReferanceExeption()
    {
        SutFactory
            .AllLists<ComparableObject>()
            .Select(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Rank(null));
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnZeroForEmptyList()
    {
        SutFactory
            .AllLists<ComparableObject>()
            .Select(sut =>
        {
            var result = sut.Rank(new(1));
            Assert.Equal(0, result);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnRank()
    {
        SutFactory
            .AllLists<int>(SutFactory.BuildArray(200))
            .Select(sut =>
        {
            var result = sut.Rank(138);
            Assert.Equal(138, result);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnRankWithRandom()
    {
        SutFactory
            .AllLists<char>(new[] { 'a', 'h', 'f', 'd', 'e', 'c', 'g', 'b' })
            .Select(sut =>
        {
            var result = sut.Rank('b');
            Assert.Equal(1, result);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnRankWithReverseCompare()
    {
        SutFactory
            .AllLists<int>(SutFactory.BuildArray(200), (x, y) => y.CompareTo(x))
            .Select(sut =>
        {
            var result = sut.Rank(138);
            Assert.Equal(200 - 138, result);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void ReturnArrayLengthPlusOneWhenItemHigherThanAll()
    {
        const int expected = 201;
        SutFactory
            .AllLists<int>(SutFactory.BuildArray(expected - 1))
            .Select(sut =>
        {
            var result = sut.Rank(expected * 2);
            Assert.Equal(expected, result);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Theory]
    [InlineData('a', 0)]
    [InlineData('b', 0)]
    [InlineData('c', 1)]
    [InlineData('d', 2)]
    [InlineData('e', 3)]
    [InlineData('f', 4)]
    [InlineData('g', 5)]
    [InlineData('h', 6)]
    [InlineData('i', 7)]
    [InlineData('j', 8)]
    [InlineData('k', 8)]
    [InlineData('l', 9)]
    [InlineData('m', 10)]
    public void ReturnRankAtEveryPosition(char value, int expected)
    {
        SutFactory
            .AllLists<char>(new[] { 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l' })
            .Select(sut =>
        {
            var result = sut.Rank(value);
            Assert.Equal(expected, result);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }
}
