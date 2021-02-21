namespace Algorithms.Benchmarker.RunningMedian
{
    using Algorithms.Benchmarker.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;

    public static class Homework
    {
        private const double EPSILON = .0000005;

        private static double AverageFunc(double x, double y) => (x + y) / 2;

        private static int MinPriorityFunc(double x, double y)
        {
            if (x == y) return 0;
            else if (y - x < 0) return -1;
            else return 1;
        }

        private static IEnumerable<double> ParseFile(string path)
        {
            WebClient wc = new WebClient();
            string data = wc.DownloadString(path);

            return data.Split('\n')
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .Select(double.Parse)
                .ToList();
        }

        public static (double, TimeSpan) GetSum(uint slidingWindow)
        {
            var data = ParseFile(AppConfig.config.RunningMedian.ExerciseFileUrl);

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

        public static void ExerciseThree()
        {
            (var sum, var ts) = GetSum(0);
            Console.WriteLine($"The median sum is {sum}, completed in {ts}");

            Debug.Assert(Math.Abs(sum - 4995738.755804) <= EPSILON);
        }

        public static void ExerciseFive()
        {
            (var sum, var ts) = GetSum(100);
            Console.WriteLine($"The median sum with a sliding window of 100 is {sum}, completed in {ts}");

            Debug.Assert(Math.Abs(sum - 4995205.397700) <= EPSILON);
            var data = ParseFile(AppConfig.config.RunningMedian.ExerciseFileUrl);
        }
    }
}
