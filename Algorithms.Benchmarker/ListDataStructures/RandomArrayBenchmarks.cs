namespace Algorithms.Benchmarker.ListDataStructures;

using Algorithms.ListDataStructures;
using BenchmarkDotNet.Attributes;

public class RandomArrayBenchmarks : Benchmarks
{
    private RandomArray<int> array;

    [GlobalSetup]
    public void Setup() => this.array = ArrayGenerator.Random(this.N);

    [Benchmark]
    public StructuredArray<int> Insert()
    {
        var arr = new RandomArray<int>();
        for (int i = 0; i < this.N; i++)
        {
            arr.InsertAtHead(i);
        }

        return arr;
    }

    [Benchmark]
    public StructuredArray<int> Search()
    {
        for (int i = 0; i < this.N; i++)
        {
            this.array.Search(x => x == this.random.Next());
        }

        return this.array;
    }

    [Benchmark]
    public StructuredArray<int> Max()
    {
        for (int i = 0; i < this.N; i++)
        {
            this.array.Max();
        }

        return this.array;
    }

    [Benchmark]
    public StructuredArray<int> Predecessor()
    {
        for (int i = 0; i < this.N; i++)
        {
            this.array.Predecessor(this.random.Next());
        }

        return this.array;
    }

    [Benchmark]
    public StructuredArray<int> Rank()
    {
        for (int i = 0; i < this.N; i++)
        {
            this.array.Rank(this.random.Next());
        }

        return this.array;
    }
}
