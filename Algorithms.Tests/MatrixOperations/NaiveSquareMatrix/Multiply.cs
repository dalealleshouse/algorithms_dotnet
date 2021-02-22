using Algorithms.MatrixOperations;
using System;
using Xunit;

namespace Algorithms.Tests.MatrixOperations.NaiveSquareMatrix
{
    public class Multiply
    {
        [Fact]
        public void Multiply_Overflow()
        {
            var a = new NaiveSquareMatrix<int>(
                    new int[] { int.MaxValue, 8, 3, 7 });
            var b = new NaiveSquareMatrix<int>(new int[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a * b);
        }


        [Fact]
        public void Multiply_HappyPath()
        {
            TestHelpers.MultiplyHappyPath<NaiveSquareMatrix<int>>();
        }
    }
}
