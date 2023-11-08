namespace Algorithms.Benchmarker.MatrixOperations;

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Benchmarker.Configuration;
using Algorithms.MatrixOperations;

public static class Homework
{
    public static async Task ExerciseThreeAsync()
    {
        await MultiplyMatriciesAsync(
                AppConfig.Config.MatrixOperations.SmallMatrixAUrl,
                AppConfig.Config.MatrixOperations.SmallMatrixBUrl,
                1321619);

        await MultiplyMatriciesAsync(
                AppConfig.Config.MatrixOperations.LargeMatrixAUrl,
                AppConfig.Config.MatrixOperations.LargeMatrixBUrl,
                168345695003062);
    }

    private static async Task MultiplyMatriciesAsync(
            string matrixPath1,
            string matrixPath2,
            long expected)
    {
        var a = await TestDataGenerator.CreateMatrixAsync<FixedSquareMatrix>(matrixPath1);
        var b = await TestDataGenerator.CreateMatrixAsync<FixedSquareMatrix>(matrixPath2);

        (var result, var time) = ActionTimer.Time<SquareMatrix<long>>(
                () => a * b);

        var sum = result.Data.Sum();

        Console.WriteLine($"The sum all cell in the product of A and B = {sum}");
        Console.WriteLine($"Time = {time}");
        Debug.Assert(expected == sum, "Wrong Answer");
    }
}
