using Algorithms.MatrixOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Algorithms.Benchmarker.MatrixOperations
{
    public static class TestDataGenerator
    {
        private static IEnumerable<long> ParseFile(string path)
        {
            WebClient wc = new WebClient();
            string matrix = wc.DownloadString(path);

            return matrix.Split('\n')
                .SelectMany(line => line.Split('\t')
                        .Where(value => long.TryParse(value, out long dummy))
                        .Select(long.Parse))
                .ToList();
        }

        public static T CreateRandomMatrix<T>(int size)
            where T : SquareMatrix<long>
        {
            var rand = new Random();

            var data = Enumerable.Range(0, size * size)
                .Select(r => (long)rand.Next(100))
                .ToList();

            return (T)Activator.CreateInstance(typeof(T), data);

        }

        public static T CreateMatrix<T>(string fileUrl)
            where T : SquareMatrix<long>
        {
            if (string.IsNullOrWhiteSpace(fileUrl))
                throw new ArgumentException(
                        $"'{nameof(fileUrl)}' cannot be null or whitespace.",
                        nameof(fileUrl));

            var data = ParseFile(fileUrl);
            return MatrixFactory.CreateMatrix<T, long>(data);
        }
    }
}
