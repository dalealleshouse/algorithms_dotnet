namespace Algorithms.Tests.MatrixOperations.FixedSquareMatrix
{
    using Algorithms.MatrixOperations;
    using Xunit;

    public class Multiply
    {
        [Fact]
        public void Multiply_MatchesNaive()
        {
            TestHelpers.MultiplyMatchesNaive<FixedSquareMatrix>();
        }
    }
}
