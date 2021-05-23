using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordFinder.Data
{
    public class WordList
    {
        public static List<string> LoadWordsByLanguage(Languages language)
        {
            List <string> result  = new List<string>();

            switch (language)
            {
                // TODO: Find other languages
                case Languages.German:
                    result = File.ReadAllLines(@"Data\German-Words_Dictionary_Final_Uppercase.txt").ToList();
                    break;
                case Languages.English:
                    result = File.ReadAllLines(@"Data\English-Words_Dictionary_Final_Uppercase.txt").ToList();
                    break;
                case Languages.French:
                    result = File.ReadAllLines(@"Data\French-Words_Dictionary_Final_Uppercase.txt").ToList();
                    break;
                default:
                    break;
            }

            return result;
        }
        public void SaveWordsByLanguage(List<string> data, string baseWord, Languages language)
        {
            File.WriteAllLines(@$"Data\{language.ToString()}_Words_From_{baseWord}.txt", data);
        }
    }
}

