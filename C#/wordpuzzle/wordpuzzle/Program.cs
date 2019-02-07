using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordpuzzle
{
    class Program
    {
        public static string filename = @"I:\GET\source\repos\AlmostGETit\C#\wordpuzzle\ordbank_bm\fullform_bm.txt";

        static void Main(string[] args)
        {
            string[] lines = ReadFile(filename);
            string[] words = parseWords(lines);
            List<string> validWords = new List<string>();
                
            foreach (var V in words)
            {
                if (IsValid(V))
                {
                    validWords.Add(V);
                }
            }

            string[] output = validWords.ToArray();
            foreach (var l in output)
            {
                Console.WriteLine(l);
            }
        }

        static string[] ReadFile(string filename)
        {
            string[] rawText = System.IO.File.ReadAllLines(filename);
            return rawText;
        }

        static bool IsValid(string word)
        {
            if (word.Length > 10 || word.Length < 7) return false;
            if (word.Contains('-')) return false;
            return true;
        }

        static string[] parseWords(string[] lines)
        {
            List<string> uniqueWords = new List<string>();
            bool firstWord = true;
            string lastWord = null;
            foreach (var line in lines)
            {
                string[] words = line.Split('\t');
                if (words.Length != 6) continue;
                string word = words[1];
                if (firstWord)
                {
                    lastWord = word;
                    uniqueWords.Add(word);
                    firstWord = false;
                }
                else
                {
                    if (word != lastWord) uniqueWords.Add(word); lastWord = word;
                }
            }

            return uniqueWords.ToArray();
        }
    }
}
