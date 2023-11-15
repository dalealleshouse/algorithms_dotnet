namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using Xunit;

public partial class Search
{
    [Fact]
    public void RejectsNulL()
    {
        var sut = new ArrayTest<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut.Search(null));
    }

    [Fact]
    public void UnwrapsResultValueOfArraySearch()
    {
        var search = new ComparableStruct(1);
        var sut = new ArrayTest<ComparableStruct>();

        var arrayResult = sut.ArraySearch(search);
        Assert.True(arrayResult.HasValue);
        Assert.Equal(0, arrayResult.Value.Item.Value);

        var result = sut.Search(search);
        Assert.True(result.HasValue);
        Assert.Equal(0, result.Value.Value);
    }

    [Fact]
    public void UnwrapsNoValueResultOfArraySearch()
    {
        var search = new ComparableObject(1);
        var sut = new ArrayTest<ComparableObject>();

        var arrayResult = sut.ArraySearch(search);
        Assert.False(arrayResult.HasValue);

        var result = sut.Search(search);
        Assert.False(result.HasValue);
    }
}
