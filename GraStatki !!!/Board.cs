using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraStatki
{
    public class Board
    {
        private char[,] board;
        private List<Ship> ships;

        public Board()
        {
            board = new char[10, 10];
            ships = new List<Ship>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
                Console.Write(" ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(board[j, i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void PrintEnemy()
        {
            Console.WriteLine("  A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
                Console.Write(" ");
                for (int j = 0; j < 10; j++)
                {
                    if (board[j, i] == 'X' || board[j, i] == 'O')
                    {
                        Console.Write(board[j, i]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public bool CanPlaceShip(Ship ship)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                int x = ship.X + (ship.Horizontal ? i : 0);
                int y = ship.Y + (ship.Horizontal ? 0 : i);
                if (x < 0 || x > 9 || y < 0 || y > 9)
                {
                    return false;
                }
                if (board[x, y] != ' ')
                {
                    return false;
                }
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int nx = x + dx;
                        int ny = y + dy;
                        if (nx >= 0 && nx <= 9 && ny >= 0 && ny <= 9)
                        {
                            if (board[nx, ny] != ' ')
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceShip(Ship ship)
        {
            ships.Add(ship);
            for (int i = 0; i < ship.Length; i++)
            {
                int x = ship.X + (ship.Horizontal ? i : 0);
                int y = ship.Y + (ship.Horizontal ? 0 : i);
                board[x, y] = '#';
            }
        }

        public bool Shoot(int x, int y)
        {
            if (board[x, y] == 'X' || board[x, y] == 'O')
            {
                Console.WriteLine("Już strzelałeś w to miejsce!");
                return false;
            }
            if (board[x, y] == '#')
            {
                board[x,
    y] = 'X';
                foreach (Ship ship in ships)
                {
                    if (ship.IsSunk(board))
                    {
                        Console.WriteLine("Zatopiony!");
                    }
                }
                if (AllShipsSunk())
                {
                    Console.WriteLine("Gratulacje! Wygrałeś!");
                    return true;
                }
            }
            else
            {
                board[x, y] = 'O';
            }
            return false;
        }
        public bool AllShipsSunk()
        {
            foreach (Ship ship in ships)
            {
                if (!ship.IsSunk(board))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
