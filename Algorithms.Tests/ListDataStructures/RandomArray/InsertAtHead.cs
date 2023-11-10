namespace Algorithms.Tests.ListDataStructures.RandomArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class InsertAtHead
{
    [Fact]
    public void ThrowForNullInput()
    {
        var sut = new RandomArray<ComparableObject>();
        Assert.Throws<ArgumentNullException>(() => sut.InsertAtHead(null));
    }

    [Fact]
    public void InsertValueAtHeadOfArray()
    {
        const int max = 20;
        var sut = SutFactory.IntArray(max);
        sut.InsertAtHead(138);

        Assert.Equal(138, sut[0]);

        for (int i = 0; i < max; i++)
        {
            Assert.Equal(i, sut[i + 1]);
        }
    }
}
