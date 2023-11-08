namespace Algorithms.Benchmarker.ListDataStructures;

using System;
using System.Linq;
using Algorithms.ListDataStructures;

public static class ArrayGenerator
{
    public static Array<int> Random(int size)
    {
        var rand = new Random();

        return Enumerable.Range(0, size - 1)
            .Select(r => rand.Next())
            .ToArray();
    }

    public static Array<int> Ordered(int size)
    {
        var rand = new Random();

        return Enumerable.Range(0, size - 1)
            .ToArray();
    }
}
