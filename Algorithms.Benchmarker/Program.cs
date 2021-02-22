using Algorithms.Benchmarker.Configuration;
using Algorithms.Benchmarker.RunningMedian;

namespace Algorithms.Benchmarker
{
    class Program
    {
        static void Main(string[] args)
        {
            AppConfig.InitConfg();

            /* CompareRuntimes.CompareTimes(); */
            /* Homework.ExerciseThree(); */

            Homework.ExerciseThree();
            Homework.ExerciseFive();
        }
    }
}
