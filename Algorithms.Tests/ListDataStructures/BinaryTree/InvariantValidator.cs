namespace Algorithms.Tests.ListDataStructures.BinaryTree;

using System;
using Algorithms;
using Algorithms.ListDataStructures;
using Xunit;

public class InvariantValidator<T> : IInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    private readonly UnbalancedBinaryTree<T> sut;

    public InvariantValidator(IStructuredList<T> sut)
    {
        this.sut = (UnbalancedBinaryTree<T>)sut;
    }

    public void Validate()
    {
        this.RootIsSet();
        this.ParentIsSet(
            Maybe<UnbalancedBinaryTree<T>.Node>.None,
            this.sut.Root);
        this.LeftRightInvariant(this.sut.Root);
        this.SizeIsEqualToNumberOfChildNodes();
        this.RootSizeIsEqualToNodeCount();
    }

    private void ParentIsSet(
            Maybe<UnbalancedBinaryTree<T>.Node> parent,
            Maybe<UnbalancedBinaryTree<T>.Node> node)
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
            Assert.True(this.sut.Root.Value.IsRoot);
        }
    }

    private void LeftRightInvariant(Maybe<UnbalancedBinaryTree<T>.Node> node)
    {
        if (!node.HasValue) return;

        this.LeftRightInvariant(node.Value.Left);

        if (node.Value.Left.HasValue)
            Assert.True(this.sut.Comparer(node.Value.Left.Value.Payload, node.Value.Payload) < 0);

        if (node.Value.Right.HasValue)
            Assert.True(this.sut.Comparer(node.Value.Right.Value.Payload, node.Value.Payload) > 0);

        this.LeftRightInvariant(node.Value.Right);
    }

    private void RootSizeIsEqualToNodeCount()
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

    private void SizeIsEqualToNumberOfChildNodes()
    {
        if (!this.sut.Root.HasValue)
        {
            Assert.Equal(0, this.sut.Length);
        }
        else
        {
            this.SizeIsEqualToNumberOfChildNodes(this.sut.Root);
        }
    }

    private void SizeIsEqualToNumberOfChildNodes(Maybe<UnbalancedBinaryTree<T>.Node> node)
    {
        if (!node.HasValue) return;

        Assert.Equal(node.Size(), node.Value.LeftSize + node.Value.RightSize + 1);

        this.SizeIsEqualToNumberOfChildNodes(node.Value.Left);
        this.SizeIsEqualToNumberOfChildNodes(node.Value.Right);
    }
}
