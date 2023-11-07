namespace Algorithms.Benchmarker.RunningMedian
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Algorithms.Benchmarker.Configuration;

    public static class Homework
    {
        private const double EPSILON = .0000005;

        public static async Task<(double Sum, TimeSpan ElaspedTime)> GetSumAsync(uint slidingWindow)
        {
            var data = await ParseFile(AppConfig.Config.RunningMedian.ExerciseFileUrl);

            double sum = 0;
            var rm = new RunningMedian<double>(MinPriorityFunc, AverageFunc, slidingWindow);

            (_, var ts) = ActionTimer.Time(() =>
            {
                foreach (var item in data)
                {
                    rm.Track(item);
                    sum += rm.Median();
                }

                return sum;
            });

            return (sum, ts);
        }

        public static async Task ExerciseThreeAsync()
        {
            (var sum, var ts) = await GetSumAsync(0);
            Console.WriteLine($"The median sum is {sum}, completed in {ts}");

            Debug.Assert(Math.Abs(sum - 4995738.755804) <= EPSILON, "Wrong Answer");
        }

        public static async Task ExerciseFiveAsync()
        {
            (var sum, var ts) = await GetSumAsync(100);
            Console.WriteLine($"The median sum with a sliding window of 100 is {sum}, completed in {ts}");

            Debug.Assert(Math.Abs(sum - 4995205.397700) <= EPSILON, "Wrong Answer");
            var data = ParseFile(AppConfig.Config.RunningMedian.ExerciseFileUrl);
        }

        private static double AverageFunc(double x, double y) => (x + y) / 2;

        private static int MinPriorityFunc(double x, double y)
        {
            if (x == y) return 0;
            else if (y - x < 0) return -1;
            else return 1;
        }

        private static async Task<IEnumerable<double>> ParseFile(string path)
        {
            string data = await FileDownloader.DownloadFile(path);

            return data.Split('\n')
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .Select(double.Parse)
                .ToList();
        }
    }
}
