namespace Algorithms.ComplexityHomework;

public class Exponential : IComplexity
{
    public ulong Calculate(int n)
    {
        return this.Loop(n);
    }

    private ulong Loop(int n, int depth = 0)
    {
        if (depth == n)
        {
            return 1;
        }

        ulong result = 0;
        for (int i = 0; i < n; i++)
        {
            result += this.Loop(n, depth + 1);
        }

        return result;
    }
}
