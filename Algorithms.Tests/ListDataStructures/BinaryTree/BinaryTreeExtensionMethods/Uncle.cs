namespace Algorithms.Tests.ListDataStructures.BinaryTree.BinaryTreeExtensionMethods;

using Algorithms.ListDataStructures;
using Xunit;

public class Uncle
{
    [Fact]
    public void ReturnNotSetWhenNotSet()
    {
        var sut = Maybe<TreeNode<int>>.None;
        var result = sut.Uncle();
        Assert.False(result.HasValue);
    }

    [Fact]
    public void ReturnNotSetWhenNoChildren()
    {
        Maybe<TreeNode<int>> sut = new(new(1));
        var result = sut.Uncle();
        Assert.False(result.HasValue);
    }

    [Fact]
    public void ReturnParentRightWhenIsLeftChild()
    {
        /*
         *       2
         *    1    3
         *  0
         */
        var tree = this.BuildSut();
        tree.Insert(0);

        var result = tree.Root.Left().Left().Uncle();
        Assert.True(result.HasValue);
        Assert.Equal(tree.Root.Right(), result);
    }

    [Fact]
    public void ReturnParentLeftWhenIsRightChild()
    {
        /*
         *       2
         *    1    3
         *           4
         */
        var tree = this.BuildSut();
        tree.Insert(4);

        var result = tree.Root.Right().Right().Uncle();
        Assert.True(result.HasValue);
        Assert.Equal(tree.Root.Left(), result);
    }

    private UnbalancedBinaryTree<int> BuildSut()
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
