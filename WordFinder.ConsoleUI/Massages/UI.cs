using System;
using System.Collections.Generic;

namespace WordFinder.ConsoleUI.Massages
{
    class UI
    {
        internal static void AskForNewWord(out string baseWord)
        {
            Console.Write("Please enter the base Word : ");
            baseWord = Console.ReadLine().ToUpper();
        }

        internal static void PrintGeneratedWordsCount(int count)
        {
            Console.WriteLine();
            Console.WriteLine($"You can create a total of {count} other words from the given word.");
        }

        internal static void ProgrammEndsMassage()
        {
            Console.WriteLine();
            Console.WriteLine("Hit ENTER to close the App..");
            Console.ReadKey(true);
        }

        internal static void PrintWordList(List<string> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
