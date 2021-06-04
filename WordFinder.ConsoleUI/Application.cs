using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using WordFinder.ConsoleUI.Utils;
using WordFinder.Core;
using WordFinder.Data;

namespace WordFinder.ConsoleUI
{
    class Application
    {
        private bool running;
        private string[] resultWords;
        private List<string> wordsDictionary;

        internal Application()
        {
            Initialize();
        }

        internal void Run()
        {
            while (running)
            {
                UIManager.AskForNewWord(out string baseWord);

                try
                {
                    Wordfinder.FindPossibleWords_Parallel(baseWord, wordsDictionary, out resultWords);
                    UIManager.PrintWordList(resultWords, out int possibleWordsCount);
                    UIManager.PrintGeneratedWordsCount(possibleWordsCount, baseWord);
                    UIManager.TryAgainMassage(ref running);
                }
                catch (Exception e)
                {
                    UIManager.ShowErrorMassage(e.Message);
                    running = false;
                }
            }
            UIManager.ProgrammEndsMassage();
        }

        private void Initialize()
        {
            UIManager.InitializeConsole();
            UIManager.PrintMassage("Application loading ..");
            running = true;
            wordsDictionary = new List<string>();

            // TODO: handle exceptions
            // TODO: Speed? 
            try
            {
                new Thread(() =>
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    DataManager.LoadWordsDictionary(wordsDictionary);
                    watch.Stop();
                    Console.WriteLine();
                    Console.WriteLine(watch.ElapsedMilliseconds);
                })
                { IsBackground = true }.Start();
            }
            catch (Exception)
            {

                throw;

            }
        }
    }
}
