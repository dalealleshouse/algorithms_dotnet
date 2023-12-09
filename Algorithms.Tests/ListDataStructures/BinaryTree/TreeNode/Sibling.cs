namespace Algorithms.Tests.ListDataStructures.BinaryTree.TreeNode;

using Algorithms.ListDataStructures;
using Xunit;

public class Sibling
{
    [Fact]
    public void ReturnNotSetWhenNotSet()
    {
        var sut = TreeNode<int>.CreateNullNode();
        var result = sut.Sibling();
        Assert.True(result.IsNull);
    }

    [Fact]
    public void ReturnNotSetWhenNoChildren()
    {
        var nullNode = TreeNode<int>.CreateNullNode();
        TreeNode<int> sut = new(1, nullNode, nullNode);
        var result = sut.Sibling();
        Assert.True(result.IsNull);
    }

    [Fact]
    public void ReturnParentRightWhenIsLeftChild()
    {
        var tree = this.BuildSut();

        var result = tree.Root.Left.Sibling();
        Assert.False(result.IsNull);
        Assert.Equal(tree.Root.Right, result);
    }

    [Fact]
    public void ReturnParentLeftWhenIsRightChild()
    {
        var tree = this.BuildSut();

        var result = tree.Root.Right.Sibling();
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
