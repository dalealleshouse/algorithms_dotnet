namespace Algorithms.Tests.ListDataStructures.RandomArray;

using Algorithms.ListDataStructures;
using Xunit;

public class Max
{
    [Fact]
    public void FindMaxBasedOnComparer()
    {
        const int max = 10;
        var sut = SutFactory.IntArray(max);

        var result = sut.ArrayMax();
        Assert.True(result.HasValue);
        Assert.Equal(max, result.Value.Index);
        Assert.Equal(max, result.Value.Item);
    }

    [Fact]
    public void FindMinBasedOnComparer()
    {
        var sut = SutFactory.IntArray(10, (x, y) => y.CompareTo(x));

        var result = sut.ArrayMax();
        Assert.True(result.HasValue);
        Assert.Equal(0, result.Value.Index);
        Assert.Equal(0, result.Value.Item);
    }

    [Fact]
    public void ReturnNotFoundForEmptyArray()
    {
        var sut = new RandomArray<int>();
        var result = sut.Max();
        Assert.False(result.HasValue);
    }
}
