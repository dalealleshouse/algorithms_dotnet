namespace Algorithms.Benchmarker.MatrixOperations
{
    using System;
    using Algorithms.MatrixOperations;

    public class CompareRuntimes
    {
        public static void CompareTimes()
        {
            const int size = 1024;
            TimeSpan ts;

            SquareMatrix<long> a = TestDataGenerator
                .CreateMatrix<NaiveSquareMatrix<long>>(size);
            SquareMatrix<long> b = TestDataGenerator
                .CreateMatrix<NaiveSquareMatrix<long>>(size);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Naive {ts}");

            a = TestDataGenerator
                .CreateMatrix<TransposeSquareMatrix<long>>(a.Data);
            b = TestDataGenerator
                .CreateMatrix<TransposeSquareMatrix<long>>(b.Data);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Transpose {ts}");

            a = TestDataGenerator
                .CreateMatrix<RecursiveSquareMatrix<long>>(a.Data);
            b = TestDataGenerator
                .CreateMatrix<RecursiveSquareMatrix<long>>(b.Data);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Recursive {ts}");

            a = TestDataGenerator
                .CreateMatrix<StrassenSquareMatrix<long>>(a.Data);
            b = TestDataGenerator
                .CreateMatrix<StrassenSquareMatrix<long>>(b.Data);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Strassen {ts}");

            a = TestDataGenerator
                .CreateMatrix<FixedSquareMatrix>(a.Data);
            b = TestDataGenerator
                .CreateMatrix<FixedSquareMatrix>(b.Data);
            (_, ts) = ActionTimer.Time(() => a * b);
            Console.WriteLine($"Fixed Strassen {ts}");


        }
    }
}
