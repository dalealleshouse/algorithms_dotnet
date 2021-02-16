namespace Algorithms.Tests.MatrixOperations.NaiveSquareMatrix
{
    using System;
    using Xunit;
    using Algorithms.MatrixOperations;
    using System.Collections.Generic;

    public class Multiply
    {
        public NaiveSquareMatrix<int> SutFactory(IEnumerable<int> data)
        {
            return new NaiveSquareMatrix<int>(BinaryOps.Int, data);
        }


        [Fact]
        public void Multiply_Overflow()
        {
            var a = SutFactory(new int[] { int.MaxValue, 8, 3, 7 });
            var b = SutFactory(new int[] { 1, 0, 5, 2 });

            Assert.Throws<OverflowException>(() => a * b);
        }


        [Fact]
        public void Multiply_HappyPath()
        {
            var expected = SutFactory(new int[] { 38, 17, 26, 14 });
            var a = SutFactory(new int[] { 1, 7, 2, 4 });
            var b = SutFactory(new int[] { 3, 3, 5, 2 });

            var result = a * b;
            Assert.Equal(expected, result);
        }
    }
}
