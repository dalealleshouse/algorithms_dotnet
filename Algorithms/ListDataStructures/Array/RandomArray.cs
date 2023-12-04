#nullable enable

namespace Algorithms.ListDataStructures;

using System;
using System.Linq;

public class RandomArray<T> : StructuredArray<T>
    where T : notnull, IComparable<T>
{
    public RandomArray(T[] array, Comparison<T>? comparer = null)
        : base(array, comparer)
    {
    }

    public RandomArray(Comparison<T>? comparer = null)
        : base(comparer)
    {
    }

    public static implicit operator T[](RandomArray<T> array) => array.array;

    public static implicit operator RandomArray<T>(T[] array) => new(array);

    public override void Insert(T item)
    {
        this.InsertAtHead(item);
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

    public override Maybe<StructuredArrayResult<T>> ArraySearch(T value)
    {
        if (value == null) throw new System.ArgumentNullException();
        return this.Search(x => x.CompareTo(value) == 0);
    }

    public Maybe<StructuredArrayResult<T>> Search(Predicate<T> predicate)
    {
        if (predicate == null) throw new System.ArgumentNullException();

        var index = this.array.TakeWhile(x => !predicate(x)).Count();

        return (index == this.array.Length) ?
            Maybe<StructuredArrayResult<T>>.None :
            new(new(index, this.array[index]));
    }

    public override Maybe<StructuredArrayResult<T>> ArrayMax()
    {
        if (this.array.Length == 0) return Maybe<StructuredArrayResult<T>>.None;

        var result = this.array
            .Select((value, index) => new { Value = value, Index = index })
            .Aggregate((a, b) =>
            {
                return this.comparer(a.Value, b.Value) > 0 ? a : b;
            });

        return new(new(result.Index, result.Value));
    }

    public override Maybe<StructuredArrayResult<T>> ArrayPredecessor(T value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));

        var result = Maybe<StructuredArrayResult<T>>.None;

        return this.array
            .Select((value, index) => new { Value = value, Index = index })
            .Aggregate(result, (acc, x) =>
            {
                if (this.comparer(x.Value, value) < 0)
                {
                    if (!acc.HasValue || this.comparer(x.Value, acc.Value.Item) > 0)
                    {
                        return new(new(x.Index, x.Value));
                    }
                }

                return acc;
            });
    }

    public override int Rank(T value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));

        var result = 0;

        return this.array
            .Aggregate(result, (acc, x) =>
            {
                return (this.comparer(x, value) < 0) ? acc + 1 : acc;
            });
    }
}
