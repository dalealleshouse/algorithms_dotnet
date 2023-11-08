namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class InsertAtHead
{
    [Fact]
    public void RejectNull()
    {
        var sut = new Array<object>();
        Assert.Throws<ArgumentNullException>(() => sut.InsertAtHead(null));

        var sut2 = new Array<int>();
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
