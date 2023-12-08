namespace Algorithms.Tests.ListDataStructures.ListInterface;

using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.ListDataStructures;
/* using Algorithms.Tests.ListDataStructures.RedBlackTree; */
using Algorithms.Tests.ListDataStructures.UnbalancedBinaryTree;

public abstract class ListTests
{
    protected void RunTestOnAllLists<T>(
            Action<IStructuredList<T>> testAction,
            T[] array = null,
            Comparison<T> comparer = null)
        where T : notnull, IComparable<T> => ListTests
            .AllLists<T>(array ?? new T[0], comparer)
            .Select(sut =>
            {
                testAction(sut);
                return sut;
            })
            .Select(ListTests.CreateValidator)
            .Validate();

    private static IEnumerable<IStructuredList<T>> AllLists<T>(Comparison<T> comparer = null)
        where T : notnull, IComparable<T> => AllLists(new T[0], comparer);

    private static IEnumerable<IStructuredList<T>> AllLists<T>(
            T[] data,
            Comparison<T> comparer = null)
        where T : notnull, IComparable<T> => Enum.GetValues(typeof(StructuredListType))
            .Cast<StructuredListType>()
            .Where(t => t != StructuredListType.Invalid)
            .Select(listType => StructuredListFactory<T>.CreateList(listType, data, comparer));

    private static IInvariantValidator<T> CreateValidator<T>(IStructuredList<T> structuredList)
        where T : notnull, IComparable<T> => structuredList switch
        {
            SortedArray<T> _ => new SortedArray.InvariantValidator<T>(structuredList),
            RandomArray<T> _ => new RandomArray.InvariantValidator<T>(structuredList),
            StructuredLinkedList<T> _ => new LinkedList.InvariantValidator<T>(structuredList),
            UnbalancedBinaryTree<T> _ => new UnbalancedBinaryTreeInvariantValidator<T>(structuredList),
            /* RedBlackTree<T> _ => new RedBlackTreeInvariantValidator<T>(structuredList), */
            _ => throw new ArgumentException("Unsupported IStructuredList type.", nameof(structuredList)),
        };
}
