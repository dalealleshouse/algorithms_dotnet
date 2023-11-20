namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.ListDataStructures;

public abstract class ListTests
{
    public static IEnumerable<IStructuredList<T>> AllLists<T>(Comparison<T> comparer = null)
        where T : notnull, IComparable<T> => AllLists(new T[0], comparer);

    public static IEnumerable<IStructuredList<T>> AllLists<T>(
            T[] data,
            Comparison<T> comparer = null)
        where T : notnull, IComparable<T> => Enum.GetValues(typeof(StructuredListType))
            .Cast<StructuredListType>()
            .Where(t => t != StructuredListType.Invalid)
            .Select(listType => StructuredListFactory<T>.CreateList(listType, data, comparer));

    public static IInvariantValidator<T> CreateValidator<T>(IStructuredList<T> structuredList)
        where T : notnull, IComparable<T>
    {
        return structuredList switch
        {
            SortedArray<T> _ => new SortedArray.InvariantValidator<T>(structuredList),
            RandomArray<T> _ => new RandomArray.InvariantValidator<T>(structuredList),
            StructuredLinkedList<T> _ => new LinkedList.InvariantValidator<T>(structuredList),
            _ => throw new ArgumentException("Unsupported IStructuredList type.", nameof(structuredList)),
        };
    }

    public void RunTestOnAllLists<T>(
            Action<IStructuredList<T>> testAction,
            T[] array = null,
            Comparison<T> comparer = null)
        where T : notnull, IComparable<T>
    {
        if (array == null) array = new T[0];

        ListTests
            .AllLists<T>(array, comparer)
            .Select(sut =>
            {
                testAction(sut);
                return sut;
            })
            .Select(ListTests.CreateValidator)
            .Validate();
    }
}
