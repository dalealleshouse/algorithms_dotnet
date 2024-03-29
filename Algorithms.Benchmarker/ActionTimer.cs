namespace Algorithms.Benchmarker;

using System;
using System.Diagnostics;

public static class ActionTimer
{
    public static (T Result, TimeSpan RunTime) Time<T>(Func<T> action)
    {
        Stopwatch stopWatch = new Stopwatch();

        stopWatch.Start();
        T result = action();
        stopWatch.Stop();

        return (result, stopWatch.Elapsed);
    }
}
