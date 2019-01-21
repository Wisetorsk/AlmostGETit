using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        // Fields (Semi-Global Variables)
        static void Main(string[] args)
        {
            Console.WriteLine("Hello WORLD!" );
            Console.WriteLine("Antall Parametere: " + args.Length);
            Console.WriteLine("All the numbers in the arguments sum to: " + SumArgs(args));
        }

        static int SumArgs(IReadOnlyList<string> arguments)
        {
            var sum = 0;
            for (var i = 0; i < arguments.Count; i++)
            {
                var parameterNo = i + 1;
                Console.WriteLine("Parameter " + parameterNo + ": " + arguments[i]);
                if (int.TryParse(arguments[i], out var number))
                {
                    sum = sum + number;
                }
            }
            return sum;
        }
    }
}
