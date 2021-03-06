using System;
using System.Diagnostics;

namespace Algorithms.Benchmarker
{
    public static class ActionTimer
    {
        public static (T, TimeSpan) Time<T>(Func<T> action)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            T result = action();
            stopWatch.Stop();

            return (result, stopWatch.Elapsed);
        }
    }
}
