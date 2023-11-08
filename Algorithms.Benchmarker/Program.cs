namespace Algorithms.Benchmarker;

using Algorithms.Benchmarker.Configuration;
using Algorithms.Benchmarker.ListDataStructures;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        AppConfig.InitConfg();

        /* /1* CompareRuntimes.CompareTimes(); *1/ */
        /* /1* MatrixOperations.Homework.ExerciseThreeAsync().Wait(); *1/ */

        /* RunningMedian.Homework.ExerciseThreeAsync().Wait(); */
        /* RunningMedian.Homework.ExerciseFiveAsync().Wait(); */

        var summary = BenchmarkRunner.Run<ArrayBenchmarks>();
    }
}
