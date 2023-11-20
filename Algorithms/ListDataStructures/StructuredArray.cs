namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1401:FieldsMustBePrivate",
        Justification = "A protected field is required for the derived class.")]
public abstract class StructuredArray<T> : IStructuredList<T>
    where T : notnull, IComparable<T>
{
    protected readonly Comparison<T> comparer;
    protected T[] array;

    public StructuredArray(T[] array, Comparison<T>? comparer = null)
    {
        this.array = array ?? throw new ArgumentNullException(nameof(array));
        this.comparer = comparer ?? Comparer<T>.Default.Compare;
    }

    public StructuredArray(Comparison<T>? comparer = null)
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

    public Comparison<T> Comparer => this.comparer;

    public T this[int index]
    {
        get
        {
            return this.array[index];
        }
    }

    public abstract void Insert(T item);

    public void Enumerate(Action<T> action)
    {
        if (action == null) throw new System.ArgumentNullException();

        Array.ForEach(this.array, action);
    }

    public abstract int Rank(T value);

    public Maybe<T> Max()
    {
        return this.ExtractArrayResult(this.ArrayMax());
    }

    public abstract Maybe<StructuredArrayResult<T>> ArrayMax();

    public Maybe<T> Predecessor(T value)
    {
        if (value == null) throw new System.ArgumentNullException();
        return this.ExtractArrayResult(this.ArrayPredecessor(value));
    }

    public abstract Maybe<StructuredArrayResult<T>> ArrayPredecessor(T value);

    public Maybe<T> Search(T value)
    {
        if (value == null) throw new System.ArgumentNullException();
        return this.ExtractArrayResult(this.ArraySearch(value));
    }

    public abstract Maybe<StructuredArrayResult<T>> ArraySearch(T value);

    private Maybe<T> ExtractArrayResult(Maybe<StructuredArrayResult<T>> result) => result.HasValue ?
            new(result.Value.Item) :
            Maybe<T>.None;
}
