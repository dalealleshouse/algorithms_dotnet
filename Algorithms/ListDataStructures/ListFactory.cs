namespace Algorithms.ListDataStructures;

using System;

public static class ListFactory<T>
    where T : notnull, IComparable<T>
{
    public static IList<T> CreateList(
    ListType listType,
    Comparison<T>? comparer = null) => CreateList(listType, new T[0], comparer);

    public static IList<T> CreateList(
    ListType listType,
    T[] data,
    Comparison<T>? comparer = null) =>
    listType switch
    {
        ListType.LinkedList => new LinkedList<T>(data, comparer),
        ListType.SortedArray => new SortedArray<T>(data, comparer),
        ListType.RandomArray => new RandomArray<T>(data, comparer),
        _ => throw new ArgumentException(nameof(listType)),
    };
}
