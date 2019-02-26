using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordpuzzle
{
    class Program
    {
        public static string filename = @"I:\GET\source\repos\AlmostGETit\C#\wordpuzzle\ordbank_bm\fullform_bm.txt";
        private static readonly Random _Rnd = new Random();
        public static string[] output;
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
            output = validWords.ToArray();

            string randomWord = RandomWord(1, output)[0];
            string pattern = randomWord.Substring(0, 3);
            int stop = 0;
            string returnWord = "null";
            for (int i = 0; i < 3; i++)
            {
                if (SearchWord(pattern.Substring(0, (3 + i)), output))
                {
                    stop = i;
                    returnWord = randomWord;
                    Console.WriteLine("break");
                    break;
                }
            }

            Console.WriteLine("Found a match {0}, {1}, {2}", pattern, returnWord, randomWord);
        }

        static bool SearchWord(string pattern, string[] words)
        {
            foreach (var w in words)
            {
                if (MatchPattern(pattern, w)) return true;
            }

            return false;
        }

        static bool MatchPattern(string pattern, string word)
        {
            return (pattern == word.Substring(0, pattern.Length));
        }

        static string[] RandomWord(int numbers, string[] words)
        {
            List<string> randomOutput = new List<string>();
            for (int i = 0; i < numbers; i++)
            {
                int number = _Rnd.Next(words.Length);
                randomOutput.Add(words[number]);
                output = output.Where(val => val != words[number]).ToArray();
            }

            return randomOutput.ToArray();
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
