namespace Algorithms.Tests.ListDataStructures;

using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.ListDataStructures;

public static class SutFactory
{
    public static List<Algorithms.ListDataStructures.IList<T>> AllLists<T>(
            Comparison<T> comparer = null)
        where T : notnull, IComparable<T> => AllLists(new T[0], comparer);

    public static List<Algorithms.ListDataStructures.IList<T>> AllLists<T>(
            T[] data,
            Comparison<T> comparer = null)
        where T : notnull, IComparable<T> => Enum.GetValues(typeof(ListType))
            .Cast<ListType>()
            .Where(t => t != ListType.Invalid)
            .Select(listType => ListFactory<T>.CreateList(listType, data, comparer))
            .ToList();

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
}
