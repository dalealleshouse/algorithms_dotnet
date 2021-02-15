namespace Algorithms.Tests.MatrixOperations
{
    using System;
    using System.Net;
    using System.Diagnostics;
    using System.Linq;
    using Xunit;
    using Algorithms.MatrixOperations;

    public class Homework
    {
        const string MATRIX_ONE_FILE = "https://raw.githubusercontent.com/dalealleshouse/algorithms/master/src/matrix_operations/test_data/random_matrix_1.txt";
        const string MATRIX_TWO_FILE = "https://raw.githubusercontent.com/dalealleshouse/algorithms/master/src/matrix_operations/test_data/random_matrix_2.txt";

        private StrassenSquareMatrix<int> ReadFile(string path, int size)
        {
            WebClient wc = new WebClient();
            string matrix = wc.DownloadString(path);

            var data = matrix.Split('\n')
                .SelectMany(line => line
                        .Split('\t')
                        .Where(value => int.TryParse(value, out int dummy))
                        .Select(int.Parse))
                .ToList();

            return new StrassenSquareMatrix<int>(BinaryOps<int>.Int(), data);
        }

        [Fact (Skip = "Long Running")]
        public void Multiply_Overflow()
        {
            var a = ReadFile(MATRIX_ONE_FILE, 4096);
            var b = ReadFile(MATRIX_ONE_FILE, 4096);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = a * b;
            stopWatch.Stop();

            long sum = result.Data.Sum();
            System.Console.WriteLine(sum);
            Assert.Equal(168345695003062, sum);

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
