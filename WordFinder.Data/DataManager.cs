using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WordFinder.Data
{
    public class DataManager
    {
        public static void LoadWordsDictionary(List<string> wordsDictionary)
        {
            string currentWord;
            var assembly        = Assembly.Load("WordFinder.Data");
            var resourceName    = "WordFinder.Data.Data.WordsDictionaryFinalUppercase-de-DE.txt";
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using var reader    = new StreamReader(stream);
            while ((currentWord = reader.ReadLine()) != null)
            {
                wordsDictionary.Add(currentWord);
            }
        }

        public static void LoadWordsDictionary(List<string> wordsDictionary, Languages language)
        { // TODO: Find other languages
            string currentWord;
            var assembly        = Assembly.Load("WordFinder.Data");
            string resourceName = language switch
            {
                Languages.German  => "WordFinder.Data.Data.WordsDictionaryFinalUppercase-de-DE.txt",
                Languages.English => "WordFinder.Data.Data.WordsDictionaryFinalUppercase-en-EN.txt",
                Languages.French  => "WordFinder.Data.Data.WordsDictionaryFinalUppercase-fr-FR.txt",
                _                 => "WordFinder.Data.Data.WordsDictionaryFinalUppercase-de-DE.txt",
            };
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using var reader    = new StreamReader(stream);
            while ((currentWord = reader.ReadLine()) != null)
            {
                wordsDictionary.Add(currentWord);
            }
        }


        public static async Task LoadWordsDictionaryAsync(List<string> wordsDictionary)
        {
            String result;
            var assembly = Assembly.Load("WordFinder.Data");
            var resourceName = "WordFinder.Data.Data.WordsDictionaryFinalUppercase-de-DE.txt";
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            while ((result = await reader.ReadLineAsync()) != null)
            {
                wordsDictionary.Add(result);
            }
        }

        public void SaveWordsDictionaryToTextfile(List<string> data, string baseWord, Languages language)
        {
            File.WriteAllLines(@$"Data\{language}_Words_From_{baseWord}.txt", data);
        }
    }
}

