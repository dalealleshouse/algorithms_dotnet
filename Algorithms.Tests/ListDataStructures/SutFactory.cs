namespace Algorithms.Tests.ListDataStructures;

using System;
using System.Linq;
using Algorithms.ListDataStructures;

public static class SutFactory
{
    private static readonly Random Rand = new();

    public static RandomArray<int> RandomArray(
            int size,
            Comparison<int> comparer = null) => comparer == null ?
            new(BuildArray(size)) :
            new(BuildArray(size), comparer);

    public static SortedArray<int> SortedArray(
            int size,
            Comparison<int> comparer = null) => comparer == null ?
            new(BuildArray(size)) :
            new(BuildArray(size), comparer, true);

    public static int[] BuildArray(int size) =>
        Enumerable.Range(0, size + 1).ToArray();

    public static int[] UnorderedArray(int size) =>
        Enumerable.Range(0, size + 1).Select(x => Rand.Next()).ToArray();
}
