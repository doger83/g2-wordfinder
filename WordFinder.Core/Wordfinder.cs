﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public static List<string> FindPossibleWords_List(string baseWord, String[] wordsDict)
        {
            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);
            List<string> result = new List<string>();

            foreach (var currentWord in wordsDict)
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
            return result;
        }
        public static List<string> FindPossibleWords_ListParallel(string baseWord, String[] wordsDict)
        {
            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);
            List<string> result = new List<string>();
           
            Parallel.ForEach(wordsDict, currentWord =>
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
            });
            return result;
        }
        public static IEnumerable<string> FindPossibleWords_yield(string baseWord)
        {
            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);

            // Data.Properties.Resources.Dict_de

            var assembly = Assembly.Load("WordFinder.Data");
            var resourceName = "WordFinder.Data.Data.WordsDictionaryFinalUppercase-de-DE.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
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
                        yield return currentWord;
                    }
                }
            }

        }





        #region Async tries

        public static async IAsyncEnumerable<string> FindPossibleWords_yield_Async(string baseWord)
        {
            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);
            string currentWord;
            using var reader = new StreamReader(@"Data\German-Words_Dictionary_Final_Uppercase.txt");
            while ((currentWord = await reader.ReadLineAsync()) != null)
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
                    yield return currentWord;
                }
            }

        }

        public static async Task FindPossibleWords_Async(string baseWord, SortedSet<string> resultList)
        {
            resultList = new SortedSet<string>();
            List<string> wordList = File.ReadAllLines(@"Data\German-Words_Dictionary_Final_Uppercase.txt").ToList();

            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);

            foreach (var currentWord in wordList)
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.getCharacterCountDict(currentWord);

                resultList.Add(await Task.Run(() => CanMakeCurrentWord(currentWordDict, lettersCountDict, currentWord)));
            }
        }

        public static void FindPossibleWords_ParallelAsync(string baseWord, SortedSet<string> resultList)
        {
            List<string> wordList = File.ReadAllLines(@"Data\German-Words_Dictionary_Final_Uppercase.txt").ToList();

            Dictionary<char, int> lettersCountDict = CharacterCounter.getCharacterCountDict(baseWord);

            foreach (var currentWord in wordList)
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.getCharacterCountDict(currentWord);

                resultList.Add(CanMakeCurrentWord(currentWordDict, lettersCountDict, currentWord));
            }
        }

        private static string CanMakeCurrentWord(Dictionary<char, int> currentWordDict, Dictionary<char, int> lettersCountDict, string currentWord)
        {

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
                return currentWord;
            }
            return "";

        }
        #endregion
    }


}

