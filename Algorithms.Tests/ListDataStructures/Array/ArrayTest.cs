namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using System.Linq;
using Algorithms;
using Algorithms.ListDataStructures;

public class ArrayTest<T> : StructuredArray<T>
    where T : notnull, IComparable<T>
{
    public ArrayTest()
        : base()
    {
    }

    public ArrayTest(T[] array, Comparison<T> comparer = null)
        : base(array, comparer)
    {
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

    public override void Insert(T item)
    {
        throw new NotImplementedException();
    }

    public override Maybe<StructuredArrayResult<T>> ArrayPredecessor(T value)
    {
        // For test purposes, return None for nullable values and a result for
        // non-nullable values.
        if (default(T) == null) return Maybe<StructuredArrayResult<T>>.None;

        return new(new(1, default));
    }

    public override int Rank(T value)
    {
        throw new NotImplementedException();
    }

    public override Maybe<StructuredArrayResult<T>> ArraySearch(T value)
    {
        // For test purposes, return None for nullable values and a result for
        // non-nullable values.
        if (default(T) == null) return Maybe<StructuredArrayResult<T>>.None;

        return new(new(1, default));
    }
}
