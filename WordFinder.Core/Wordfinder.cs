using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WordFinder.Core.Helper;

namespace WordFinder.Core
{
    public class Wordfinder
    {
        public static void FindAndPrintPossibleWords_Basic(string baseWord, out int possibleWordsCount)
        {
            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);
            possibleWordsCount = 0;

            using (var reader = new StreamReader(@"Data\German-Words_Dictionary_Final_Uppercase.txt"))
            {
                for (string currentWord = reader.ReadLine(); currentWord != null; currentWord = reader.ReadLine())
                {
                    Dictionary<char, int> currentWordDict = CharacterCounter.getCharacterCountDict(currentWord.ToUpper());

                    bool canMakeCurrentWord = true;

                    foreach (char character in currentWordDict.Keys)
                    {
                        int currentWordCharCount = currentWordDict[character];
                        int lettersCharCount = 0;

                        if (lettersCountDict.ContainsKey(character))
                        {
                            lettersCharCount = lettersCountDict[character];
                        }
                        else
                        {
                            lettersCharCount = 0;
                        }
                        if (currentWordCharCount > lettersCharCount)
                        {
                            canMakeCurrentWord = false;
                            break;
                        }
                    }
                    if (canMakeCurrentWord)
                    {
                        possibleWordsCount++;
                        Console.Write("{0,-40}", currentWord);
                    }
                }
            }
        }

        public static void FindPossibleWords_static(string baseWord, out SortedSet<string> resultList)
        {
            resultList = new SortedSet<string>();
            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);

            try
            {
                using var reader = new StreamReader(@"Data\German-Words_Dictionary_Final_Uppercase.txt");
                for (string currentWord = reader.ReadLine(); currentWord != null; currentWord = reader.ReadLine())
                {
                    Dictionary<char, int> currentWordDict = CharacterCounter.getCharacterCountDict(currentWord);

                    bool canMakeCurrentWord = true;

                    foreach (char character in currentWordDict.Keys)
                    {
                        int currentWordCharCount = currentWordDict[character];
                        int lettersCharCount = 0;

                        if (lettersCountDict.ContainsKey(character))
                        {
                            lettersCharCount = lettersCountDict[character];
                        }
                        else
                        {
                            lettersCharCount = 0;
                        }
                        if (currentWordCharCount > lettersCharCount)
                        {
                            canMakeCurrentWord = false;
                            break;
                        }
                    }
                    if (canMakeCurrentWord)
                    {
                        resultList.Add(currentWord);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
