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

    public static void InsertionSort<T>(this RandomArray<T> list)
      where T : IComparable<T>
    {
        for (uint i = 1; i < list.Length; i++)
        {
            var openIndex = i;
            var temp = list[i];

            for (uint j = i - 1; true; j--)
            {
                if (list.Comparer(temp, list[j]) < 0)
                {
                    list[openIndex] = list[j];
                    openIndex--;
                }
                else
                {
                    break;
                }

                if (j == 0) break;
            }

            list[openIndex] = temp;
        }
    }

    public static void SelectionSort<T>(this RandomArray<T> list)
      where T : IComparable<T>
    {
        for (uint i = 0; i < list.Length; i++)
        {
            var minIndex = i;

            for (uint j = i + 1; j < list.Length; j++)
            {
                if (list.Comparer(list[j], list[minIndex]) < 0)
                    minIndex = j;
            }

            list.Swap(i, minIndex);
        }
    }

    public static SortedArray<T> MergeSort<T>(this RandomArray<T> list)
      where T : IComparable<T>
    {
        /* return list.MergeSort(0, list.Length - 1); */
        throw new NotImplementedException();
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
