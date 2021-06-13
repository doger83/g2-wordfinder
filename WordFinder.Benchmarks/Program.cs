using BenchmarkDotNet.Running;

namespace WordFinder.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<CharacterCounterBenchmarks>();
        }
    }
}
