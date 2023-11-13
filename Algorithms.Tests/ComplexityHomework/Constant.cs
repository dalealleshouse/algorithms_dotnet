namespace Algorithms.Tests.ComplexityHomework;

using Xunit;

public class Constant
{
    [Fact]
    public void ReturnOneRegardlessOfInput()
    {
        var constant = new Algorithms.ComplexityHomework.Constant();
        var result = constant.Calculate(1000000);
        Assert.Equal(1U, result);
    }
}
