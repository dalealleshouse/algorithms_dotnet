namespace Algorithms.Tests.Soting;

using Algorithms.ListDataStructures;
using Algorithms.Tests.ListDataStructures;
using Xunit;

public class SortAlgorithms
{
    private RandomArray<int> sut;

    public SortAlgorithms()
    {
        this.sut = new RandomArray<int>(SutFactory.UnorderedArray(100));
    }

    [Fact]
    public void BubbleSort()
    {
        this.sut.BubbleSort();
        TestHelpers.IsSorted(this.sut);
    }

    [Fact]
    public void InsertionSort()
    {
        this.sut.InsertionSort();
        TestHelpers.IsSorted(this.sut);
    }

    [Fact]
    public void SelectionSort()
    {
        this.sut.SelectionSort();
        TestHelpers.IsSorted(this.sut);
    }
}
