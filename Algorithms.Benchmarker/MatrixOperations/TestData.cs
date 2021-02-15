namespace Algorithms.Benchmarker.MatrixOperations
{
    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.Linq;
    using Algorithms.MatrixOperations;

    public static class TestData
    {
        private static IEnumerable<long> ParseFile(string path)
        {
            WebClient wc = new WebClient();
            string matrix = wc.DownloadString(path);

            return matrix.Split('\n')
                .SelectMany(line => line
                        .Split('\t')
                        .Where(value => long.TryParse(value, out long dummy))
                        .Select(long.Parse))
                .ToList();
        }

        public static T CreateMatrix<T>(int size)
            where T : SquareMatrix<long>
        {
            var rand = new Random();

            var data = Enumerable.Range(0, size * size)
                .Select(r => (long)rand.Next(100))
                .ToList();

            return (T)Activator.CreateInstance(typeof(T),
                    BinaryOps<long>.Long, data);
        }

        public static T CreateMatrix<T>(string fileUrl)
            where T : SquareMatrix<long>
        {
            if (string.IsNullOrWhiteSpace(fileUrl))
                throw new ArgumentException(
                        $"'{nameof(fileUrl)}' cannot be null or whitespace.",
                        nameof(fileUrl));

            return (T)Activator.CreateInstance(typeof(T),
                    BinaryOps<long>.Long, ParseFile(fileUrl));
        }
    }
}
