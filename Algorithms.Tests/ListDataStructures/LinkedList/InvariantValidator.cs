namespace Algorithms.Tests.ListDataStructures.LinkedList;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class InvariantValidator<T> : IInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    private readonly StructuredLinkedList<T> sut;

    public InvariantValidator(IStructuredList<T> sut)
    {
        this.sut = (StructuredLinkedList<T>)sut;
    }

    public void Validate()
    {
        this.ValidateNextLinks();
        this.ValidatePreviousLinks();
        this.ValidateHeadAndTailAreSet();
        this.ValidateHeadPreviousIsNotSet();
        this.ValidateTailNextIsNotSet();
    }

    private void ValidateHeadAndTailAreSet()
    {
        if (this.sut.Length == 0)
        {
            Assert.False(this.sut.Head.HasValue);
            Assert.False(this.sut.Tail.HasValue);
        }
        else
        {
            Assert.True(this.sut.Head.HasValue);
            Assert.True(this.sut.Tail.HasValue);
        }
    }

    private void ValidateHeadPreviousIsNotSet()
    {
        if (this.sut.Length == 0) return;
        Assert.False(this.sut.Head.Value.Previous.HasValue);
    }

    private void ValidateTailNextIsNotSet()
    {
        if (this.sut.Length == 0) return;
        Assert.False(this.sut.Tail.Value.Next.HasValue);
    }

    private void ValidateNextLinks()
    {
        var count = 0;
        var node = this.sut.Head;

        while (node.HasValue)
        {
            count++;
            node = node.Value.Next;
        }

        Assert.Equal(count, this.sut.Length);
    }

    private void ValidatePreviousLinks()
    {
        var count = 0;
        var node = this.sut.Tail;

        while (node.HasValue)
        {
            count++;
            node = node.Value.Previous;
        }

        Assert.Equal(count, this.sut.Length);
    }
}
