namespace Algorithms.Tests.ListDataStructures.RandomArray;

using Algorithms.ListDataStructures;
using Xunit;

public class Predecessor
{
    [Fact]
    public void ReturnPredecessor()
    {
        var expected = new StructuredArrayResult<int>(137, 137);
        var sut = SutFactory.RandomArray(200);
        var result = sut.ArrayPredecessor(138);

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnPredecessorWithRandom()
    {
        var expected = new StructuredArrayResult<char>(5, 'c');
        var sut = new RandomArray<char>(
                new[] { 'a', 'h', 'f', 'd', 'e', 'c', 'g', 'b' },
                (x, y) => x.CompareTo(y));
        var result = sut.ArrayPredecessor('d');

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnFirstPredecessorWithRandom()
    {
        var expected = new StructuredArrayResult<char>(1, 'c');
        var sut = new RandomArray<char>(
                new[] { 'a', 'c', 'f', 'd', 'e', 'c', 'g', 'c' },
                (x, y) => x.CompareTo(y));
        var result = sut.ArrayPredecessor('d');

        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void ReturnPredecessorWithReverseCompare()
    {
        var expected = new StructuredArrayResult<int>(139, 139);
        var sut = SutFactory.RandomArray(200, (x, y) => y.CompareTo(x));
        var result = sut.ArrayPredecessor(138);

        Assert.Equal(expected, result.Value);
    }
}
