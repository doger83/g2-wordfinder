using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordFinder.Data
{
    public class WordList
    {
        //        public List<string> Words;

        //        public WordList(Languages language)
        //        {
        //            Words = LoadWordsByLanguage(language)
        //;
        //        }

        //public void SaveWords(List<string> data, string fileName, Languages language)
        //{
        //    File.WriteAllLines(@$"Data\{language.ToString()}Words_Sorted.txt", data);
        //}

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
    }
}

