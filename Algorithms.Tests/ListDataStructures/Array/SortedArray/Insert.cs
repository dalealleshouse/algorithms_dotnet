namespace Algorithms.Tests.ListDataStructures.SortedArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Insert
{
    [Fact]
    public void ThrowForNullInput()
    {
        var sut = new SortedArray<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut.Insert(null));
    }

    [Fact]
    public void InsertValuesInOrder()
    {
        var sut = new SortedArray<int>();
        sut.Insert(2);
        sut.Insert(1);
        sut.Insert(3);

        Assert.Equal(1, sut[0]);
        Assert.Equal(2, sut[1]);
        Assert.Equal(3, sut[2]);
    }

    [Fact]
    public void InsertValuesInOrderWithCustomCompare()
    {
        var sut = new SortedArray<int>((x, y) => y.CompareTo(x));
        sut.Insert(2);
        sut.Insert(1);
        sut.Insert(3);

        Assert.Equal(3, sut[0]);
        Assert.Equal(2, sut[1]);
        Assert.Equal(1, sut[2]);
    }
}
