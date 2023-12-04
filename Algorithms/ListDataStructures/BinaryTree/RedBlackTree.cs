namespace Algorithms.ListDataStructures;

using System;

public class RedBlackTree<T> : StructuredBinaryTree<T>
    where T : notnull, IComparable<T>
{
    public RedBlackTree(T[] array, Comparison<T>? comparer = null)
      : base(array, comparer)
    {
    }

    public RedBlackTree(Comparison<T>? comparer = null)
        : this(new T[0], comparer)
    {
    }
}
