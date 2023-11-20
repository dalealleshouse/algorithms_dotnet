namespace Algorithms.Tests.ListDataStructures.LinkedList;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public class InvariantValidator<T> : IInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    private readonly StructuredLinkedList<T> sut;

    public InvariantValidator(IStructuredList<T> sut)
    {
        this.sut = (StructuredLinkedList<T>)sut;
    }

    public void Validate()
    {
        /* if (sut.Length == 0) return; */

        /* var previous = sut[0]; */

        /* for (int i = 1; i < sut.Length; i++) */
        /* { */
        /*     var compare = sut.Comparer(previous, sut[i]); */
        /*     Assert.True(compare <= 0); */
        /*     previous = sut[i]; */
        /* } */
    }
}
