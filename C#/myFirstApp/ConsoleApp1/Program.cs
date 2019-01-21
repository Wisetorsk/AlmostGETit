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
            var range = 250;
            var counts = new int[range];
            var percentages = new double[range];
            var text = "something";
            while (!string.IsNullOrWhiteSpace(text))
            {
                text = Console.ReadLine();
                foreach (var character in text.ToUpper() ?? string.Empty)
                {
                    counts[(int)character]++;
                }

                var sum = counts.Sum();
                var percentageFactor = Convert.ToDouble(sum);

                for (var i = 0; i < counts.Length; i++)
                {
                    double percent = counts[i] / percentageFactor * 100;
                    percentages[i] = percent;
                }

                for (var i = 0; i < range; i++)
                {
                    if (counts[i] <= 0) continue;
                    var character = (char)i;
                    Console.WriteLine(character + " - " + String.Format("{0, 10}", Math.Round(percentages[i], 2)) + '%');
                }
            }
            Console.WriteLine("Number of input parameters: " + args.Length);
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
