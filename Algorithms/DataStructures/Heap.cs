namespace Algorithms.DataStructures
{
    using System;
    using System.Collections.Generic;

    public class Heap<T> where T : notnull
    {
        private const uint INIT_SIZE = 50;

        private readonly Priority priorityFunc;
        private Dictionary<T, uint> itemLocator;
        private uint size;
        private uint itemCount = 0;
        private T[] data;

        public delegate int Priority(T x, T y);

        public Heap(Priority priorityFunc, uint initialSize)
        {
            this.priorityFunc = priorityFunc ?? throw new System.ArgumentNullException(nameof(priorityFunc));
            if (initialSize <= 0) throw new ArgumentOutOfRangeException(nameof(initialSize));
            this.size = initialSize;
            data = new T[initialSize];
            itemLocator = new Dictionary<T, uint>((int)initialSize);
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
            ++index;
            index = index >> 1;
            return index - 1;
        }

        private uint ChildIndex(uint index)
        {
            index++;
            index = index << 1;
            return index - 1;
        }

        private void SetDataItem(uint index, T value)
        {
            itemLocator[value] = index;
            data[index] = value;
        }

        private void Swap(uint x, uint y)
        {
            T temp = data[x];
            SetDataItem(x, data[y]);
            SetDataItem(y, temp);
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

        private uint GreatestPriority(uint x, uint y)
        {
            if (priorityFunc(data[x], data[y]) >= 0) return x;
            return y;
        }

        private void BubbleDown(uint start)
        {
            uint child;

            while ((child = ChildIndex(start)) < itemCount)
            {
                child = GreatestPriority(child, child + 1);
                if (priorityFunc(data[start], data[child]) >= 0) return;

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
            int comp_result = priorityFunc(data[index], data[parent]);

            if (comp_result > 0)
                BubbleUp(index); // If it is greater, then bubble it up
            else
                BubbleDown(index);// The only other option is less so bubble it down

        }

        /***************************************************************************************************************
         * Public Methods
         **************************************************************************************************************/
        public uint ItemCount { get => itemCount; }

        public void Insert(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            if (itemLocator.ContainsKey(item)) throw new InvalidOperationException("Duplicate items are not supported");

            if (itemCount == size) Grow();

            SetDataItem(itemCount++, item);
            BubbleUp(ItemCount - 1);
        }

        public void Delete(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            if (!itemLocator.ContainsKey(item)) throw new ArgumentException("Item does not exist");

            uint index;
            itemLocator.Remove(item, out index);
            --itemCount;

            SetDataItem(index, data[itemCount]);
            Reprioritize(index);
        }

        public T Extract()
        {
            if (itemCount == 0) throw new InvalidOperationException("Heap is empty");

            T returnValue = data[0];
            itemLocator.Remove(data[0]);
            --itemCount;

            SetDataItem(0, data[itemCount]);
            BubbleDown(0);
            return returnValue;
        }

        public void Reprioritize(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            if (!itemLocator.ContainsKey(item)) throw new ArgumentException("Item does not exist");

            var index = itemLocator[item];
            Reprioritize(index);
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
    }
}
