using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;

namespace PassordGenerator
{
    class Program
    {
        public static string pattern;
        public static int numInt;
        public static char[] validChars = {'l', 'L', 's', 'd'};
        

        static void Main(string[] args)
        {

            if (!IsValid(args))
            {
                ShowHelpText();
                return;
            }
            ParseArgs(args);
        }

        public static void ParseArgs(string[] args)
        {
            var pass = "";
            Console.WriteLine(pattern);
            Console.WriteLine(numInt);
            Console.WriteLine(pass);
        }

        public static bool IsValid(string[] args)
        {
            if (args.Length != 0) return false;
            if (int.TryParse(args[0], out var val))
            {
                numInt = val;
            }
            foreach (var c in args[1])
            {
                if (!((IList) validChars).Contains(c))
                {
                    return false;
                }
            }
            pattern = args[1];
            return true;
        }


        public static char WriteRandomLowerCaseLetter()
        {
            return 's';
        }

        public static char WriteRandomUpperCaseLetter()
        {
            return 'S';
        }

        public static int WriteRandomDigit()
        {
            return 1;
        }

        public static char WriteRandomSpecialCharacter()
        {
            return '[';
        }

        public static void ShowHelpText()
        {
            var lineWidth = 80;
            var tab = new String(' ', 4);
            var edgeL = "|" + tab;
            var edgeR = "|";
            var line = new String('=', lineWidth);
            string[] helpString = {
                line,
                edgeL + "PasswordGenerator",
                edgeL + "Options:",
                edgeL + tab + "-l = lower case letter",
                edgeL + tab + "- L = upper case letter",
                edgeL + tab + "- d = digit",
                edgeL + tab + "- s = special character(!\"#¤%&/(){}[]",
                edgeL + "Example: PasswordGenerator 14 lLssdd",
                edgeL + tab + "Min. 1 lower case",
                edgeL + tab + "Min. 1 upper case",
                edgeL + tab + "Min. 2 special characters",
                edgeL + tab + "Min. 2 digits",
                line
            };
            foreach (var t in helpString)
            {
                Console.WriteLine(t + new String(' ', lineWidth - t.Length) + edgeR);
            }
        }
    }
}

