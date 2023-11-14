namespace Algorithms.Benchmarker.ListDataStructures;

using System;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;

[SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1401:FieldsMustBePrivate",
        Justification = "A protected field is required for the derived class.")]
[IterationCount(3)]
public abstract class Benchmarks
{
    protected readonly Random random = new Random();

    [Params(100, 1_000, 10_000)]
    public int N { get; set; }
}
