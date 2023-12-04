namespace Algorithms.Tests.ListDataStructures.UnbalancedBinaryTree;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public partial class Constructor
{
    private ComparableStruct[] testData = new ComparableStruct[] { new(1), new(2), new(3) };

    [Fact]
    public void RejectNull()
    {
        Assert.Throws<ArgumentNullException>(() => new UnbalancedBinaryTree<ComparableObject>(null, null));
    }

    [Fact]
    public void InitRoot()
    {
        var expected = Maybe<TreeNode<int>>.None;

        var sut = new UnbalancedBinaryTree<int>();
        Assert.Equal(0, sut.Length);
        Assert.Equal(expected, sut.Root);
    }

    [Fact]
    public void GeneratsListFromConstructorArray()
    {
        var sut = new UnbalancedBinaryTree<int>(new int[] { 1, 2, 3 });
        Assert.Equal(3, sut.Length);
    }
}
