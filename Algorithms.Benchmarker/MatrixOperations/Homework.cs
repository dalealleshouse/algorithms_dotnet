namespace Algorithms.Benchmarker.MatrixOperations
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Algorithms.Benchmarker.Configuration;
    using Algorithms.MatrixOperations;

    public static class Homework
    {
        private static void MultiplyMatricies(string matrixPath1,
                string matrixPath2, long expected)
        {
            var a = TestData.CreateMatrix<StrassenSquareMatrix<long>>(matrixPath1);
            var b = TestData.CreateMatrix<StrassenSquareMatrix<long>>(matrixPath2);

            (var result, var time) = ActionTimer.Time<SquareMatrix<long>>(
                    () => a * b);

            var sum = result.Data.Sum();

            Console.WriteLine($"The sum all cell in the product of A and B = {sum}");
            Console.WriteLine($"Time = {time}");
            Debug.Assert(expected == sum, "Wrong Answer");
        }

        public static void ExerciseThree()
        {
            MultiplyMatricies(
                    AppConfig.config.MatrixOperations.SmallMatrixAUrl,
                    AppConfig.config.MatrixOperations.SmallMatrixBUrl,
                    1321619);

            MultiplyMatricies(
                    AppConfig.config.MatrixOperations.LargeMatrixAUrl,
                    AppConfig.config.MatrixOperations.LargeMatrixBUrl,
                    168345695003062);
        }
    }
}
