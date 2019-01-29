using System;

namespace ConsoleApp2
{
    
    class Program
    {
        static readonly Random rand = new Random();

        static void Main(string[] args)
        {
            if (!IsValid(args))
            {
                Help();
                return;
            }
            var letters = args[1];
            var value = int.Parse(args[0]);
            var pass = ReturnPass(letters, value);
            Console.WriteLine(pass);
        }

        public static bool IsValid(string[] args)
        {
            switch (args.Length)
            {
                case 2 when int.TryParse(args[0], out int val):
                    // Val is now int
                    return true;
                default:
                    return false;
            }
        }

        public static string GetRandomType(string input, char inType='0')
        {
            string outVar = "";
            char type = (inType == '0') ? input[rand.Next(input.Length)] : inType;
            
            switch (type)
            {
                case 's':
                    outVar += GetRandomSpecial();
                    break;
                case 'L':
                    outVar += char.ToUpper(GetRandomChar());
                    break;
                case 'l':
                    outVar += GetRandomChar();
                    break;
                case 'd':
                    outVar += GetRandomInt();
                    break;
                default:
                    Console.WriteLine("Parse Error");
                    Help();
                    outVar = null;
                    break;
                    //return outVar;
            }

            return outVar;
        }

        public static string ReturnPass(string input, int numberOfLetters)
        {
            var outVar = "";
            foreach (char c in input)
            {
                outVar += GetRandomType(input, c);
            }
            for (var i = 0; i < numberOfLetters-input.Length; i++)
            {
                outVar += GetRandomType(input);
            }
            return outVar;
        }

        public static char GetRandomSpecial()
        {
            string sp = "!/\"#¤%&/(){}[]";
            return sp[rand.Next(sp.Length)];
        }

        public static char GetRandomChar()
        {
            
            var ch = (char) ('a' + rand.Next(0, 25));
            return ch;
        }

        public static int GetRandomInt()
        {
            return rand.Next(0, 9);
        }

        public static bool IsValid(string arguments)
        {
            return true;
        }

        static void Help()
        {
            Console.WriteLine("Password Generator");
            Console.WriteLine("  Options:");
            Console.WriteLine("  - l = lower case letter");
            Console.WriteLine("  - L = upper case letter");
            Console.WriteLine("  - d = digit");
            Console.WriteLine("  - s = special character (!/\"#¤%&/(){}[]");
            Console.WriteLine("Example: PasswordGenerator 14 lLssdd");
            Console.WriteLine("         Min. 1 lower case");
            Console.WriteLine("         Min. 1 upper case");
            Console.WriteLine("         Min. 2 special characters");
            Console.WriteLine("         Min. 2 digits");
        }
    }
}
