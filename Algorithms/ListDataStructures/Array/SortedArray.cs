#nullable enable

namespace Algorithms.ListDataStructures;

using System;
using System.Linq;
using Algorithms;

public class SortedArray<T> : StructuredArray<T>
    where T : notnull, IComparable<T>
{
    public SortedArray(T[] array, Comparison<T>? comparer = null)
        : base(array, comparer)
    {
        Array.Sort(this.array, this.comparer);
    }

    public SortedArray(Comparison<T>? comparer = null)
        : base(comparer)
    {
    }

    public static implicit operator T[](SortedArray<T> array) => array.array;

    public static implicit operator SortedArray<T>(T[] array) => new(array);

    public override void Insert(T item)
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

    public override Maybe<StructuredArrayResult<T>> ArraySearch(T value)
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

        return Maybe<StructuredArrayResult<T>>.None;
    }

    public override Maybe<StructuredArrayResult<T>> ArrayMax()
    {
        var maxIndex = this.Length - 1;

        return (maxIndex < 0) ?
            Maybe<StructuredArrayResult<T>>.None :
            new(new(maxIndex, this.array[maxIndex]));
    }

    public override Maybe<StructuredArrayResult<T>> ArrayPredecessor(T value)
    {
        if (value == null) throw new System.ArgumentNullException();
        if (this.Length == 0) return Maybe<StructuredArrayResult<T>>.None;

        int mid, start = 0;
        var end = this.Length - 1;
        var candiate = Maybe<int>.None;

        if (this.comparer(this.array[end], value) < 0) return new(new(end, this.array[end]));

        while (start <= end)
        {
            mid = (start + end) / 2;
            var compResult = this.comparer(this.array[mid], value);

            if (compResult == 0)
            {
                if (mid == 0) return Maybe<StructuredArrayResult<T>>.None;

                return new(new(mid - 1, this.array[mid - 1]));
            }
            else if (compResult > 0)
            {
                end = mid - 1;
            }
            else
            {
                candiate = new(mid);
                start = mid + 1;
            }
        }

        return candiate.HasValue ?
            new(new(candiate.Value, this.array[candiate.Value])) :
            Maybe<StructuredArrayResult<T>>.None;
    }

    public override int Rank(T value)
    {
        if (value == null) throw new System.ArgumentNullException();
        if (this.Length == 0) return 0;

        var mid = 0;
        var start = 0;
        var end = this.Length - 1;

        if (this.comparer(this.array[end], value) < 0) return this.Length;

        while (start <= end)
        {
            mid = (start + end) / 2;
            var compResult = this.comparer(this.array[mid], value);

            if (compResult == 0) return mid;
            else if (compResult > 0) end = mid - 1;
            else start = mid + 1;
        }

        return mid;
    }
}
