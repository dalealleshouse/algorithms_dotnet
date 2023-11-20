namespace Algorithms.ListDataStructures;

using System;

public interface IStructuredList<T>
    where T : notnull, IComparable<T>
{
    int Length { get; }

    Comparison<T> Comparer { get; }

    void Insert(T item);

    void Enumerate(Action<T> action);

    int Rank(T value);

    Maybe<T> Max();

    Maybe<T> Predecessor(T value);

    Maybe<T> Search(T value);
}
