namespace Algorithms.Benchmarker.ListDataStructures;

using Algorithms.ListDataStructures;
using BenchmarkDotNet.Attributes;

[MarkdownExporter]
[RPlotExporter]
public class Lists : Benchmarks
{
    private IStructuredList<int> list;

    [Params(
        StructuredListType.RandomArray,
        StructuredListType.SortedArray,
        StructuredListType.LinkedList,
        StructuredListType.UnbalancedBinaryTree,
        StructuredListType.RedBlackTree)]
    public StructuredListType ListType { get; set; }

    [GlobalSetup]
    public void Setup() =>
      this.list = StructuredListFactory<int>.CreateList(this.ListType, ArrayGenerator.RawArray(this.N));

    [Benchmark]
    public IStructuredList<int> Insert()
    {
        var list = StructuredListFactory<int>.CreateList(this.ListType);

        for (int i = 0; i < this.N; i++) list.Insert(this.random.Next());

        return list;
    }

    [Benchmark]
    public IStructuredList<int> Enumerate()
    {
        var tally = 0;
        this.list.Enumerate(x => tally = tally + x);

        return this.list;
    }

    public IStructuredList<int> Rank()
    {
        for (int i = 0; i < this.N; i++) this.list.Rank(this.random.Next());

        return this.list;
    }

    [Benchmark]
    public IStructuredList<int> Max()
    {
        for (int i = 0; i < this.N; i++) this.list.Max();

        return this.list;
    }

    [Benchmark]
    public IStructuredList<int> Predecessor()
    {
        for (int i = 0; i < this.N; i++) this.list.Predecessor(this.random.Next());
        return this.list;
    }

    [Benchmark]
    public IStructuredList<int> Search()
    {
        for (int i = 0; i < this.N; i++) this.list.Search(i);

        return this.list;
    }

    [Benchmark]
    public IStructuredList<int> Delete()
    {
        for (int i = 0; i < this.N; i++) this.list.Delete(this.random.Next());
        return this.list;
    }
}
