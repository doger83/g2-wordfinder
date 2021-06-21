using System;
using System.Collections.Generic;

namespace WordFinder.ConsoleUI.Utils
{
    class UIManager
    {
        #region initialization
        internal static void InitializeConsole()
        {
            Console.Title = "Wordfinder 1.0";
            Console.SetWindowSize(160, Console.LargestWindowHeight - 15);
            Console.SetBufferSize(160, short.MaxValue - 1);
            ConsoleUtils.CenterConsole();
        }

        #endregion

        #region Massages
        internal static void AskForNewWord(out string baseWord)
        {
            Console.Clear();
            Console.Write("Please enter the base Word : ");
            baseWord = Console.ReadLine().ToUpper();
        }
        internal static void PrintMassage(string massage)
        {
            Console.WriteLine(massage);
        }
        internal static void ShowErrorMassage(string errorMassage)
        {
            Console.WriteLine();
            Console.WriteLine("UPS ;( Something went wrong!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Error: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(errorMassage + "\n");
            Console.WriteLine();
        }
        internal static void TryAgainMassage(ref bool continueRunning)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Do you want to find words from a other word? [y / n]");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    continueRunning = true;
                    Console.Clear();
                    break;
                }
                if (input == "n")
                {
                    continueRunning = false;
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Wrong input. Please try again.");

            }
        }
        internal static void ProgrammEndsMassage()
        {
            Console.WriteLine();
            Console.WriteLine("Hit ENTER to close the App..");
            Console.ReadKey(true);

        }

        #endregion

        #region Printhelper
        internal static void PrintGeneratedWordsCount(int count, string baseWord)
        {
            Console.WriteLine();
            Console.WriteLine($"You can create a total of {count} other words from the given word {baseWord}.");
            //throw new Exception("Test exception from debugging");
        }

        internal static void PrintWordList(IEnumerable<string> wordList, out int printedWordsCount)
        {
            printedWordsCount = 0;
            foreach (var word in wordList)
            {
                printedWordsCount++;
                Console.Write("{0,-40}", word);
            }
            Console.WriteLine();
        }

        internal static async void PrintWordList_Async(IAsyncEnumerable<string> wordList)
        {

            //printedWordsCount = 0;
            await foreach (var word in wordList)
            {
                //printedWordsCount++;
                Console.Write("{0,-40}", word);
            }
            Console.WriteLine();
        }

        #endregion

        #region Exceptions

        public static void HandleException(Exception ex)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("UPS ;( Something went wrong!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Error: ");
            Console.ResetColor();
            Console.Write(ex.ToString());
            Console.WriteLine();

        }


        #endregion

    }
}
