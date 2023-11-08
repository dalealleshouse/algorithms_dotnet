namespace Algorithms.Benchmarker;

using Algorithms.Benchmarker.Configuration;

public class Program
{
    public static void Main(string[] args)
    {
        AppConfig.InitConfg();

        /* CompareRuntimes.CompareTimes(); */
        /* MatrixOperations.Homework.ExerciseThreeAsync().Wait(); */

        RunningMedian.Homework.ExerciseThreeAsync().Wait();
        RunningMedian.Homework.ExerciseFiveAsync().Wait();
    }
}
