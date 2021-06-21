using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordFinder.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class WordFinderBenchmarks
    {
        private const string baseWord = "schornsteinfegerleiter";
        //private static List<string> wordsDictionary = new List<string>() { "Test", "Aber", "Haustier", "Set", "Schornstein" };
        private static List<string> wordsDictionary = File.ReadAllLines(@".\WordsDictionaryFinalUppercase-de-DE.txt").ToList();

        private static string[] resultDict;


        //[Benchmark(Baseline = true)]
        //public void FindPossibleWords_Parallel()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel(baseWord, wordsDictionary, out resultDict);
        //}

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


        //[Benchmark]
        //public void FindPossibleWords_Parallel_return_new2()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_return_new2(baseWord, wordsDictionary, out resultDict);
        //}

        //[Benchmark]
        //public void FindPossibleWords_Parallel_Scramble()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_Scramble(baseWord, wordsDictionary, out resultDict);
        //}

        //[Benchmark]
        //public void FindPossibleWords_Parallel_Scramble_2foreach()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_Scramble_2foreach(baseWord, wordsDictionary, out resultDict);
        //}

        //[Benchmark]
        //public void FindPossibleWords_Parallel_Scramble_foreach()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_Scramble_foreach(baseWord, wordsDictionary, out resultDict);
        //}

        //[Benchmark]
        //public void FindPossibleWords_Parallel_Scramble_foreachCount()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_Scramble_foreachCount(baseWord, wordsDictionary, out resultDict);
        //}
        //[Benchmark]
        //public void FindPossibleWords_Parallel_Scramble_groupby()
        //{
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_Scramble_groupby(baseWord, wordsDictionary, out resultDict);
        //}
        [Benchmark]
        public void FindPossibleWords_Parallel_Scramble_ifFor()
        {
            WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_Scramble_ifFor(baseWord, wordsDictionary, out resultDict);
        }

        //[Benchmark]
        //public void FindPossibleWords_Parallel_Span()
        //{
        //    ReadOnlySpan<string> wordsSpan = new ReadOnlySpan<string>(wordsDictionary.ToArray());
        //    WordFinder.Core.Wordfinder.FindPossibleWords_Parallel_Span(baseWord, wordsSpan, out resultDict);
        //}


        //[Benchmark]
        //public void FindWords_Basic()
        //{
        //    WordFinder.Core.Wordfinder.FindAndPrintPossibleWords_Basic(baseWord, out count);
        //}

    }
}
