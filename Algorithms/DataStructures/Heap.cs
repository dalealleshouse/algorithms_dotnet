namespace Algorithms.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Heap<T> where T : notnull
    {
        private const uint INIT_SIZE = 50;

        private readonly Priority priorityFunc;
        // The linked list accounts for duplicate values
        private Dictionary<T, LinkedList<uint>> itemLocator;
        private uint size;
        private uint itemCount = 0;
        private T[] data;

        public delegate int Priority(T x, T y);

        public Heap(Priority priorityFunc, uint initialSize)
        {
            this.priorityFunc = priorityFunc ?? throw new ArgumentNullException(nameof(priorityFunc));
            if (initialSize <= 0) throw new ArgumentOutOfRangeException(nameof(initialSize));
            this.size = initialSize;
            data = new T[initialSize];
            itemLocator = new((int)initialSize);
        }

        public Heap(Priority priorityFunc) : this(priorityFunc, INIT_SIZE) { }

        /***************************************************************************************************************
         * Private Methods
         **************************************************************************************************************/
        private void Grow()
        {
            size = size * 2;
            Array.Resize(ref data, (int)size);
        }

        private uint ParentIndex(uint index)
        {
            index = ++index >> 1;
            return index - 1;
        }

        private uint ChildIndex(uint index)
        {
            index = ++index << 1;
            return index - 1;
        }

        private T ClearDataItem(uint index)
        {
            T value = data[index];

            var indices = itemLocator[value];
            indices.Remove(index);

            // If the list is empty, clear out the dictonrary entry
            if (indices.Count == 0)
                itemLocator.Remove(value);

            data[index] = default(T);
            return value;
        }

        private void InsertDataItem(uint index, T value)
        {
            LinkedList<uint> indices;

            if (itemLocator.ContainsKey(value))
                indices = itemLocator[value];
            else
            {
                indices = new();
                itemLocator[value] = indices;
            }

            indices.AddFirst(index);
            data[index] = value;
        }

        private void Swap(uint x, uint y)
        {
            var xIndices = itemLocator[data[x]];
            var yIndices = itemLocator[data[y]];

            xIndices.Find(x).Value = y;
            yIndices.Find(y).Value = x;

            T temp = data[x];
            data[x] = data[y];
            data[y] = temp;
        }

        private void BubbleUp(uint index)
        {
            while (index > 0)
            {
                uint parent = ParentIndex(index);

                if (priorityFunc(data[index], data[parent]) <= 0) break;

                Swap(index, parent);
                index = parent;
            }
        }

        private uint GreatestChild(uint x)
        {
            if (x == itemCount - 1) return x;

            if (priorityFunc(data[x], data[x + 1]) >= 0) return x;
            return x + 1;
        }

        private void BubbleDown(uint start)
        {
            uint child;

            while ((child = ChildIndex(start)) < itemCount)
            {
                child = GreatestChild(child);
                if (priorityFunc(data[start], data[child]) > 0) return;

                Swap(start, child);
                start = child;
            }
        }

        private void Reprioritize(uint index)
        {
            // Index is the first item in queue, so it can only go down
            if (index == 0)
            {
                BubbleDown(index);
                return;
            }

            // Figure out if item has a higher priority than its parent
            uint parent = ParentIndex(index);
            if (priorityFunc(data[index], data[parent]) > 0)
                BubbleUp(index); // If it is greater, then bubble it up
            else
                BubbleDown(index); // The only other option is less so bubble it down

        }

        /***************************************************************************************************************
         * Public Methods
         **************************************************************************************************************/
        public uint ItemCount { get => itemCount; }

        public void Insert(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            if (itemCount == size) Grow();

            InsertDataItem(itemCount++, item);
            BubbleUp(itemCount - 1);
        }

        public void Delete(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            if (!itemLocator.ContainsKey(item)) throw new ArgumentException($"{nameof(item)} does not exist");

            uint index = itemLocator[item].First.Value;
            ClearDataItem(index);
            --itemCount;

            // No need to reprioritize becasue we just deleted the last item
            if (index == itemCount) return;

            T relocate = data[itemCount];
            ClearDataItem(itemCount);
            InsertDataItem(index, relocate);
            Reprioritize(index);
        }

        public T Extract()
        {
            if (itemCount == 0) throw new InvalidOperationException("Heap is empty");

            T returnValue = data[0];
            ClearDataItem(0);
            --itemCount;

            if (itemCount == 0) return returnValue;

            T relocate = data[itemCount];
            ClearDataItem(itemCount);
            InsertDataItem(0, relocate);
            if (itemCount == 1) return returnValue;

            BubbleDown(0);
            return returnValue;
        }

        public void Reprioritize(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            if (!itemLocator.ContainsKey(item)) throw new ArgumentException("Item does not exist");

            var indices = itemLocator[item];

            if (indices.Count == 1)
            {
                Reprioritize(indices.First.Value);
                return;
            }

            // If there is more than one, they have to prioritized in order
            var sorted = new List<uint>(itemLocator[item]);
            sorted.Sort();
            sorted.ForEach(Reprioritize);
        }

        public T Peek()
        {
            if (itemCount == 0) throw new InvalidOperationException("Heap is empty");

            return data[0];
        }

        public bool Exists(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            return itemLocator.ContainsKey(item);
        }

        public override string ToString()
        {
            return this.data
                .Aggregate(new StringBuilder(), (sb, i) => sb.Append($"{i}-"))
                .ToString();
        }
    }
}
