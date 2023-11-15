namespace Algorithms.Tests.ListDataStructures.LinkedList;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public partial class Constructor
{
    private ComparableStruct[] testData = new ComparableStruct[] { new(1), new(2), new(3) };

    [Fact]
    public void RejectNull()
    {
        Assert.Throws<ArgumentNullException>(() => new LinkedList<ComparableObject>(null, null));
    }

    [Fact]
    public void InitHeadAndTail()
    {
        var expected = Maybe<LinkedList<int>.Node>.None;

        var sut = new LinkedList<int>();
        Assert.Equal(0, sut.Length);
        Assert.Equal(expected, sut.Head);
        Assert.Equal(expected, sut.Tail);
    }

    [Fact]
    public void GeneratsListFromConstructorArray()
    {
        var sut = new LinkedList<int>(new int[] { 1, 2, 3 });
        Assert.Equal(3, sut.Length);
        Assert.Equal(3, sut.Head.Value.Value);
        Assert.Equal(1, sut.Tail.Value.Value);
    }

    [Fact]
    public void UseDefaultComparer()
    {
        var sut = new LinkedList<ComparableStruct>(this.testData);

        var arrayResult = sut.Max();
        var result = sut.Max();
        Assert.True(result.HasValue);
        Assert.Equal(3, result.Value.Value);
    }

    [Fact]
    public void UseCustomComparer()
    {
        var sut = new LinkedList<ComparableStruct>(this.testData, (x, y) => y.CompareTo(x));

        var result = sut.Max();
        Assert.True(result.HasValue);
        Assert.Equal(1, result.Value.Value);
    }
}
