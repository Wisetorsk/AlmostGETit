using System.Dynamic;
using System.Runtime.CompilerServices;

namespace RandomSquares.Modules
{

    public class VirtualScreenCell
    {
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Left { get; private set; }
        public bool Right { get; private set; }

        public char GetCharacter()
        {

        }

        public void AddHorizontal()
        {

        }

        public void AddVertical() { }
        public void AddLowerLeftCorner() { }
        public void AddUpperLeftCorner() { }
        public void AddUpperRightCorner() { }
        public void AddLowerRightCorner() { }
    }

}