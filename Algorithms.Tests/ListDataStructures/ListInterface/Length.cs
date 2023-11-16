namespace Algorithms.Tests.ListDataStructures.ListInterface;

using Xunit;

public class Length
{
    [Fact]
    public void ThrowForNullInput()
    {
        SutFactory
            .AllLists<int>()
            .ForEach(sut =>
        {
            for (int i = 1; i < 10; i++)
            {
                sut.Insert(i * 2);
                Assert.Equal(i, sut.Length);
            }
        });
    }
}
