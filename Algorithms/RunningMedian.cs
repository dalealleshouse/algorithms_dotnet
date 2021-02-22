namespace Algorithms
{
    using Algorithms.DataStructures;
    using System;
    using System.Collections.Generic;

    public class RunningMedian<T> where T : notnull
    {
        private const uint DEFAULTINITSIZE = 50;
        public delegate T Average(T x, T y);

        private readonly Heap<T>.Priority minPriorityFunc;
        private readonly Average averageFunc;
        private readonly uint slidingWindow;
        private readonly uint initalSize;
        private readonly Heap<T> maxHeap;
        private readonly Heap<T> minHeap;
        private uint itemCount = 0;
        private LinkedList<T> window = new ();

        // minPriorityFunc = priority function that prioritizes smaller values
        // averageFunc = calculates the average of two values
        public RunningMedian(Heap<T>.Priority minPriorityFunc, Average averageFunc, uint slidingWindow, uint initalSize)
        {
            this.minPriorityFunc = minPriorityFunc ?? throw new ArgumentNullException(nameof(minPriorityFunc));
            this.averageFunc = averageFunc ?? throw new ArgumentNullException(nameof(averageFunc));
            this.slidingWindow = slidingWindow;
            this.initalSize = initalSize;
            uint half = (uint)Math.Ceiling((decimal)(initalSize / 2));
            this.maxHeap = new Heap<T>((x, y) => minPriorityFunc(x, y) * -1, half);
            this.minHeap = new Heap<T>(minPriorityFunc, half);
        }

        public RunningMedian(Heap<T>.Priority minPriorityFunc, Average averageFunc, uint slidingWindow) :
            this(minPriorityFunc, averageFunc, slidingWindow, DEFAULTINITSIZE)
        {
        }

        public RunningMedian(Heap<T>.Priority minPriorityFunc, Average averageFunc) :
            this(minPriorityFunc, averageFunc, 0, DEFAULTINITSIZE)
        {
        }

        /***************************************************************************************************************
         * Private Members
         **************************************************************************************************************/
        private bool IsBalanced()
        {
            return (this.itemCount % 2 == 0)
                ? this.maxHeap.ItemCount == this.minHeap.ItemCount
                : Math.Abs((int)this.maxHeap.ItemCount - (int)this.minHeap.ItemCount) == 1;
        }

        private void BalanceHeaps()
        {
            while (!this.IsBalanced())
            {
                if (this.maxHeap.ItemCount > this.minHeap.ItemCount)
                    this.minHeap.Insert(this.maxHeap.Extract());
                else
                    this.maxHeap.Insert(this.minHeap.Extract());
            }
        }

        private void MaintainSlidingWindow(T value)
        {
            this.window.AddFirst(value);

            if (this.itemCount <= this.slidingWindow) return;
            var doomed = this.window.Last.Value;

            if (this.minPriorityFunc(doomed, this.maxHeap.Peek()) >= 0)
                this.maxHeap.Delete(doomed);
            else
                this.minHeap.Delete(doomed);

            this.window.RemoveLast();
            this.itemCount--;
        }

        /***************************************************************************************************************
         * Public Members
         **************************************************************************************************************/
        public uint ItemCount { get => this.itemCount; }

        public void Track(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (this.itemCount == 0)
            {
                // If no items exist, just put it on the lower heap
                this.maxHeap.Insert(value);
            }
            else
            {
                // Figure out which heap to push the new value on
                T mid = this.maxHeap.Peek();

                if (this.minPriorityFunc(value, mid) >= 0)
                    this.maxHeap.Insert(value);
                else
                    this.minHeap.Insert(value);
            }

            this.itemCount++;
            if (this.slidingWindow > 0) this.MaintainSlidingWindow(value);

            this.BalanceHeaps();
        }

        public T Median()
        {
            if (this.itemCount % 2 == 0)
                return this.averageFunc(this.minHeap.Peek(), this.maxHeap.Peek());

            if (this.minHeap.ItemCount > this.maxHeap.ItemCount)
                return this.minHeap.Peek();

            return this.maxHeap.Peek();
        }
    }
}
