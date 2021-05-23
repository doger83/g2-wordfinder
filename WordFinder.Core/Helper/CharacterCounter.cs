using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder.Core.Helper
{
    public class CharacterCounter
    {
        internal static Dictionary<char, int> getCharacterCountDict(string letters)
        {
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
