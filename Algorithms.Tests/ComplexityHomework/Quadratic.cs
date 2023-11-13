namespace Algorithms.Tests.ComplexityHomework;

using System;
using Xunit;

public class Quadratic
{
    [Fact]
    public void ReturnNSquaredOfInput()
    {
        const int n = 10000;
        var constant = new Algorithms.ComplexityHomework.Quadratic();
        var result = constant.Calculate(n);
        Assert.Equal(Math.Pow(n, 2), result);
    }
}
