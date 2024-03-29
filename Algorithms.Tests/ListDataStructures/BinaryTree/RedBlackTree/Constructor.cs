namespace Algorithms.Tests.ListDataStructures.RedBlackTree;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Constructor
{
    private ComparableStruct[] testData = new ComparableStruct[] { new(1), new(2), new(3) };

    [Fact]
    public void RejectNull()
    {
        Assert.Throws<ArgumentNullException>(() => new RedBlackTree<ComparableObject>(null, null));
    }

    [Fact]
    public void InitRoot()
    {
        var sut = new RedBlackTree<int>();
        Assert.Equal(0, sut.Length);
        Assert.Equal(sut.NullNode, sut.Root);
    }

    [Fact]
    public void GeneratsListFromConstructorArray()
    {
        var sut = new RedBlackTree<int>(new int[] { 1, 2, 3 });
        Assert.Equal(3, sut.Length);
    }
}
