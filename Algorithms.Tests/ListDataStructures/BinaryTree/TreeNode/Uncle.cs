namespace Algorithms.Tests.ListDataStructures.BinaryTree.TreeNode;

using Algorithms.ListDataStructures;
using Xunit;

public class Uncle
{
    [Fact]
    public void ReturnNullNodeWhenNotSet()
    {
        var sut = TreeNode<int>.CreateNullNode();
        var result = sut.Uncle();
        Assert.True(result.IsNull);
    }

    [Fact]
    public void ReturnNullNodeWhenNoChildren()
    {
        var nullNode = TreeNode<int>.CreateNullNode();
        TreeNode<int> sut = new(1, nullNode, nullNode, nullNode);
        var result = sut.Uncle();
        Assert.True(result.IsNull);
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

        var result = tree.Root.Left.Left.Uncle();
        Assert.False(result.IsNull);
        Assert.Equal(tree.Root.Right, result);
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

        var result = tree.Root.Right.Right.Uncle();
        Assert.False(result.IsNull);
        Assert.Equal(tree.Root.Left, result);
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
