using System;

namespace RandomSquares.Modules
{
    public class Box
    {
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    private int _minimumSize = 3;

    public Box(Random random, int maxX, int maxY) { }
    public Box(int x, int y, int width, int height) { }
    public int GetTopRowY() { }
    public int GetBottomRowY() { }
    }
}