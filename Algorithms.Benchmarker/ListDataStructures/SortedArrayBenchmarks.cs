namespace Algorithms.Benchmarker.ListDataStructures;

using Algorithms.ListDataStructures;
using BenchmarkDotNet.Attributes;

public class SortedArrayBenchmarks : Benchmarks
{
    private SortedArray<int> array;

    [GlobalSetup]
    public void Setup() => this.array = ArrayGenerator.Ordered(this.N);

    [Benchmark]
    public Array<int> Insert()
    {
        var arr = new SortedArray<int>();
        for (int i = 0; i < this.N; i++)
        {
            arr.Insert(i);
        }

        return arr;
    }

    [Benchmark]
    public Array<int> Search()
    {
        for (int i = 0; i < this.N; i++)
        {
            this.array.Search(this.random.Next());
        }

        return this.array;
    }

    [Benchmark]
    public Array<int> Max()
    {
        for (int i = 0; i < this.N; i++)
        {
            this.array.Max();
        }

        return this.array;
    }

    [Benchmark]
    public Array<int> Predecessor()
    {
        for (int i = 0; i < this.N; i++)
        {
            this.array.Predecessor(this.random.Next());
        }

        return this.array;
    }

    [Benchmark]
    public Array<int> Rank()
    {
        for (int i = 0; i < this.N; i++)
        {
            this.array.Rank(this.random.Next());
        }

        return this.array;
    }
}
