namespace Algorithms.Tests.Soting;

using System;
using Algorithms.ListDataStructures;
using Xunit;

public static class TestHelpers
{
    public static void IsSorted<T>(RandomArray<T> sut)
      where T : IComparable<T>
    {
        var previous = sut[0];
        for (uint i = 1; i < sut.Length; i++)
        {
            var compareResult = sut.Comparer(previous, sut[i]);
            Assert.True(compareResult <= 0, $"Expected {previous} <= {sut[i]}");
            previous = sut[i];
        }
    }
}
