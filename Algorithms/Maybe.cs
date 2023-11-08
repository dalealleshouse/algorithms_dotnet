namespace Algorithms;

using System;

public struct Maybe<T>
{
    private readonly T? value;

    private readonly bool hasValue;

    public Maybe(T value)
        : this(value, true)
    {
    }

    private Maybe(T? value, bool hasValue)
    {
        this.value = value;
        this.hasValue = hasValue;
    }

    public static Maybe<T> None => new Maybe<T>(default, false);

    public T Value => this.hasValue && this.value != null ? this.value : throw new InvalidOperationException("Value is not set.");

    public bool HasValue => this.hasValue;
}
