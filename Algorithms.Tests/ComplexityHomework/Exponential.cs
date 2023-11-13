namespace Algorithms.Tests.ComplexityHomework;

using System;
using Xunit;

public class Exponential
{
    [Fact]
    public void ReturnNToTheNOfInput()
    {
        const int n = 5;
        var constant = new Algorithms.ComplexityHomework.Exponential();
        var result = constant.Calculate(n);
        Assert.Equal(Math.Pow(n, n), result);
    }
}
