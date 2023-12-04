namespace Algorithms.ListDataStructures;

using System;

public class UnbalancedBinaryTree<T> : StructuredBinaryTree<T>
    where T : notnull, IComparable<T>
{
    public UnbalancedBinaryTree(T[] array, Comparison<T>? comparer = null)
      : base(array, comparer)
    {
    }

    public UnbalancedBinaryTree(Comparison<T>? comparer = null)
        : this(new T[0], comparer)
    {
    }
}
