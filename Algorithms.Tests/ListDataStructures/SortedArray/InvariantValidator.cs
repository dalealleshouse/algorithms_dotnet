namespace Algorithms.Tests.ListDataStructures.SortedArray;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class InvariantValidator<T> : IInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    private readonly SortedArray<T> sut;

    public InvariantValidator(IStructuredList<T> sut)
    {
        this.sut = (SortedArray<T>)sut;
    }

    public void Validate()
    {
        this.ValidateSorting();
    }

    private void ValidateSorting()
    {
        if (this.sut.Length == 0) return;

        var previous = this.sut[0];

        for (int i = 1; i < this.sut.Length; i++)
        {
            var compare = this.sut.Comparer(previous, this.sut[i]);
            Assert.True(compare <= 0);
            previous = this.sut[i];
        }
    }
}
