namespace Algorithms.Benchmarker
{
    using Algorithms.Benchmarker.Configuration;
    using Algorithms.Benchmarker.MatrixOperations;

    class Program
    {
        static void Main(string[] args)
        {
            AppConfig.InitConfg();

            Homework.ExerciseThree();
        }
    }
}
