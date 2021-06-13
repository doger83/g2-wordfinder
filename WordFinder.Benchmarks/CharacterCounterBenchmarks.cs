using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Benchmarks
{
    [MemoryDiagnoser]
    public class CharacterCounterBenchmarks
    {
        private const string letters = "Rinderkennzeichnungsfleischetikettierungsüberwachungsaufgabenübertragungsgesetz";

        [Benchmark(Baseline = true)]
        public void GetCharacterCountDict()
        {
            WordFinder.Core.Helper.CharacterCounter.GetCharacterCountDict(letters);
        }
        [Benchmark]
        public void GetCharacterCountDict_new()
        {
            WordFinder.Core.Helper.CharacterCounter.GetCharacterCountDict_new(letters);
        }

    }
}
