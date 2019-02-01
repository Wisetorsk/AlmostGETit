using System;
using System.Linq;


namespace PassordGenerator
{
    class Program
    {
        public static string Pattern;
        public static int NumInt;
        public static char[] ValidChars = {'l', 'L', 's', 'd'};
        private static readonly Random _rand = new Random();

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
            foreach (char letter in Pattern)
            {
                Console.WriteLine(letter);
                switch (letter)
                {
                    case 'l':
                        pass += WriteRandomLowerCaseLetter();
                        break;
                    case 'L':
                        pass += WriteRandomUpperCaseLetter();
                        break;
                    case 's':
                        pass += WriteRandomSpecialCharacter();
                        break;
                    case 'd':
                        pass += WriteRandomDigit();
                        break;
                    default:
                        ShowHelpText();
                        break;
                }
            }

            for (var i = 0; i < (NumInt - Pattern.Length); i++)
            {
                pass += WriteRandomLowerCaseLetter();
            }
            Console.WriteLine(pass);
            
        }

        public static bool IsValid(string[] args)
        {
            if (args.Length == 0 || args.Length == 1) return false;
            if (int.TryParse(args[0], out var val))
            {
                NumInt = val;
            }
            else
            {
                return false;
            }
            foreach (var c in args[1])
            {
                if (!ValidChars.Contains(c))
                {
                    return false;
                }
            }
            Pattern = args[1];
            if (Pattern.Length > NumInt) return false;
            return true;
        }


        public static char WriteRandomLowerCaseLetter()
        {
            return (char)('a' + _rand.Next(26));
        }

        public static char WriteRandomUpperCaseLetter()
        {
            return char.ToUpper(WriteRandomLowerCaseLetter());
        }

        public static int WriteRandomDigit()
        {
            
            return _rand.Next(10);
        }

        public static char WriteRandomSpecialCharacter()
        {
            var s = "!\"#¤%&/(){}[]";
            return (char)s[_rand.Next(s.Length)];
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
                edgeL + "Pattern must be same length og less than first argument",
                line
            };
            foreach (var t in helpString)
            {
                Console.WriteLine(t + new String(' ', lineWidth - t.Length) + edgeR);
            }
        }
    }
}

