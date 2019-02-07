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
            foreach (var line in lines)
            {
                //Console.WriteLine(line);
            }
        }

        static string[] ReadFile(string filename)
        {
            string[] rawText = System.IO.File.ReadAllLines(filename);
            return rawText;
        }
    }
}
