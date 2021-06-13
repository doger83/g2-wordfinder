using System;
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
            var lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);
            possibleWordsCount = 0;

            using var reader = new StreamReader(@"Data\WordsDictionaryFinalUppercase-de-DE.txt");
            for (string currentWord = reader.ReadLine(); currentWord != null; currentWord = reader.ReadLine())
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord.ToUpper());

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

        public static void FindPossibleWords_static(string baseWord, out SortedSet<string> resultList)
        {
            resultList = new SortedSet<string>();
            Dictionary<char, int> lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);

            try
            {
                using var reader = new StreamReader(@"Data\German-Words_Dictionary_Final_Uppercase.txt");
                for (string currentWord = reader.ReadLine(); currentWord != null; currentWord = reader.ReadLine())
                {
                    Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);

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
            Dictionary<char, int> lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);
            List<string> result = new List<string>();

            foreach (var currentWord in wordsDict)
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);

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

        public static void FindPossibleWords_Parallel(string baseWord, List<string> inputDict, out string[] resultDict)
        {
            // TODO: make async?
            var lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);
            var resultSet = new SortedSet<string>();
            var Locker = new object();
            //ParallelLoopState state = new ParallelLoopState(;

            Parallel.ForEach(inputDict, currentWord =>
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);

                bool canMakeCurrentWord = true;
                int currentWordCharCount;
                int lettersCharCount;
                foreach (char character in currentWordDict.Keys)
                {
                    currentWordCharCount = currentWordDict[character];
                    lettersCharCount = 0;

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
                    lock (Locker)
                    {
                        resultSet.Add(currentWord);
                    }
                }
            });
            resultDict = resultSet.ToArray();
        }

        public static void FindPossibleWords_Parallel_return(string baseWord, List<string> inputDict, out string[] resultDict)
        {
            // TODO: make async?
            var lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);
            var resultSet = new SortedSet<string>();
            var Locker = new object();
            //ParallelLoopState state = new ParallelLoopState(;

            Parallel.ForEach(inputDict, currentWord =>
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);
                if (currentWordDict.Count > lettersCountDict.Count)
                {
                    return;
                }
                //bool canMakeCurrentWord = true;
                int currentWordCharCount;
                int lettersCharCount;
                foreach (char character in currentWordDict.Keys)
                {
                    currentWordCharCount = currentWordDict[character];
                    lettersCharCount = 0;

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
                        //canMakeCurrentWord = false;
                        return;
                    }
                }
                //if (canMakeCurrentWord)
                //{
                lock (Locker)
                {
                    resultSet.Add(currentWord);
                }
                //}
            });
            resultDict = resultSet.ToArray();
        }

        public static void FindPossibleWords_Parallel_return_new(string baseWord, List<string> inputDict, out string[] resultDict)
        {
            // TODO: make async?
            var lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);
            var resultSet = new SortedSet<string>();
            var Locker = new object();
            //ParallelLoopState state = new ParallelLoopState(;

            Parallel.ForEach(inputDict, currentWord =>
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);
                if (currentWordDict.Count > lettersCountDict.Count)
                {
                    return;
                }
                //bool canMakeCurrentWord = true;
                int currentWordCharCount;
                int lettersCharCount;
                foreach (char character in currentWordDict.Keys)
                {
                    currentWordCharCount = currentWordDict[character];
                    lettersCharCount = 0;

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
                        //canMakeCurrentWord = false;
                        return;
                    }
                }
                //if (canMakeCurrentWord)
                //{
                lock (Locker)
                {
                    resultSet.Add(currentWord);
                }
                //}
            });
            resultDict = resultSet.ToArray();
        }


        public static void FindPossibleWords_Parallel_return_new2(string baseWord, List<string> inputDict, out string[] resultDict)
        {
            // TODO: make async?
            var lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);
            var resultSet = new SortedSet<string>();
            var Locker = new object();
            //ParallelLoopState state = new ParallelLoopState(;

            Parallel.ForEach(inputDict, currentWord =>
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);
                if (currentWordDict.Count > lettersCountDict.Count)
                {
                    return;
                }
                //bool canMakeCurrentWord = true;
                int currentWordCharCount;
                int lettersCharCount;

                //foreach (char character in lettersCountDict.Keys)
                //{
                //    if (!currentWordDict.ContainsKey(character))
                //    {
                //        return;
                //    }


                //}

                foreach (char character in currentWordDict.Keys)
                {
                    currentWordCharCount = currentWordDict[character];
                    lettersCharCount = 0;
                    if (!lettersCountDict.ContainsKey(character))
                    {
                        return;
                    }

                    lettersCharCount = lettersCountDict[character];


                    if (currentWordCharCount > lettersCharCount)
                    {
                        //canMakeCurrentWord = false;
                        return;
                    }
                }
                //if (canMakeCurrentWord)
                //{
                lock (Locker)
                {
                    resultSet.Add(currentWord);
                }
                //}
            });
            resultDict = resultSet.ToArray();
        }

        public static void FindPossibleWords_Parallel_Span(string baseWord, List<string> inputDict, out string[] resultDict)
        {
            // TODO: make async?
            var inputSpan = new ReadOnlySpan<string>(inputDict.ToArray());

            var lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);
            var resultSet = new SortedSet<string>();

            string currentWord = "";
            for (int i = 0; i < inputSpan.Length; i++)
            {
                //currentWord = inputSpan.Slice(i, 1)[0].ToString();
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(inputSpan[i]);
                if (currentWordDict.Count > lettersCountDict.Count)
                {
                    continue;
                }
                bool canMakeCurrentWord = true;
                int currentWordCharCount;
                int lettersCharCount;
                foreach (char character in currentWordDict.Keys)
                {
                    currentWordCharCount = currentWordDict[character];
                    lettersCharCount = 0;

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

                    resultSet.Add(inputSpan[i]);

                }
            }
            resultDict = resultSet.ToArray();
        }


        public static IEnumerable<string> FindPossibleWords_yield(string baseWord)
        {
            var lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);
            var assembly = Assembly.Load("WordFinder.Data");
            var resourceName = "WordFinder.Data.Data.WordsDictionaryFinalUppercase-de-DE.txt";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            for (string currentWord = reader.ReadLine(); currentWord != null; currentWord = reader.ReadLine())
            {
                var currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);
                var canMakeCurrentWord = true;

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

        #region Async trys

        public static async IAsyncEnumerable<string> FindPossibleWords_yield_Async(string baseWord)
        {
            Dictionary<char, int> lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);
            string currentWord;
            using var reader = new StreamReader(@"Data\German-Words_Dictionary_Final_Uppercase.txt");
            while ((currentWord = await reader.ReadLineAsync()) != null)
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);

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

            Dictionary<char, int> lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);

            foreach (var currentWord in wordList)
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);

                resultList.Add(await Task.Run(() => CanMakeCurrentWord(currentWordDict, lettersCountDict, currentWord)));
            }
        }

        public static void FindPossibleWords_ParallelAsync(string baseWord, SortedSet<string> resultList)
        {
            List<string> wordList = File.ReadAllLines(@"Data\German-Words_Dictionary_Final_Uppercase.txt").ToList();

            Dictionary<char, int> lettersCountDict = CharacterCounter.GetCharacterCountDict(baseWord);

            foreach (var currentWord in wordList)
            {
                Dictionary<char, int> currentWordDict = CharacterCounter.GetCharacterCountDict(currentWord);

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

