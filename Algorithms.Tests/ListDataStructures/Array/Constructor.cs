namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using Xunit;

public class Constructor
{
    private ComparableStruct[] testData = new ComparableStruct[] { new(1), new(2), new(3) };

    [Fact]
    public void RejectNull()
    {
        Assert.Throws<ArgumentNullException>(() => new ArrayTest<ComparableObject>(null));
    }

    [Fact]
    public void UseDefaultComparer()
    {
        var sut = new ArrayTest<ComparableStruct>(this.testData);

        var arrayResult = sut.ArrayMax();
        var result = sut.Max();
        Assert.True(result.HasValue);
        Assert.Equal(3, arrayResult.Value.Item.Value);
        Assert.Equal(3, result.Value.Value);
    }

    [Fact]
    public void UseCustomComparer()
    {
        var sut = new ArrayTest<ComparableStruct>(this.testData, (x, y) => y.CompareTo(x));

        var result = sut.ArrayMax();
        Assert.True(result.HasValue);
        Assert.Equal(1, result.Value.Item.Value);
    }
}
