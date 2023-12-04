namespace Algorithms.ListDataStructures;

using System;

public static class StructuredListFactory<T>
    where T : notnull, IComparable<T>
{
    public static IStructuredList<T> CreateList(
    StructuredListType listType,
    Comparison<T>? comparer = null) => CreateList(listType, new T[0], comparer);

    public static IStructuredList<T> CreateList(
    StructuredListType listType,
    T[] data,
    Comparison<T>? comparer = null) =>
    listType switch
    {
        StructuredListType.LinkedList => new StructuredLinkedList<T>(data, comparer),
        StructuredListType.SortedArray => new SortedArray<T>(data, comparer),
        StructuredListType.RandomArray => new RandomArray<T>(data, comparer),
        StructuredListType.UnbalancedBinaryTree => new UnbalancedBinaryTree<T>(data, comparer),
        _ => throw new ArgumentException(nameof(listType)),
    };
}
