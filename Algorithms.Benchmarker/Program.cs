namespace Algorithms.Benchmarker
{
    using Algorithms.Benchmarker.Configuration;
    using Algorithms.Benchmarker.MatrixOperations;

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
}
