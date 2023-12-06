namespace Algorithms.ListDataStructures;

using System;

public static class ArrayExtensionMethods
{
    public static Maybe<T> Unwrap<T>(this Maybe<StructuredLinkedList<T>.Node> node)
        where T : notnull, IComparable<T>
        => node.HasValue ? new(node.Value.Payload) : Maybe<T>.None;

    public static Maybe<T> Unwrap<T>(this Maybe<StructuredArrayResult<T>> result)
        where T : notnull, IComparable<T>
        => result.HasValue ? new(result.Value.Item) : Maybe<T>.None;
}
