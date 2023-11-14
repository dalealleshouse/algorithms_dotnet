namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1401:FieldsMustBePrivate",
        Justification = "A protected field is required for the derived class.")]
public abstract class Array<T>
    where T : notnull, IComparable<T>
{
    protected readonly Comparison<T> comparer;
    protected T[] array;

    public Array(T[] array, Comparison<T>? comparer = null)
    {
        this.array = array ?? throw new ArgumentNullException(nameof(array));
        this.comparer = comparer ?? Comparer<T>.Default.Compare;
    }

    public Array(Comparison<T>? comparer = null)
        : this(new T[0], comparer)
    {
    }

    public int Length
    {
        get
        {
            return this.array.Length;
        }
    }

    public T this[int index]
    {
        get
        {
            return this.array[index];
        }
    }

    public void Enumerate(Action<T> action)
    {
        if (action == null) throw new System.ArgumentNullException();

        Array.ForEach(this.array, action);
    }

    public abstract void Insert(T item);

    public abstract Maybe<ArrayResult> Search(T value);

    public abstract Maybe<ArrayResult> Max();

    public abstract Maybe<ArrayResult> Predecessor(T value);

    public abstract Maybe<int> Rank(T value);

    public readonly record struct ArrayResult(int Index, T Item);
}
