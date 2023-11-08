namespace Algorithms.Tests.ListDataStructures.Array;

using System.Linq;
using Algorithms.ListDataStructures;

public static class SutFactory
{
    public static Array<int> IntArray(int size) =>
        new Array<int>(Enumerable.Range(0, size + 1).ToArray());
}
