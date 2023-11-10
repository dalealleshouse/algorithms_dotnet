namespace Algorithms.Tests.ListDataStructures.SortedArray;

using Algorithms.ListDataStructures;
using Xunit;

public class Max
{
    [Fact]
    public void ReturnMaxValue()
    {
        const int max = 10;
        var expected = new Array<int>.ArrayResult(max, max);

        var sut = SutFactory.SortedIntArray(max);
        var result = sut.Max();
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnMaxObjectValue()
    {
        var data = new ComparableObject[] { new(1), new(2), new(3) };
        var sut = new SortedArray<ComparableObject>(data);

        var result = sut.Max();
        Assert.True(result.HasValue);
        Assert.Equal(2, result.Value.Index);
        Assert.Equal(data[2], result.Value.Item);
    }

    [Fact]
    public void ReturnNotFoundForEmptyArray()
    {
        var sut = new SortedArray<int>();
        var result = sut.Max();
        Assert.False(result.HasValue);
    }
}
