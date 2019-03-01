namespace RandomSquares.Modules
{
    public class VirtualScreenRow
    {
        private VirtualScreenCell[] _cells;
        private int _screenWidth;

        public VirtualScreenRow(int screenWidth) { }

        public void AddBoxTopRow(int boxX, int boxWidth) { }
        public void AddBoxBottomRow(int boxX, int boxWidth) { }
        public void AddBoxMiddleRow(int boxX, int boxWidth) { }
        public void Show() { }
    }
}