using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder.Core.Helper
{
    public class CharacterCounter
    {
        internal static Dictionary<char, int> GetCharacterCountDict(string letters)
        {
            // TODO: add more Guard clauses in project see: https://stavroskasidis.com/blog/2017/tips-and-tricks-1-guard-clauses/
            // https://maximegel.medium.com/what-are-guard-clauses-and-how-to-use-them-350c8f1b6fd2
            //if (string.IsNullOrEmpty(letters))
            //{
            //    throw new ArgumentException($"'{nameof(letters)}' cannot be null or empty.", nameof(letters));
            //}
            // TODO: change exceptionhandling. Dont catch guards!

            var result = new Dictionary<char, int>();

            for (int i = 0; i < letters.Length; i++)
            {
                char currentChar = letters[i];

                if (result.ContainsKey(currentChar))
                {
                    result[currentChar] = result[currentChar] + 1;
                }
                else
                {
                    result.Add(currentChar, 1);
                }
            }
            return result;
        }

        private static string SortString(string input)
        {
            char[] characters = input.ToLower().ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
