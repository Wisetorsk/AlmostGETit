using System;
using System.Collections.Generic;
using System.Linq;
using TrePaaRad.Modules;

namespace TrePaaRad
{
    class Program
    {
        private static readonly Random _rng = new Random();
        private static BoardModel _brett;
        private static BoardView _visning;

        public static Dictionary<char, int> translate = new Dictionary<char, int>()
        {
            {'a', 0},
            {'b', 1},
            {'c', 2}
        };

        static void Main(string[] args)
        {
            _brett = new BoardModel();
            _visning = new BoardView(_brett);
            var finished = false;
            bool ai;
            Tuple<bool, char> result = new Tuple<bool, char>(false, ' ');
            Console.WriteLine("Play against the computer? (Y/N):");
            while (true)
            {
                var userSelect = Console.ReadLine();
                if (userSelect == "y" || userSelect == "Y")
                {
                    ai = true;
                    break;
                }
                if (userSelect == "n" || userSelect == "N")
                {
                    ai = false;
                    break;
                }
            }

            _visning.Show();
            while (!finished)
            {
                var selectX = false;
                var selectY = false;
                while (!selectX)
                {
                    if (!AddChar('x')) continue;
                    result = IsGameOver(_brett);
                    finished = result.Item1;
                    _visning.Show();
                    selectX = true;
                }

                while (!selectY)
                {
                    if (!ai)
                    { 
                        if (!AddChar('o')) continue;
                        result = IsGameOver(_brett);
                        finished = result.Item1;
                        _visning.Show();
                        selectY = true;
                    }
                    else
                    {
                        selectY = SetRandomO();
                        result = IsGameOver(_brett);
                        finished = result.Item1;
                        _visning.Show();
                    }
                }

            }
            Console.WriteLine($"Game over! Winner is: {result.Item2}");
        }

        public static Tuple<bool, char> IsGameOver(BoardModel board)
        {
            var result = false;
            var player = ' ';
            Tuple<int, int>[][] indexes = 
            {
                new Tuple<int, int>[] {
                    new Tuple<int, int>(0, 0),
                    new Tuple<int, int>(0, 1),
                    new Tuple<int, int>(0, 2)
                },
                new Tuple<int, int>[] {
                    new Tuple<int, int>(1, 0),
                    new Tuple<int, int>(1, 1),
                    new Tuple<int, int>(1, 2)
                },
                new Tuple<int, int>[] {
                    new Tuple<int, int>(2, 0),
                    new Tuple<int, int>(2, 1),
                    new Tuple<int, int>(2, 2)
                },
                new Tuple<int, int>[] {
                    new Tuple<int, int>(0, 0),
                    new Tuple<int, int>(1, 0),
                    new Tuple<int, int>(2, 0)
                },
                new Tuple<int, int>[] {
                    new Tuple<int, int>(0, 1),
                    new Tuple<int, int>(1, 1),
                    new Tuple<int, int>(2, 1)
                },
                new Tuple<int, int>[] {
                    new Tuple<int, int>(0, 2),
                    new Tuple<int, int>(1, 2),
                    new Tuple<int, int>(2, 2)
                },
                new Tuple<int, int>[] {
                    new Tuple<int, int>(0, 0),
                    new Tuple<int, int>(1, 1),
                    new Tuple<int, int>(2, 2)
                },
                new Tuple<int, int>[] {
                    new Tuple<int, int>(0, 2),
                    new Tuple<int, int>(1, 1),
                    new Tuple<int, int>(2, 0)
                }
            };

            foreach (var sequence in indexes)
            {
                var line = sequence.Aggregate("", (current, step) => current + _brett.board[step.Item1][step.Item2]);

                if (line != "xxx" && line != "ooo") continue;
                result = true;
                player = Convert.ToChar(line.Substring(0, 1));
                break;
            }

            return new Tuple<bool, char>(result, player);
        }

        public static bool AddChar(char player)
        {
            Console.WriteLine($"Enter coordinates for '{player}' (row, column)");
            var rawInput = Console.ReadLine()?.Split(' ');
            if (rawInput != null && rawInput.Length < 2) return false;
            if (!Int16.TryParse(rawInput[0], out var row)) return false;
            if (row > 2 || row < 0) return false;
            if (!Char.TryParse(rawInput[1], out var ch)) return false;
            if (!translate.TryGetValue(ch, out var col)) return false;
            if (player == 'x')
            {
                if (AddX(row, col)) return true;
            }
            else
            {
                if (AddO(row, col)) return true;
            }

            return false;
        }

        public static bool AddX(int r, int c)
        {
            if (IsOccupied(r, c)) return false;
            Console.WriteLine($"Setting {r} {c} to X");
            _brett.board[r][c] = "x";
            return true;
        }

        public static bool AddO(int r, int c)
        {
            if (IsOccupied(r, c)) return false;
            Console.WriteLine($"Setting {r} {c} to O");
            _brett.board[r][c] = "o";
            return true;
        }

        public static bool IsOccupied(int r, int c)
        {
            switch (_brett.board[r][c])
            {
                case "x":
                case "o":
                    return true;
                default:
                    return false;
            }
        }

        public static bool SetRandomO()
        {
            var r = _rng.Next(3);
            var c = _rng.Next(3);
            while (true)
            {
                if (AddO(r, c)) return true;
            }
        }
    } 
}
