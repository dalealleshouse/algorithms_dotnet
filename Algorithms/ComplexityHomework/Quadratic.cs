namespace Algorithms.ComplexityHomework;

public class Quadratic : IComplexity
{
    public ulong Calculate(int n)
    {
        uint result = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result++;
            }
        }

        return result;
    }
}
