namespace Algorithms.Tests.Soting;

using Algorithms.ListDataStructures;
using Algorithms.Tests.ListDataStructures;
using Xunit;

public class BubbleSort
{
    [Fact]
    public void SortsValuesAcending()
    {
        var sut = new RandomArray<int>(SutFactory.UnorderedArray(100));

        sut.BubbleSort();

        var previous = sut[0];
        for (uint i = 1; i < sut.Length; i++)
        {
            Assert.True(previous <= sut[i]);
            previous = sut[i];
        }
    }
}
