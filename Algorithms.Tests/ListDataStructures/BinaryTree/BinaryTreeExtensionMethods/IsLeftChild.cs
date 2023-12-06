namespace Algorithms.Tests.ListDataStructures.BinaryTree.BinaryTreeExtensionMethods;

using Algorithms.ListDataStructures;
using Xunit;

public class IsLeftChild
{
    private readonly UnbalancedBinaryTree<int> sut = BuildSut();

    [Fact]
    public void ReturnFalseWhenNotSet()
    {
        var sut = Maybe<TreeNode<int>>.None;
        Assert.False(sut.IsLeftChild());
    }

    [Fact]
    public void ReturnNotSetWhenNoParent()
    {
        Maybe<TreeNode<int>> sut = new(new(1));
        Assert.False(sut.IsLeftChild());
    }

    [Fact]
    public void ReturnTrueWhenIsLeft()
    {
        Assert.True(this.sut.Root.Left().IsLeftChild());
    }

    [Fact]
    public void ReturnFalseWhenIsRight()
    {
        Assert.False(this.sut.Root.Right().IsLeftChild());
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
