namespace Algorithms.Tests.ListDataStructures.BinaryTree;

using System;
using Algorithms;
using Algorithms.ListDataStructures;
using Xunit;

public class InvariantValidator<T> : IInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    private readonly StructuredBinaryTree<T> sut;

    public InvariantValidator(IStructuredList<T> sut)
    {
        this.sut = (StructuredBinaryTree<T>)sut;
    }

    public void Validate()
    {
        this.RootIsSet();
        this.ParentIsSet(
            Maybe<StructuredBinaryTree<T>.Node>.None,
            this.sut.Root);
        this.LeftRightInvariant(this.sut.Root);
        this.SizeIsEqualToTheNumberOfChildNodes();
    }

    private void ParentIsSet(
            Maybe<StructuredBinaryTree<T>.Node> parent,
            Maybe<StructuredBinaryTree<T>.Node> node)
    {
        if (!node.HasValue) return;

        Assert.Equal(parent, node.Value.Parent);
        this.ParentIsSet(node, node.Value.Left);
        this.ParentIsSet(node, node.Value.Right);
    }

    private void RootIsSet()
    {
        if (this.sut.Length == 0)
        {
            Assert.False(this.sut.Root.HasValue);
        }
        else
        {
            Assert.True(this.sut.Root.HasValue);
        }
    }

    private void LeftRightInvariant(Maybe<StructuredBinaryTree<T>.Node> node)
    {
        if (!node.HasValue) return;

        this.LeftRightInvariant(node.Value.Left);

        if (node.Value.Left.HasValue)
            Assert.True(this.sut.Comparer(node.Value.Left.Value.Payload, node.Value.Payload) < 0);

        if (node.Value.Right.HasValue)
            Assert.True(this.sut.Comparer(node.Value.Right.Value.Payload, node.Value.Payload) > 0);

        this.LeftRightInvariant(node.Value.Right);
    }

    private void SizeIsEqualToTheNumberOfChildNodes()
    {
        if (!this.sut.Root.HasValue)
        {
            Assert.Equal(0, this.sut.Length);
        }
        else
        {
            var count = 0;
            this.sut.Enumerate(x => count++);
            Assert.Equal(count, this.sut.Length);
            Assert.Equal(this.sut.Length, this.sut.Root.Value.Size);
        }
    }
}
