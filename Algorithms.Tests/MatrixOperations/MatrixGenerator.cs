namespace Algorithms.Tests.MatrixOperations
{
    using System;
    using Algorithms.MatrixOperations;

    public static class MatrixGenerator
    {
        public static NaiveSquareMatrix<int> NaiveMatrixGenerator(int size)
        {
            var rand = new Random();

            var matrix = new NaiveSquareMatrix<int>(size, BinaryOps<int>.Int());
            for (var i = 0; i < size; i++)
            {

                for (var j = 0; j < size; j++)
                {
                    matrix[i, j] = rand.Next(50);
                }
            }
            return matrix;
        }
    }
}
