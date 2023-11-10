namespace Algorithms.Tests.ListDataStructures.RandomArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class InsertAtTail
{
    [Fact]
    public void ThrowForNullInput()
    {
        var sut = new RandomArray<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut.InsertAtTail(null));
    }

    [Fact]
    public void InsertValueAtTheTailOfArray()
    {
        var sut = new RandomArray<int>();
        sut.InsertAtTail(1);
        sut.InsertAtTail(2);
        sut.InsertAtTail(3);

        Assert.Equal(1, sut[0]);
        Assert.Equal(2, sut[1]);
        Assert.Equal(3, sut[2]);
    }
}
