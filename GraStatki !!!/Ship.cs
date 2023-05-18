using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraStatki
{
    public class Ship
    {
        public int Length { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool Horizontal { get; private set; }
        public Ship(int length, int x, int y, bool horizontal)
        {
            Length = length;
            X = x;
            Y = y;
            Horizontal = horizontal;
        }

        public bool IsSunk(char[,] board)
        {
            for (int i = 0; i < Length; i++)
            {
                int x = X + (Horizontal ? i : 0);
                int y = Y + (Horizontal ? 0 : i);
                if (board[x, y] != 'X')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
