namespace TrePaaRad.Modules
{
    public class BoardModel
    {
        public string[][] board;

        public BoardModel()
        {
            this.board = new[]
            {
                new[]
                {
                    " ",
                    " ",
                    " "
                },
                new[]
                {
                    " ",
                    " ",
                    " "
                },
                new[]
                {
                    " ",
                    " ",
                    " "
                }
            };
        }
    }
}