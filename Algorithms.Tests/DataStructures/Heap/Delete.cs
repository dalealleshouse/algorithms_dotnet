namespace Algorithms.Tests.DataStructures.Heap;

using System;
using Algorithms.DataStructures;
using Xunit;

public class Delete
{
    [Fact]
    public void RejectNull()
    {
        var sut = new Heap<object>((x, y) => -1, 10);
        Assert.Throws<ArgumentNullException>(() => sut.Delete(null));
    }

    [Fact]
    public void ThorwIfItemDoesNotExist()
    {
        var sut = SutFactory.MaxHeap(10, new int[] { 5, 10 });

        Assert.Throws<ArgumentException>(() => sut.Delete(15));
    }

    [Fact]
    public void Reprioritizes()
    {
        var data = new int[] { 25, 5, 15, 10, 20 };
        var sut = SutFactory.MaxHeap(10, data);

        sut.Delete(25);
        Assert.Equal(20, sut.Peek());
    }

    [Fact]
    public void DecrementsItemCount()
    {
        var data = new int[] { 25, 5, 15, 10, 20 };
        var n = data.Length;
        var sut = SutFactory.MaxHeap(10, data);

        Assert.Equal((uint)n, sut.ItemCount);

        for (var i = 0; i < n; i++)
        {
            Assert.Equal((uint)(n - i), sut.ItemCount);
            sut.Delete(data[i]);
        }

        Assert.Equal(0U, sut.ItemCount);
    }

    [Fact]
    public void DeletesOnlyOneOfDuplicate()
    {
        var data = new int[] { 25, 5, 5, 10 };
        var n = data.Length;
        var sut = SutFactory.MaxHeap(10, data);

        sut.Delete(5);
        Assert.Equal(3U, sut.ItemCount);

        Assert.Equal(25, sut.Extract());
        Assert.Equal(2U, sut.ItemCount);

        Assert.Equal(10, sut.Extract());
        Assert.Equal(1U, sut.ItemCount);

        Assert.Equal(5, sut.Extract());
        Assert.Equal(0U, sut.ItemCount);
    }
}
