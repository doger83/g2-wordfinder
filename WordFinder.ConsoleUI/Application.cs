using System;
using System.Collections.Generic;
using WordFinder.ConsoleUI.Massages;
using WordFinder.Data;
using WordFinder.Core;

namespace WordFinder.ConsoleUI
{
    class Application
    {
        private bool continueRunning;
        //List<string> germanWords;
        SortedSet<string> resultWords;

        internal Application()
        {
            Initialize();
        }

        internal void Run()
        {

            while (continueRunning)
            {
                UI.AskForNewWord(out string baseWord);

                //FindAndPrintPossibleWords_Basic(baseWord, out int possibleWordsCount);
                //UI.PrintGeneratedWordsCount(possibleWordsCount);

                //resultWords = Wordfinder.findPossibleWords(germanWords, baseWord);
                resultWords = Wordfinder.findPossibleWords(baseWord);

                foreach (var item in resultWords)
                {
                    Console.Write("{0,-40}", item);
                }

                UI.PrintGeneratedWordsCount(resultWords.Count);

                continueRunning = false;
            }
        }


        internal void Close()
        {
            UI.ProgrammEndsMassage();
        }

        private void Initialize()
        {
            continueRunning = true;
            Console.SetBufferSize(160, short.MaxValue - 1);
            Console.SetWindowSize(160, 65);
            //germanWords = WordList.LoadWordsByLanguage(Languages.German);
        }
    }
}


