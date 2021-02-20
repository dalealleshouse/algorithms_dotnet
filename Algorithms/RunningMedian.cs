namespace Algorithms
{
    using System;
    using Algorithms.DataStructures;

    public class RunningMedian<T>
        where T : notnull
    {
        public delegate T Average(T x, T y);

        private readonly Heap<T>.Priority minPriorityFunc;
        private readonly Average averageFunc;
        private readonly Heap<T> maxHeap;
        private readonly Heap<T> minHeap;
        private uint itemCount = 0;


        // minPriorityFunc = priority function that prioritizes smaller values
        // averageFunc = calculates the average of two values
        public RunningMedian(Heap<T>.Priority minPriorityFunc, Average averageFunc)
        {
            this.minPriorityFunc = minPriorityFunc ?? throw new ArgumentNullException(nameof(minPriorityFunc));
            this.averageFunc = averageFunc ?? throw new ArgumentNullException(nameof(averageFunc));

            this.maxHeap = new Heap<T>((x, y) => minPriorityFunc(x, y) * -1);
            this.minHeap = new Heap<T>(minPriorityFunc);
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

        /***************************************************************************************************************
         * Public Members
         **************************************************************************************************************/
        public uint ItemCount { get => itemCount; }

        public void Track(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            /* ResultCode result_code = ResizeHeapsIfNeeded(self); */

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
            BalanceHeaps();

            /* if (self->sliding_window > 0) */
            /* { */
            /*     result_code = MaintainSlidingWindow(self, val); */
            /*     if (result_code != kSuccess) goto fail; */
            /* } */
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
