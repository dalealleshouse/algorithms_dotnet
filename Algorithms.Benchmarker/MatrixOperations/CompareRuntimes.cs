namespace Algorithms.Benchmarker.MatrixOperations
{
    using Algorithms.MatrixOperations;
    using System;

    public class CompareRuntimes
    {
        public static void CompareTimes()
        {
            const int size = 1024;
            TimeSpan ts;

            SquareMatrix<long> a = TestDataGenerator
                .CreateRandomMatrix<NaiveSquareMatrix<long>>(size);
            SquareMatrix<long> b = TestDataGenerator
                .CreateRandomMatrix<NaiveSquareMatrix<long>>(size);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Naive {ts}");

            a = MatrixFactory
                .CreateMatrix<TransposeSquareMatrix<long>, long>(a.Data);
            b = MatrixFactory
                .CreateMatrix<TransposeSquareMatrix<long>, long>(b.Data);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Transpose {ts}");

            a = MatrixFactory
                .CreateMatrix<RecursiveSquareMatrix<long>, long>(a.Data);
            b = MatrixFactory
                .CreateMatrix<RecursiveSquareMatrix<long>, long>(b.Data);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Recursive {ts}");

            a = MatrixFactory
                .CreateMatrix<StrassenSquareMatrix<long>, long>(a.Data);
            b = MatrixFactory
                .CreateMatrix<StrassenSquareMatrix<long>, long>(b.Data);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Strassen {ts}");

            a = MatrixFactory
                .CreateMatrix<FixedSquareMatrix, long>(a.Data);
            b = MatrixFactory
                .CreateMatrix<FixedSquareMatrix, long>(b.Data);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Fixed Strassen {ts}");
        }
    }
}
