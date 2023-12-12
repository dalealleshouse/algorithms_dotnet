namespace Algorithms.Tests.ListDataStructures;

using System;

public class ComparableObject : IComparable<ComparableObject>
{
    public ComparableObject(int value) => this.Value = value;

    public int Value { get; }

    public int CompareTo(ComparableObject other) => this.Value.CompareTo(other.Value);
}
