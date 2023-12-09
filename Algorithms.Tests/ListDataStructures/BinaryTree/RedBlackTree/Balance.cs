namespace Algorithms.Tests.ListDataStructures.RedBlackTree;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class Balance
{
    [Fact]
    public void ColorChildNodesRed()
    {
        var sut = new RedBlackTree<int>();
        sut.Insert(2);
        sut.Insert(1);
        sut.Insert(3);

        Assert.Equal(NodeColor.Black, sut.Root.Color);
        Assert.Equal(NodeColor.Red, sut.Root.Left.Color);
        Assert.Equal(NodeColor.Red, sut.Root.Right.Color);

        var validator = new RedBlackTreeInvariantValidator<int>(sut);
        validator.Validate();
    }

    [Fact]
    public void UncleNodeIsRead()
    {
        var sut = new RedBlackTree<int>();
        sut.Insert(35);
        sut.Insert(25);
        sut.Insert(45);
        sut.Insert(20);

        var validator = new RedBlackTreeInvariantValidator<int>(sut);
        validator.Validate();
    }

    [Fact]
    public void DeleteReblances()
    {
        var sut = new RedBlackTree<int>(SutFactory.BuildArray(10));
        var doomed = 4;
        var deleteResult = sut.Delete(doomed);

        Assert.Equal(doomed, deleteResult.Value);
        var searchResult = sut.Search(doomed);
        Assert.False(searchResult.HasValue);

        var validator = new RedBlackTreeInvariantValidator<int>(sut);
        validator.Validate();
    }

    [Fact]
    public void DeleteReblances2()
    {
        var sut = new RedBlackTree<char>(
            new[] { 'b', 'c', 'l', 'e', 'f', 'g', 'h', 'i', 'k', 'd' });
        var doomed = 'g';
        var deleteResult = sut.Delete(doomed);

        Assert.Equal(doomed, deleteResult.Value);
        var searchResult = sut.Search(doomed);
        Assert.False(searchResult.HasValue);

        var validator = new RedBlackTreeInvariantValidator<char>(sut);
        validator.Validate();
    }
}
