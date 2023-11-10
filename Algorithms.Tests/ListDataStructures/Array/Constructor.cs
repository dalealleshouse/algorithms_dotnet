namespace Algorithms.Tests.ListDataStructures.Array;

using System;
using System.Linq;
using Algorithms;
using Algorithms.ListDataStructures;
using Xunit;

public class Constructor
{
    private ComparableStruct[] testData = new ComparableStruct[] { new(1), new(2), new(3) };

    [Fact]
    public void RejectNull()
    {
        Assert.Throws<ArgumentNullException>(() => new ArrayTest(null));
    }

    [Fact]
    public void UseDefaultComparer()
    {
        var sut = new ArrayTest(this.testData);

        var result = sut.Max();
        Assert.True(result.HasValue);
        Assert.Equal(3, result.Value.Item.Value);
    }

    [Fact]
    public void UseCustomComparer()
    {
        var sut = new ArrayTest(this.testData, (x, y) => y.CompareTo(x));

        var result = sut.Max();
        Assert.True(result.HasValue);
        Assert.Equal(1, result.Value.Item.Value);
    }

    private class ArrayTest : Array<ComparableStruct>
    {
        public ArrayTest(ComparableStruct[] array, Comparison<ComparableStruct> comparer = null)
            : base(array, comparer)
        {
        }

        public override Maybe<ArrayResult> Max()
        {
            if (this.array.Length == 0) return Maybe<ArrayResult>.None;

            var result = this.array
                .Select((value, index) => new { Value = value, Index = index })
                .Aggregate((a, b) =>
                {
                    return this.comparer(a.Value, b.Value) > 0 ? a : b;
                });

            return new(new(result.Index, result.Value));
        }

        public override Maybe<ArrayResult> Predecessor(ComparableStruct value)
        {
            throw new NotImplementedException();
        }

        public override Maybe<int> Rank(ComparableStruct value)
        {
            throw new NotImplementedException();
        }

        public override Maybe<ArrayResult> Search(ComparableStruct value)
        {
            throw new NotImplementedException();
        }
    }
}
