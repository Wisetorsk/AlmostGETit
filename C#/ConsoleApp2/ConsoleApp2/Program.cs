using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                help();
            }
            else if (args.Length == 2)
            {
                if (int.TryParse(args[0], out var value))
                {
                    // Val is now int
                    string letters = args[1];
                    foreach (char letter in letters)
                    {
                        // Runs through the settings
                        switch (letter)
                        {
                            case 'l':
                                break;

                            case 'L':
                                break;

                            case 'd':
                                break;

                            case 's':
                                break;
                                
                            default:
                                help();
                                break;
                        }
                    }
                }
                else
                {
                    help();
                }
                
            }
        }

        static bool IsValid(string arguments)
        {
            return true;
        }

        static void help()
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
