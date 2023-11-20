namespace Algorithms.Tests.ListDataStructures;

using System;
using Algorithms.ListDataStructures;

public static class InvariantValidatorFactory
{
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
}
