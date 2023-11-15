namespace Algorithms.Tests.ListDataStructures.LinkedList;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public partial class Insert
{
    [Fact]
    public void RejectNull()
    {
        var sut = new LinkedList<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut.Insert(null));
    }

    [Fact]
    public void SetsHeadAndTailOnFirstInsert()
    {
        var expected = new LinkedList<int>.Node(1, null, null);
        var sut = new LinkedList<int>();

        sut.Insert(1);

        Assert.Equal(1, sut.Length);
        Assert.Equal(1, sut.Head.Value.Value);
        Assert.False(sut.Head.Value.Next.HasValue);
        Assert.False(sut.Head.Value.Previous.HasValue);
    }

    [Fact]
    public void SetsHeadAndTailOnSecondInsert()
    {
        var sut = new LinkedList<int>();

        sut.Insert(1);
        sut.Insert(2);

        Assert.Equal(2, sut.Length);

        Assert.True(sut.Head.HasValue);
        Assert.Equal(2, sut.Head.Value.Value);
        Assert.Equal(sut.Head.Value.Next, sut.Tail);
        Assert.False(sut.Head.Value.Previous.HasValue);

        Assert.True(sut.Tail.HasValue);
        Assert.Equal(1, sut.Tail.Value.Value);
        Assert.Equal(sut.Tail.Value.Previous, sut.Head);
        Assert.False(sut.Tail.Value.Next.HasValue);
    }

    [Fact]
    public void SetNextLinks()
    {
        var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var sut = new LinkedList<int>(data);

        var head = sut.Head.Value;
        for (int i = 10; i >= 1; i--)
        {
            Assert.Equal(i, head.Value);
            if (head.Next.HasValue) head = head.Next.Value;
        }

        Assert.False(head.Next.HasValue);
    }

    [Fact]
    public void SetPreviousLinks()
    {
        var data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var sut = new LinkedList<int>(data);

        var tail = sut.Tail.Value;
        for (int i = 1; i <= 10; i++)
        {
            Assert.Equal(i, tail.Value);
            if (tail.Previous.HasValue) tail = tail.Previous.Value;
        }

        Assert.False(tail.Previous.HasValue);
    }
}
