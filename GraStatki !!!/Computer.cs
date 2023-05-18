using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraStatki
{
    public class Computer
    {
        public Board Board { get; private set; }
        private Random random;
        public Computer()
        {
            Board = new Board();
            random = new Random();
        }

        public void SetShips()
        {
            for (int i = 4; i > 0; i--)
            {
                for (int j = 0; j < 5 - i; j++)
                {
                    while (true)
                    {
                        int x = random.Next(10);
                        int y = random.Next(10);
                        bool horizontal = random.Next(2) == 0;
                        Ship ship = new Ship(i, x, y, horizontal);
                        if (Board.CanPlaceShip(ship))
                        {
                            Board.PlaceShip(ship);
                            break;
                        }
                    }
                }
            }
        }

        public void TakeTurn(Board enemyBoard)
        {
            while (true)
            {
                int x = random.Next(10);
                int y = random.Next(10);
                Console.WriteLine($"Komputer strzela w pole {Convert.ToChar(x + 'A')}{y}.");
                if (enemyBoard.Shoot(x, y))
                {
                    Console.WriteLine("Trafiony!");
                    enemyBoard.Print();
                    if (enemyBoard.AllShipsSunk())
                    {
                        Console.WriteLine("Niestety, przegrałeś.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Pudło!");
                    enemyBoard.Print();
                    return;
                }
            }
        }
    }
}
