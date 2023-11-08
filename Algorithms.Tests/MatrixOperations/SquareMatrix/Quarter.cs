namespace Algorithms.Tests.MatrixOperations.SquareMatrix;

using System;
using Xunit;

public class Quarter
{
    [Fact]
    public void Should_RejectSizeLessThanTwo()
    {
        var a = new TestMatrix(1);

        Assert.Throws<ArgumentOutOfRangeException>(() => a.Quarter());
    }

    [Fact]
    public void Should_SplitSize2MatrixIntoQuadrants()
    {
        TestMatrix q1, q2, q3, q4;
        var a = new TestMatrix(new int[] { 1, 2, 3, 4 });

        (q1, q2, q3, q4) =
            ((TestMatrix, TestMatrix, TestMatrix, TestMatrix))a.Quarter();

        Assert.Equal(new TestMatrix(new int[] { 1 }), q1);
        Assert.Equal(new TestMatrix(new int[] { 2 }), q2);
        Assert.Equal(new TestMatrix(new int[] { 3 }), q3);
        Assert.Equal(new TestMatrix(new int[] { 4 }), q4);
    }

    [Fact]
    public void Should_SplitSize4MatrixIntoQuadrants()
    {
        TestMatrix q1, q2, q3, q4;
        var a = new TestMatrix(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

        (q1, q2, q3, q4) =
            ((TestMatrix, TestMatrix, TestMatrix, TestMatrix))a.Quarter();

        Assert.Equal(new TestMatrix(new int[] { 1, 2, 5, 6 }), q1);
        Assert.Equal(new TestMatrix(new int[] { 3, 4, 7, 8 }), q2);
        Assert.Equal(new TestMatrix(new int[] { 9, 10, 13, 14 }), q3);
        Assert.Equal(new TestMatrix(new int[] { 11, 12, 15, 16 }), q4);
    }
}
