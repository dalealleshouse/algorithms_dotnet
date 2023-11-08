#nullable enable

namespace Algorithms.ListDataStructures;

using System;
using System.Linq;

public class Array<T>
{
    private T[] array;

    public Array(T[] array)
    {
        this.array = array;
    }

    public Array()
    {
        this.array = new T[0];
    }

    public T this[int index]
    {
        get
        {
            return this.array[index];
        }
    }

    public static implicit operator Array<T>(T[] arr)
    {
        return new Array<T>(arr);
    }

    public static implicit operator T[](Array<T> arr)
    {
        return arr.array;
    }

    public void InsertAtHead(T item)
    {
        if (item == null) throw new System.ArgumentNullException();

        T[] newArray = new T[this.array.Length + 1];
        newArray[0] = item;
        this.array.CopyTo(newArray, 1);
        this.array = newArray;
    }

    public void InsertAtTail(T item)
    {
        if (item == null) throw new System.ArgumentNullException();

        T[] newArray = new T[this.array.Length + 1];
        newArray[newArray.Length - 1] = item;
        this.array.CopyTo(newArray, 0);
        this.array = newArray;
    }

    public Maybe<ArrayResult> Search(Predicate<T> predicate)
    {
        if (predicate == null) throw new System.ArgumentNullException();

        var index = this.array.TakeWhile(x => !predicate(x)).Count();

        return (index == this.array.Length) ?
            Maybe<ArrayResult>.None :
            new(new(index, this.array[index]));
    }

    public void Enumerate(Action<T> action)
    {
        if (action == null) throw new System.ArgumentNullException();

        Array.ForEach(this.array, action);
    }

    public Maybe<ArrayResult> Max(Comparison<T> comparer)
    {
        if (comparer is null) throw new ArgumentNullException(nameof(comparer));

        if (this.array.Length == 0) return Maybe<ArrayResult>.None;

        var result = this.array
            .Select((value, index) => new { Value = value, Index = index })
            .Aggregate((a, b) =>
            {
                return comparer(a.Value, b.Value) > 0 ? a : b;
            });

        return new(new(result.Index, result.Value));
    }

    public Maybe<ArrayResult> Predecessor(T value, Comparison<T> comparer)
    {
        if (comparer is null) throw new ArgumentNullException(nameof(comparer));
        if (value is null) throw new ArgumentNullException(nameof(value));

        var result = Maybe<ArrayResult>.None;

        return this.array
            .Select((value, index) => new { Value = value, Index = index })
            .Aggregate(result, (acc, x) =>
            {
                if (comparer(x.Value, value) < 0)
                {
                    if (!acc.HasValue || comparer(x.Value, acc.Value.Item) > 0)
                    {
                        return new(new(x.Index, x.Value));
                    }
                }

                return acc;
            });
    }

    public Maybe<int> Rank(T value, Comparison<T> comparer)
    {
        if (comparer is null) throw new ArgumentNullException(nameof(comparer));
        if (value is null) throw new ArgumentNullException(nameof(value));

        var result = new Maybe<int>(0);

        return this.array
            .Aggregate(result, (acc, x) =>
            {
                return (comparer(x, value) < 0) ? new(acc.Value + 1) : acc;
            });
    }

    public readonly record struct ArrayResult(int Index, T Item);
}
