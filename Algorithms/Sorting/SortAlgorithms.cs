using System;
using Algorithms.ListDataStructures;

public static class SortAlgorithms
{
    public static void BubbleSort<T>(this RandomArray<T> list)
      where T : IComparable<T>
    {
        var sorted = false;
        var unsortedLength = list.Length - 2;

        while (!sorted)
        {
            sorted = true;
            for (uint i = 0; i <= unsortedLength; i++)
            {
                if (list[i].CompareTo(list[i + 1]) > 0)
                {
                    list.Swap(i, i + 1);
                    sorted = false;
                }
            }
        }
    }

    public static void Swap<T>(this RandomArray<T> list, uint index1, uint index2)
      where T : IComparable<T>
    {
        if (index1 >= list.Length || index2 >= list.Length)
            throw new IndexOutOfRangeException();

        var temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}
