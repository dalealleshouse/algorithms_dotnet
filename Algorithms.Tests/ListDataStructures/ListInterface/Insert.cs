namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using System.Linq;
using Xunit;

public class Insert
{
    [Fact]
    public void ThrowForNullInput()
    {
        SutFactory
            .AllLists<ComparableObject>()
            .Select(sut =>
        {
            Assert.Throws<ArgumentNullException>(() => sut.Insert(null));
            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }
}
