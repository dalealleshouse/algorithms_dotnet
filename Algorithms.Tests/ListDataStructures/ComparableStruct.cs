namespace Algorithms.Tests.ListDataStructures;

using System;

public readonly record struct ComparableStruct(int Value) : IComparable<ComparableStruct>
{
    public int CompareTo(ComparableStruct other) => this.Value.CompareTo(other.Value);
}
