using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordFinder.Benchmarks
{
    [MemoryDiagnoser]
    public class WordFinderBenchmarks
    {
        private const string baseWord = "test";
        private static List<string> wordsDictionary = File.ReadAllLines(@".\WordsDictionaryFinalUppercase-de-DE.txt").ToList();
        private static string[] resultDict;


        [Benchmark(Baseline = true)]
        public void FindPossibleWords_Parallel()
        {
            WordFinder.Core.Wordfinder.FindPossibleWords_Parallel(baseWord, wordsDictionary, out resultDict);
        }

        //[Benchmark]
        //public void FindPossibleWords_Parallel_return()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_return(baseWord, wordsDictionary, out resultDict);
        //}

        //[Benchmark]
        //public void FindPossibleWords_Parallel_return_new()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_return_new(baseWord, wordsDictionary, out resultDict);
        //}


        [Benchmark]
        public void FindPossibleWords_Parallel_return_new2()
        {
            WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_return_new2(baseWord, wordsDictionary, out resultDict);
        }


        //[Benchmark]
        //public void FindPossibleWords_Parallel_Span()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_Span(baseWord, wordsDictionary, out resultDict);
        //}


        //[Benchmark]
        //public void FindWords_Basic()
        //{
        //    WordFinder.Core.Wordfinder.FindAndPrintPossibleWords_Basic(baseWord, out count);
        //}

    }
}
