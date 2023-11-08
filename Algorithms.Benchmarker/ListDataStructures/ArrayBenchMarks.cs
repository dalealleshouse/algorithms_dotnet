namespace Algorithms.Benchmarker.ListDataStructures;

using System;
using Algorithms.ListDataStructures;
using BenchmarkDotNet.Attributes;

[IterationCount(3)]
public class ArrayBenchmarks
{
    private readonly Random random = new Random();
    private Array<int> array;

    [Params(100, 1_000)]
    public int N { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        this.array = ArrayGenerator.Random(this.N);
    }

    [Benchmark]
    public Array<int> InsertAtHead()
    {
        var arr = new Array<int>();
        for (int i = 0; i < this.N; i++)
        {
            arr.InsertAtHead(i);
        }

        return arr;
    }

    [Benchmark]
    public Array<int> InsertAtTail()
    {
        var arr = new Array<int>();
        for (int i = 0; i < this.N; i++)
        {
            arr.InsertAtTail(i);
        }

        return arr;
    }

    [Benchmark]
    public Array<int> Search()
    {
        for (int i = 0; i < this.N; i++)
        {
            this.array.Search(x => x == this.random.Next());
        }

        return this.array;
    }
}
