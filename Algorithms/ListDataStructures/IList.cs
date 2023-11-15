namespace Algorithms.ListDataStructures;

using System;

public interface IList<T>
    where T : notnull, IComparable<T>
{
    int Length { get; }

    void Insert(T item);

    void Enumerate(Action<T> action);

    Maybe<int> Rank(T value);

    Maybe<T> Max();

    Maybe<T> Predecessor(T value);

    Maybe<T> Search(T value);
}
