namespace Algorithms.Tests.ListDataStructures.BinaryTree;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public partial class Constructor
{
    private ComparableStruct[] testData = new ComparableStruct[] { new(1), new(2), new(3) };

    [Fact]
    public void RejectNull()
    {
        Assert.Throws<ArgumentNullException>(() => new StructuredBinaryTree<ComparableObject>(null, null));
    }

    [Fact]
    public void InitRoot()
    {
        var expected = Maybe<StructuredBinaryTree<int>.Node>.None;

        var sut = new StructuredBinaryTree<int>();
        Assert.Equal(0, sut.Length);
        Assert.Equal(expected, sut.Root);
    }

    [Fact]
    public void GeneratsListFromConstructorArray()
    {
        var sut = new StructuredBinaryTree<int>(new int[] { 1, 2, 3 });
        Assert.Equal(3, sut.Length);
    }
}
