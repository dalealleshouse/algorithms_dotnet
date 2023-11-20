namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using System.Linq;
using Xunit;

public class Enumerate
{
    [Fact]
    public void RejectNull()
    {
        SutFactory
            .AllLists<ComparableStruct>()
            .Select(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Enumerate(null));
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void InvokeAnActionForEachItem()
    {
        const int expected = 10;

        SutFactory
            .AllLists<int>(SutFactory.BuildArray(expected - 1))
            .Select(sut =>
        {
            var invokeCount = 0;
            sut.Enumerate(x =>
            {
                invokeCount++;
            });

            Assert.Equal(expected, invokeCount);
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }

    [Fact]
    public void DoesNotFailOnEmpty()
    {
        SutFactory
            .AllLists<int>()
            .Select(sut =>
        {
            sut.Enumerate(x => Assert.Fail("Should not be called"));
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }
}
