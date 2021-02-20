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
        private static decimal AverageFunc(decimal x, decimal y)
        {
            return (x + y) / 2;
        }

        private static int MinPriorityFunc(decimal x, decimal y)
        {
            if (x == y) return 0;
            else if (y - x < 0) return -1;
            else return 1;
        }

        private static IEnumerable<decimal> ParseFile(string path)
        {
            WebClient wc = new WebClient();
            string data = wc.DownloadString(path);

            return data.Split('\n')
                .Where(value => decimal.TryParse(value, out decimal dummy))
                .Select(decimal.Parse)
                .ToList();
        }

        public static void ExerciseThree()
        {
            var data = ParseFile(AppConfig.config.RunningMedian.ExerciseFileUrl);

            decimal sum = 0;
            var rm = new RunningMedian<decimal>(MinPriorityFunc, AverageFunc);
            foreach (var item in data){
                rm.Track(item);
                sum += rm.Median();
            }
            Console.WriteLine($"{sum}");
        }
    }
}
