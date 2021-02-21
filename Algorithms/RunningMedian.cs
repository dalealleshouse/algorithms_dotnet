namespace Algorithms
{
    using Algorithms.DataStructures;
    using System;
    using System.Collections.Generic;

    public class RunningMedian<T> where T : notnull
    {
        private const uint DEFAULT_INIT_SIZE = 50;
        public delegate T Average(T x, T y);

        private readonly Heap<T>.Priority minPriorityFunc;
        private readonly Average averageFunc;
        private readonly uint slidingWindow;
        private readonly uint initalSize;
        private readonly Heap<T> maxHeap;
        private readonly Heap<T> minHeap;
        private uint itemCount = 0;
        private LinkedList<T> window = new();


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
            this(minPriorityFunc, averageFunc, slidingWindow, DEFAULT_INIT_SIZE)
        {
        }

        public RunningMedian(Heap<T>.Priority minPriorityFunc, Average averageFunc) :
            this(minPriorityFunc, averageFunc, 0, DEFAULT_INIT_SIZE)
        {
        }

        /***************************************************************************************************************
         * Private Members
         **************************************************************************************************************/
        private bool IsBalanced()
        {
            return (itemCount % 2 == 0)
                ? maxHeap.ItemCount == minHeap.ItemCount
                : Math.Abs((int)maxHeap.ItemCount - (int)minHeap.ItemCount) == 1;
        }

        private void BalanceHeaps()
        {
            while (!IsBalanced())
            {
                if (maxHeap.ItemCount > minHeap.ItemCount)
                    minHeap.Insert(maxHeap.Extract());
                else
                    maxHeap.Insert(minHeap.Extract());
            }
        }

        private void MaintainSlidingWindow(T value)
        {
            window.AddFirst(value);

            if (itemCount <= slidingWindow) return;
            var doomed = window.Last.Value;

            if (minPriorityFunc(doomed, maxHeap.Peek()) >= 0)
                maxHeap.Delete(doomed);
            else
                minHeap.Delete(doomed);

            window.RemoveLast();
            itemCount--;
        }

        /***************************************************************************************************************
         * Public Members
         **************************************************************************************************************/
        public uint ItemCount { get => itemCount; }

        public void Track(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (itemCount == 0)
            {
                // If no items exist, just put it on the lower heap
                maxHeap.Insert(value);
            }
            else
            {
                // Figure out which heap to push the new value on
                T mid = maxHeap.Peek();

                if (minPriorityFunc(value, mid) >= 0)
                    maxHeap.Insert(value);
                else
                    minHeap.Insert(value);
            }

            itemCount++;
            if (slidingWindow > 0) MaintainSlidingWindow(value);

            BalanceHeaps();
        }

        public T Median()
        {
            if (itemCount % 2 == 0)
                return averageFunc(minHeap.Peek(), maxHeap.Peek());

            if (minHeap.ItemCount > maxHeap.ItemCount)
                return minHeap.Peek();

            return maxHeap.Peek();
        }
    }
}
