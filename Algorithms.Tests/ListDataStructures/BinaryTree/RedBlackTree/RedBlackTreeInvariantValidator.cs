namespace Algorithms.Tests.ListDataStructures.RedBlackTree;

using System;
using Algorithms.ListDataStructures;
using Algorithms.Tests.ListDataStructures.StructuredBinaryTree;
using Xunit;

public class RedBlackTreeInvariantValidator<T> : BinaryTreeInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    private readonly RedBlackTree<T> sut;

    public RedBlackTreeInvariantValidator(IStructuredList<T> sut)
      : base(sut)
    {
        this.sut = (RedBlackTree<T>)sut;
    }

    public override void Validate()
    {
        base.Validate();
        this.EveryNodeIsRedOrBlack(this.sut.Root);
        this.RootNodeIsBlack();
        this.NoConsecutiveRedNodes(this.sut.Root);
    }

    private void EveryNodeIsRedOrBlack(Maybe<TreeNode<T>> node)
    {
        if (!node.HasValue) return;

        Assert.True(node.Value.Color == NodeColor.Red || node.Value.Color == NodeColor.Black);
        this.EveryNodeIsRedOrBlack(node.Value.Left);
        this.EveryNodeIsRedOrBlack(node.Value.Right);
    }

    private void RootNodeIsBlack()
    {
        if (this.sut.Root.HasValue)
            Assert.True(this.sut.Root.Value.Color == NodeColor.Black);
    }

    private void NoConsecutiveRedNodes(Maybe<TreeNode<T>> node)
    {
        if (!node.HasValue) return;

        if (node.Value.Color == NodeColor.Red)
        {
            Assert.Equal(NodeColor.Black, node.Value.Left.Color());
            Assert.Equal(NodeColor.Black, node.Value.Right.Color());
            Assert.Equal(NodeColor.Black, node.Value.Parent.Color());
        }

        this.NoConsecutiveRedNodes(node.Value.Left);
        this.NoConsecutiveRedNodes(node.Value.Right);
    }
}
