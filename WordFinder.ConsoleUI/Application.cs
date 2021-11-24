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
        // TODO: continueRunning static or volatile?
        private bool continueRunning;
        private string[] resultWords;
        private List<string> wordsDictionary;

        internal Application()
        {
            Initialize();
        }
        private void Initialize()
        {
            UIManager.InitializeConsole();
            UIManager.PrintMassage("Application loading ..");
            wordsDictionary = new List<string>();
            continueRunning = true;
            // TODO try?
            //Exception threadException = null;
            Thread backgroundWorker = new Thread(() =>
            {
                //try
                //{
                SafeExecute(() => DataManager.LoadWordsDictionary(wordsDictionary), UIManager.HandleException);
                //}
                //catch (Exception ex)
                //{
                //    threadException = ex;
                //    //throw new Exception(ex.Message);
                //}

            })
            { IsBackground = true };
            backgroundWorker.Start();
            backgroundWorker.Join();
        }
        internal void Run()
        {
            while (continueRunning)
            {
                UIManager.AskForNewWord(out string baseWord);
                // TODO try?
                //try
                //{
                //Wordfinder.FindPossibleWords_Parallel(baseWord, wordsDictionary, out resultWords);
                //Wordfinder.FindPossibleWords_Parallel_return_new2(baseWord, wordsDictionary, out resultWords);
                Wordfinder.FindPossibleWords_Parallel_Scramble_ifFor(baseWord, wordsDictionary, out resultWords);
                //Wordfinder.FindPossibleWords_Parallel_Span(baseWord, wordsDictionary, out resultWords);
                UIManager.PrintWordList(resultWords, out int possibleWordsCount);
                UIManager.PrintGeneratedWordsCount(possibleWordsCount, baseWord);
                UIManager.TryAgainMassage(ref continueRunning);
                //}
                //catch (Exception)
                //{
                //    throw;
                //    //UIManager.HandleException(ex);
                //    //continueRunning = false;
                //}
            }
            UIManager.ProgrammEndsMassage();
        }




        private void SafeExecute(Action action, Action<Exception> handleException)
        {
            Exception exception = null;
            try
            {
                action.Invoke();
            }
            catch (Exception exc)
            {
                exception = exc;
                Console.Clear();
                handleException(exception);
            }
            finally
            {
                if (exception != null)
                {
                    continueRunning = false;
                }

            }
        }
    }
}
