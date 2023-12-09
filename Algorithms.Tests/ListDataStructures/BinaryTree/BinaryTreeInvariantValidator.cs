namespace Algorithms.Tests.ListDataStructures.StructuredBinaryTree;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class BinaryTreeInvariantValidator<T> : IInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    private readonly StructuredBinaryTree<T> sut;

    public BinaryTreeInvariantValidator(IStructuredList<T> sut)
    {
        this.sut = (StructuredBinaryTree<T>)sut;
    }

    public virtual void Validate()
    {
        this.RootIsSet();
        this.ParentIsSet(
            this.sut.NullNode,
            this.sut.Root);
        this.LeftRightInvariant(this.sut.Root);
        this.SizeIsEqualToNumberOfChildNodes();
        this.RootSizeIsEqualToNodeCount();
    }

    private void ParentIsSet(
            TreeNode<T> parent,
            TreeNode<T> node)
    {
        if (node.IsNull) return;

        Assert.Equal(parent, node.Parent);
        this.ParentIsSet(node, node.Left);
        this.ParentIsSet(node, node.Right);
    }

    private void RootIsSet()
    {
        if (this.sut.Length == 0)
        {
            Assert.True(this.sut.Root.IsNull);
        }
        else
        {
            Assert.False(this.sut.Root.IsNull);
            Assert.True(this.sut.Root.IsRoot());
        }
    }

    private void LeftRightInvariant(TreeNode<T> node)
    {
        if (node.IsNull) return;

        this.LeftRightInvariant(node.Left);

        if (!node.Left.IsNull)
            Assert.True(this.sut.Comparer(node.Left.Payload, node.Payload) < 0);

        if (!node.Right.IsNull)
            Assert.True(this.sut.Comparer(node.Right.Payload, node.Payload) > 0);

        this.LeftRightInvariant(node.Right);
    }

    private void RootSizeIsEqualToNodeCount()
    {
        if (this.sut.Root.IsNull)
        {
            Assert.Equal(0, this.sut.Length);
        }
        else
        {
            var count = 0;
            this.sut.Enumerate(x => count++);
            Assert.Equal(count, this.sut.Length);
            Assert.Equal(this.sut.Length, this.sut.Root.Size);
        }
    }

    private void SizeIsEqualToNumberOfChildNodes()
    {
        if (this.sut.Root.IsNull)
        {
            Assert.Equal(0, this.sut.Length);
        }
        else
        {
            this.SizeIsEqualToNumberOfChildNodes(this.sut.Root);
        }
    }

    private void SizeIsEqualToNumberOfChildNodes(TreeNode<T> node)
    {
        if (node.IsNull) return;

        Assert.Equal(node.Size, node.LeftSize() + node.RightSize() + 1);

        this.SizeIsEqualToNumberOfChildNodes(node.Left);
        this.SizeIsEqualToNumberOfChildNodes(node.Right);
    }
}
