namespace Algorithms.Tests.ListDataStructures;

using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.ListDataStructures;

public static class SutFactory
{
    public static RandomArray<int> RandomArray(
            int size,
            Comparison<int> comparer = null) => comparer == null ?
            new(BuildArray(size)) :
            new(BuildArray(size), comparer);

    public static SortedArray<int> SortedArray(
            int size,
            Comparison<int> comparer = null) => comparer == null ?
            new(BuildArray(size)) :
            new(BuildAndSortArray(size, comparer), comparer);

    public static int[] BuildArray(int size) =>
        Enumerable.Range(0, size + 1).ToArray();

    public static int[] BuildAndSortArray(int size, Comparison<int> comparer)
    {
        var array = BuildArray(size);
        System.Array.Sort(array, comparer);
        return array;
    }

    public static void Validate<T>(this IEnumerable<IInvariantValidator<T>> validators)
        where T : notnull, IComparable<T>
    {
        foreach (var val in validators)
        {
            val.Validate();
        }
    }
}
