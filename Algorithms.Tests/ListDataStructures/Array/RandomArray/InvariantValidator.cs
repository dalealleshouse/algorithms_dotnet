namespace Algorithms.Tests.ListDataStructures.RandomArray;

using System;
using Algorithms.ListDataStructures;

public class InvariantValidator<T> : IInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    private readonly RandomArray<T> sut;

    public InvariantValidator(IStructuredList<T> sut)
    {
        this.sut = (RandomArray<T>)sut;
    }

    public void Validate()
    {
        // No validation for RandomArray<T>
    }
}
