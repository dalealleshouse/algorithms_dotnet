namespace Algorithms.Tests.ListDataStructures;

using System;

public interface IInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    void Validate();
}
