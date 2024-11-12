using BenchmarkDotNet.Running;

namespace LazyEvaluation;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<FibLazyVsEager>();
    }
}