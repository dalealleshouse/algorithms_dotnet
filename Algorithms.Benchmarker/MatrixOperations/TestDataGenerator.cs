namespace Algorithms.Benchmarker.MatrixOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Algorithms.MatrixOperations;

    public static class TestDataGenerator
    {
        public static T CreateRandomMatrix<T>(int size)
            where T : SquareMatrix<long>
        {
            var rand = new Random();

            var data = Enumerable.Range(0, size * size)
                .Select(r => (long)rand.Next(100))
                .ToList();

            return (T)Activator.CreateInstance(typeof(T), data);
        }

        public static async Task<T> CreateMatrixAsync<T>(string fileUrl)
            where T : SquareMatrix<long>
        {
            if (string.IsNullOrWhiteSpace(fileUrl))
            {
                throw new ArgumentException(
                        $"'{nameof(fileUrl)}' cannot be null or whitespace.",
                        nameof(fileUrl));
            }

            var data = await ParseFileAsync(fileUrl);

            return MatrixFactory.CreateMatrix<T, long>(data);
        }

        private static async Task<IEnumerable<long>> ParseFileAsync(string path)
        {
            string matrix = await FileDownloader.DownloadFile(path);

            return matrix.Split('\n')
                .SelectMany(line => line.Split('\t')
                        .Where(value => long.TryParse(value, out long dummy))
                        .Select(long.Parse))
                .ToList();
        }
    }
}
