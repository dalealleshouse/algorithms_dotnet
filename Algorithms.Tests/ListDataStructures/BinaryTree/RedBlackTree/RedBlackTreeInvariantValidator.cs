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
        this.ValidateBlackHeight(this.sut.Root);
    }

    private void EveryNodeIsRedOrBlack(TreeNode<T> node)
    {
        if (node.IsNull) return;

        Assert.True(node.IsRed || node.IsBlack);
        this.EveryNodeIsRedOrBlack(node.Left);
        this.EveryNodeIsRedOrBlack(node.Right);
    }

    private void RootNodeIsBlack() => Assert.True(this.sut.Root.IsBlack);

    private void NoConsecutiveRedNodes(TreeNode<T> node)
    {
        if (node.IsNull) return;

        if (node.IsRed)
        {
            Assert.Equal(NodeColor.Black, node.Left.Color);
            Assert.Equal(NodeColor.Black, node.Right.Color);
            Assert.Equal(NodeColor.Black, node.Parent.Color);
        }

        this.NoConsecutiveRedNodes(node.Left);
        this.NoConsecutiveRedNodes(node.Right);
    }

    private int ValidateBlackHeight(TreeNode<T> node)
    {
        if (node.IsNull) return 0;

        int leftBlackHeight = this.ValidateBlackHeight(node.Left);
        int rightBlackHeight = this.ValidateBlackHeight(node.Right);

        if (leftBlackHeight != rightBlackHeight && leftBlackHeight != 0 && rightBlackHeight != 0)
        {
            this.sut.Root.PrintTree();

            // Optionally, throw a more informative exception here
            throw new InvalidOperationException($"Black height imbalance detected at node {node.StringValue()}. Left height: {leftBlackHeight}, Right height: {rightBlackHeight}");
        }

        return (node.IsBlack ? 1 : 0) + leftBlackHeight;
    }
}
