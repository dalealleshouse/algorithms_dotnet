namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;

public class StructuredBinaryTree<T> : IStructuredList<T>
    where T : notnull, IComparable<T>
{
    private readonly Comparison<T> comparer;

    public StructuredBinaryTree(T[] array, Comparison<T>? comparer = null)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        Array.ForEach(array, x => this.Insert(x));

        this.comparer = comparer ?? Comparer<T>.Default.Compare;
    }

    public StructuredBinaryTree(Comparison<T>? comparer = null)
        : this(new T[0], comparer)
    {
    }

    public int Length => throw new NotImplementedException();

    public Comparison<T> Comparer => throw new NotImplementedException();

    public void Enumerate(Action<T> action)
    {
        throw new NotImplementedException();
    }

    public void Insert(T item)
    {
        throw new NotImplementedException();
    }

    public Maybe<T> Max()
    {
        throw new NotImplementedException();
    }

    public Maybe<T> Predecessor(T value)
    {
        throw new NotImplementedException();
    }

    public int Rank(T value)
    {
        throw new NotImplementedException();
    }

    public Maybe<T> Search(T value)
    {
        throw new NotImplementedException();
    }
}
