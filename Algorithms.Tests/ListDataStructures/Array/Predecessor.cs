namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using Xunit;

public partial class Predecessor
{
    [Fact]
    public void RejectsNulL()
    {
        var sut = new ArrayTest<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut.Predecessor(null));
    }

    [Fact]
    public void UnwrapsResultValueOfArrayPredecessor()
    {
        var search = new ComparableStruct(1);
        var sut = new ArrayTest<ComparableStruct>();

        var arrayResult = sut.ArrayPredecessor(search);
        Assert.True(arrayResult.HasValue);
        Assert.Equal(0, arrayResult.Value.Item.Value);

        var result = sut.Predecessor(search);
        Assert.True(result.HasValue);
        Assert.Equal(0, result.Value.Value);
    }

    [Fact]
    public void UnwrapsNoValueResultOfArrayPredecessor()
    {
        var search = new ComparableObject(1);
        var sut = new ArrayTest<ComparableObject>();

        var arrayResult = sut.ArrayPredecessor(search);
        Assert.False(arrayResult.HasValue);

        var result = sut.Predecessor(search);
        Assert.False(result.HasValue);
    }
}
