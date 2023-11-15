namespace Algorithms.Tests.ListDataStructures.SortedArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Max
{
    [Fact]
    public void ReturnMaxValue()
    {
        const int max = 10;
        var expected = new ArrayResult<int>(max, max);

        var sut = SutFactory.SortedIntArray(max);
        var result = sut.ArrayMax();
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnMaxObjectValue()
    {
        var data = new ComparableObject[] { new(1), new(2), new(3) };
        var sut = new SortedArray<ComparableObject>(data);

        ComparableObject c = null;
        Console.WriteLine(c);

        var result = sut.ArrayMax();
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
