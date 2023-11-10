#nullable enable

namespace Algorithms.ListDataStructures;

using System;
using System.Linq;
using Algorithms;

public class SortedArray<T> : Array<T>
    where T : notnull, IComparable<T>
{
    public SortedArray(T[] array, Comparison<T>? comparer = null)
        : base(array, comparer)
    {
    }

    public SortedArray(Comparison<T>? comparer = null)
        : base(comparer)
    {
    }

    public static implicit operator T[](SortedArray<T> array) => array.array;

    public static implicit operator SortedArray<T>(T[] array) => new(array);

    public void Insert(T item)
    {
        if (item == null) throw new System.ArgumentNullException();

        var newArray = new T[this.array.Length + 1];
        var index = this.array
            .TakeWhile(x => x != null && this.comparer(x, item) < 0)
            .Count();

        newArray[index] = item;
        Array.Copy(this.array, 0, newArray, 0, index);
        Array.Copy(this.array, index, newArray, index + 1, this.array.Length - index);

        this.array = newArray;
    }

    public override Maybe<ArrayResult> Search(T value)
    {
        if (value == null) throw new System.ArgumentNullException();

        var start = 0;
        var end = this.Length - 1;

        while (start <= end)
        {
            var mid = (start + end) / 2;
            var compResult = this.comparer(this.array[mid], value);

            if (compResult == 0) return new(new(mid, this.array[mid]));
            else if (compResult > 0) end = mid - 1;
            else start = mid + 1;
        }

        return Maybe<ArrayResult>.None;
    }

    public override Maybe<ArrayResult> Max()
    {
        var maxIndex = this.Length - 1;

        return (maxIndex < 0) ?
            Maybe<ArrayResult>.None :
            new(new(maxIndex, this.array[maxIndex]));
    }

    public override Maybe<ArrayResult> Predecessor(T value)
    {
        if (value == null) throw new System.ArgumentNullException();

        var searchResult = this.Search(value);
        return searchResult.HasValue ?
            new(new(searchResult.Value.Index - 1, this.array[searchResult.Value.Index - 1])) :
            Maybe<ArrayResult>.None;
    }

    public override Maybe<int> Rank(T value)
    {
        if (value == null) throw new System.ArgumentNullException();

        var mid = 0;
        var start = 0;
        var end = this.Length - 1;

        if (this.comparer(this.array[end], value) < 0) return new(this.Length);

        while (start <= end)
        {
            mid = (start + end) / 2;
            var compResult = this.comparer(this.array[mid], value);

            if (compResult == 0) return new(mid);
            else if (compResult > 0) end = mid - 1;
            else start = mid + 1;
        }

        return new(mid);
    }
}
