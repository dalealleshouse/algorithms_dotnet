namespace Algorithms.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Heap<T> 
        where T : notnull
    {
        private const uint INITSIZE = 50;

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
            this.data = new T[initialSize];
            this.itemLocator = new((int)initialSize);
        }

        public Heap(Priority priorityFunc) : this(priorityFunc, INITSIZE) { }

        /***************************************************************************************************************
         * Private Methods
         **************************************************************************************************************/
        private void Grow()
        {
            this.size = this.size * 2;
            Array.Resize(ref this.data, (int)this.size);
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
            T value = this.data[index];

            var indices = this.itemLocator[value];
            indices.Remove(index);

            // If the list is empty, clear out the dictonrary entry
            if (indices.Count == 0)
                this.itemLocator.Remove(value);

            this.data[index] = default(T);
            return value;
        }

        private void InsertDataItem(uint index, T value)
        {
            LinkedList<uint> indices;

            if (this.itemLocator.ContainsKey(value))
                indices = this.itemLocator[value];
            else
            {
                indices = new();
                this.itemLocator[value] = indices;
            }

            indices.AddFirst(index);
            this.data[index] = value;
        }

        private void Swap(uint x, uint y)
        {
            var xIndices = this.itemLocator[this.data[x]];
            var yIndices = this.itemLocator[this.data[y]];

            xIndices.Find(x).Value = y;
            yIndices.Find(y).Value = x;

            T temp = this.data[x];
            this.data[x] = this.data[y];
            this.data[y] = temp;
        }

        private void BubbleUp(uint index)
        {
            while (index > 0)
            {
                uint parent = this.ParentIndex(index);

                if (this.priorityFunc(this.data[index], this.data[parent]) <= 0) break;

                this.Swap(index, parent);
                index = parent;
            }
        }

        private uint GreatestChild(uint x)
        {
            if (x == this.itemCount - 1) return x;

            if (this.priorityFunc(this.data[x], this.data[x + 1]) >= 0) return x;
            return x + 1;
        }

        private void BubbleDown(uint start)
        {
            uint child;

            while ((child = this.ChildIndex(start)) < this.itemCount)
            {
                child = this.GreatestChild(child);
                if (this.priorityFunc(this.data[start], this.data[child]) > 0) return;

                this.Swap(start, child);
                start = child;
            }
        }

        private void Reprioritize(uint index)
        {
            // Index is the first item in queue, so it can only go down
            if (index == 0)
            {
                this.BubbleDown(index);
                return;
            }

            // Figure out if item has a higher priority than its parent
            uint parent = this.ParentIndex(index);
            if (this.priorityFunc(this.data[index], this.data[parent]) > 0)
                this.BubbleUp(index); // If it is greater, then bubble it up
            else
                this.BubbleDown(index); // The only other option is less so bubble it down

        }

        /***************************************************************************************************************
         * Public Methods
         **************************************************************************************************************/
        public uint ItemCount { get => this.itemCount; }

        public void Insert(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            if (this.itemCount == this.size) this.Grow();

            this.InsertDataItem(this.itemCount++, item);
            this.BubbleUp(this.itemCount - 1);
        }

        public void Delete(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            if (!this.itemLocator.ContainsKey(item)) throw new ArgumentException($"{nameof(item)} does not exist");

            uint index = this.itemLocator[item].First.Value;
            this.ClearDataItem(index);
            --this.itemCount;

            // No need to reprioritize becasue we just deleted the last item
            if (index == this.itemCount) return;

            T relocate = this.data[this.itemCount];
            this.ClearDataItem(this.itemCount);
            this.InsertDataItem(index, relocate);
            this.Reprioritize(index);
        }

        public T Extract()
        {
            if (this.itemCount == 0) throw new InvalidOperationException("Heap is empty");

            T returnValue = this.data[0];
            this.ClearDataItem(0);
            --this.itemCount;

            if (this.itemCount == 0) return returnValue;

            T relocate = this.data[this.itemCount];
            this.ClearDataItem(this.itemCount);
            this.InsertDataItem(0, relocate);
            if (this.itemCount == 1) return returnValue;

            this.BubbleDown(0);
            return returnValue;
        }

        public void Reprioritize(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            if (!this.itemLocator.ContainsKey(item)) throw new ArgumentException("Item does not exist");

            var indices = this.itemLocator[item];

            if (indices.Count == 1)
            {
                this.Reprioritize(indices.First.Value);
                return;
            }

            // If there is more than one, they have to prioritized in order
            var sorted = new List<uint>(this.itemLocator[item]);
            sorted.Sort();
            sorted.ForEach(this.Reprioritize);
        }

        public T Peek()
        {
            if (this.itemCount == 0) throw new InvalidOperationException("Heap is empty");

            return this.data[0];
        }

        public bool Exists(T item)
        {
            if (item == null) throw new System.ArgumentNullException(nameof(item));
            return this.itemLocator.ContainsKey(item);
        }

        public override string ToString()
        {
            return this.data
                .Aggregate(new StringBuilder(), (sb, i) => sb.Append($"{i}-"))
                .ToString();
        }
    }
}
