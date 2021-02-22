using Xunit;

namespace Algorithms.Tests.MatrixOperations.FixedSquareMatrix
{
    using Algorithms.MatrixOperations;

    public class Multiply
    {
        [Fact]
        public void Multiply_MatchesNaive()
        {
            TestHelpers.MultiplyMatchesNaive<FixedSquareMatrix>();
        }
    }
}
