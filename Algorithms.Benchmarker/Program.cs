namespace Algorithms.Benchmarker;

using Algorithms.Benchmarker.Configuration;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        AppConfig.InitConfg();

        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
