using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

        public static SortedSet<string> findPossibleWords(string baseWord)
        {
            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);
            SortedSet<string> result = new SortedSet<string>();

            using (var reader = new StreamReader(@"Data\German-Words_Dictionary_Final_Uppercase.txt"))
            {
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
                        result.Add(currentWord);
                    }

                }
            }

            return result;
        }

        public static async Task findPossibleWordsAsync(List<string> wordsDict, string baseWord, List<string> result)
        {

            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);


            foreach (string currentWord in wordsDict)
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

                    await Task.Run(() => result.Add(currentWord));
                }

            }
        }

    }
}
