namespace Algorithms.Benchmarker
{
    using System;
    using System.Diagnostics;

    public static class ActionTimer
    {
        public static (T, string) Time<T>(Func<T> action)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            T result = action();
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string time = $"{ts.Minutes:00} {ts.Seconds:00}.{ts.Milliseconds / 10:00} sec";

            return (result, time);
        }
    }
}
