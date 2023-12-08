namespace Algorithms.Tests.ListDataStructures.BinaryTree.TreeNode;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class IsLeftChild
{
    private readonly UnbalancedBinaryTree<int> sut = BuildSut();

    [Fact]
    public void ReturnTureForNullNode()
    {
        var sut = TreeNode<int>.GetNullNode();
        Assert.True(sut.IsLeftChild);
    }

    [Fact]
    public void ReturnFalseWhenNoParent()
    {
        TreeNode<int> sut = new(1);
        Assert.False(sut.IsLeftChild);
    }

    [Fact]
    public void ReturnTrueWhenIsLeft()
    {
        Assert.True(this.sut.Root.Left.IsLeftChild);
    }

    [Fact]
    public void ReturnFalseWhenIsRight()
    {
        Assert.False(this.sut.Root.Right.IsLeftChild);
    }

    private static UnbalancedBinaryTree<int> BuildSut()
    {
        /*
         *     2
         *  1    3
         */
        var tree = new UnbalancedBinaryTree<int>();
        tree.Insert(2);
        tree.Insert(1);
        tree.Insert(3);
        return tree;
    }
}
