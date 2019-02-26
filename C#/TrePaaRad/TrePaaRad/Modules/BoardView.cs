using System;

namespace TrePaaRad.Modules
{
    public class BoardView
    {
        private BoardModel _board;

        public BoardView(BoardModel board)
        {
            _board = board;
        }

        public void Show()
        {
            Console.WriteLine("    a   b   c");
            Console.WriteLine("  -------------");
            Console.WriteLine("0 | " + _board.board[0][0] + " | " + _board.board[0][1] + " | " + _board.board[0][2] + " |");
            Console.WriteLine("1 | " + _board.board[1][0] + " | " + _board.board[1][1] + " | " + _board.board[1][2] + " |");
            Console.WriteLine("2 | " + _board.board[2][0] + " | " + _board.board[2][1] + " | " + _board.board[2][2] + " |");
            Console.WriteLine("  -------------");
        }

    }
}