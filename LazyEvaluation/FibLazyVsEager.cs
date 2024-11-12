using BenchmarkDotNet.Attributes;

namespace LazyEvaluation;

[RPlotExporter]
public class FibLazyVsEager
{
    [Params(10, 10000, 10000000)]
    public int N = 10;
        
    // benchmark methods
    [Benchmark]
    public void BenchLazy()
    {
        var x = FibLazy().Take(N);
    }
        
    [Benchmark]
    public void BenchEager()
    {
        var x = FibEager(N);
    }

    // Lazy evaluation
    private IEnumerable<int> FibLazy()
    {
        var prev = -1;
        var next = 1;
        while (true)
        {
            var sum = prev + next;
            prev = next;
            next = sum;
            yield return sum;
        }
    }

    // Eager evaluation
    private List<int> FibEager(int x)
    {
        var prev = -1;
        var next = 1;
        var result = new List<int>();
        for (var i = 0; i < x; i++)
        {
            var sum = prev + next;
            prev = next;
            next = sum;
            result.Add(sum);
        }
        return result;
    }
}