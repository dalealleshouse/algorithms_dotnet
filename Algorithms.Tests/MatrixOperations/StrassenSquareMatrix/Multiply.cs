namespace Algorithms.Tests.MatrixOperations.StrassenSquareMatrix;

using System;
using Algorithms.MatrixOperations;
using Xunit;

public class Multiply
{
    [Fact]
    public void Multiply_Overflow()
    {
        var a = new StrassenSquareMatrix<int>(
                new int[] { int.MaxValue, 8, 3, 7 });
        var b = new StrassenSquareMatrix<int>(
                new int[] { 1, 0, 5, 2 });

        Assert.Throws<OverflowException>(() => a * b);
    }

    [Fact]
    public void Multiply_HappyPath()
    {
        TestHelpers.MultiplyHappyPath<StrassenSquareMatrix<int>>();
    }

    [Fact]
    public void Multiply_MatchesNaive()
    {
        TestHelpers.MultiplyMatchesNaive<StrassenSquareMatrix<long>>();
    }
}
