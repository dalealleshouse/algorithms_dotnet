namespace Algorithms.ListDataStructures;

using System;

public static class UnwrapExtensionMethods
{
    public static Maybe<T> Unwrap<T>(this Maybe<StructuredLinkedList<T>.Node> node)
        where T : notnull, IComparable<T>
        => node.HasValue ? new(node.Value.Payload) : Maybe<T>.None;

    public static Maybe<T> Unwrap<T>(this Maybe<StructuredArrayResult<T>> result)
        where T : notnull, IComparable<T>
        => result.HasValue ? new(result.Value.Item) : Maybe<T>.None;

    public static Maybe<T> Unwrap<T>(this TreeNode<T> node)
        where T : notnull, IComparable<T>
        => !node.IsNull ? new(node.Payload) : Maybe<T>.None;
}
