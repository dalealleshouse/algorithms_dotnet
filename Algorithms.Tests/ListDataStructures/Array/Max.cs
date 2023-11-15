namespace Algorithms.Tests.ListDataStructures.Array;

using Xunit;

public partial class Max
{
    private ComparableStruct[] testData = new ComparableStruct[] { new(1), new(2), new(3) };

    [Fact]
    public void UnwrapsTheValueOfArrayMax()
    {
        var sut = new ArrayTest<ComparableStruct>(this.testData);

        var arrayResult = sut.ArrayMax();
        var result = sut.Max();
        Assert.True(result.HasValue);
        Assert.Equal(3, arrayResult.Value.Item.Value);
        Assert.Equal(3, result.Value.Value);
    }
}
