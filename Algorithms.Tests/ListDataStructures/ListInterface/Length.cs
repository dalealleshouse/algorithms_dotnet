namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System.Linq;
using Xunit;

public class Length
{
    [Fact]
    public void ThrowForNullInput()
    {
        SutFactory
            .AllLists<int>()
            .Select(sut =>
        {
            for (int i = 1; i < 10; i++)
            {
                sut.Insert(i * 2);
                Assert.Equal(i, sut.Length);
            }

            return sut;
        })
        .Select(InvariantValidatorFactory.CreateValidator)
        .Validate();
    }
}
