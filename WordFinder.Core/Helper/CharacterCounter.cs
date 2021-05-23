using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder.Core.Helper
{
    public class CharacterCounter
    {
        //public string Word;
        //public char Character;
        //public int Count;
        private readonly Dictionary<char, int> letters = new Dictionary<char, int>();

        public CharacterCounter(string Word)
        {
            //this.Word = Word;
            //this.Character = Character;
            //this.Count = Count;
            letters = CountCharacters(Word);
        }

        public Dictionary<char, int> CountCharacters(string baseWord)
        {
            baseWord = SortString(baseWord);

            Dictionary<char,int> result = new Dictionary<char, int>();
            foreach (var character in baseWord)
            {
                char c1 = char.ToUpper(character);
                try
                {
                    result.Add(c1, 1);
                }
                catch (Exception e)
                {
                    result[c1] = result[c1] + 1;
                    //Debug.WriteLine("CountCharacters went wrong with Message:" + e.Message);
                }
            }
            return result;
        }
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

        private string SortString(string input)
        {
            char[] characters = input.ToLower().ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
