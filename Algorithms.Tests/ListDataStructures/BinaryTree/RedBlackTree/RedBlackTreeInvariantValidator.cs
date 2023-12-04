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
    }

    public void EveryNodeIsRedOrBlack(Maybe<TreeNode<T>> node)
    {
        if (!node.HasValue) return;

        Assert.True(node.Value.Color == NodeColor.Red || node.Value.Color == NodeColor.Black);
    }
}
