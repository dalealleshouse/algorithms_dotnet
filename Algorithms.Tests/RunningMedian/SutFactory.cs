namespace Algorithms.Tests.RunningMedian
{
    using Algorithms;

    public static class SutFactory
    {
        public static RunningMedian<int> Create()
        {
            return new RunningMedian<int>((x, y) => y - x, (x, y) => (x + y) / 2);
        }
    }
}
