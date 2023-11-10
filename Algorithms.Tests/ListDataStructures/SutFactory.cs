namespace Algorithms.Tests.ListDataStructures;

using System;
using System.Linq;
using Algorithms.ListDataStructures;

public static class SutFactory
{
    public static RandomArray<int> IntArray(
            int size,
            Comparison<int> comparer = null) => comparer == null ?
            new(BuildArray(size)) :
            new(BuildArray(size), comparer);

    public static SortedArray<int> SortedIntArray(
            int size,
            Comparison<int> comparer = null) => comparer == null ?
            new(BuildArray(size)) :
            new(BuildAndSortArray(size, comparer), comparer);

    private static int[] BuildArray(int size) =>
        Enumerable.Range(0, size + 1).ToArray();

    private static int[] BuildAndSortArray(int size, Comparison<int> comparer)
    {
        var array = BuildArray(size);
        System.Array.Sort(array, comparer);
        return array;
    }
}
