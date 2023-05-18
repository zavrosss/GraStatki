using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraStatki
{
    public class Player
    {
        public Board Board { get; private set; }
        public Player()
        {
            Board = new Board();
        }

        public void SetShips()
        {
            for (int i = 4; i > 0; i--)
            {
                for (int j = 0; j < 5 - i; j++)
                {
                    while (true)
                    {
                        Console.Clear();
                        Board.Print();
                        Console.WriteLine($"Ustaw {i}-masztowiec. Statek nr {j + 1}.");
                        Console.Write("Wprowadź współrzędne (np. A0): ");
                        string userEntry = Console.ReadLine().ToUpper();
                        if (userEntry.Length < 2)
                        {
                            continue;
                        }
                        int x = userEntry[0] - 'A';
                        int y = int.Parse(userEntry.Substring(1));
                        if (x < 0 || x > 9 || y < 0 || y > 9)
                        {
                            continue;
                        }
                        Console.Write("Wybierz orientację statku (H - poziomo, V - pionowo): ");
                        char orientation = Char.ToUpper(Console.ReadKey().KeyChar);
                        if (orientation != 'H' && orientation != 'V')
                        {
                            continue;
                        }
                        Ship ship = new Ship(i, x, y, orientation == 'H');
                        if (Board.CanPlaceShip(ship))
                        {
                            Board.PlaceShip(ship);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nNie można postawić statku w tym miejscu. Spróbuj ponownie.");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public void TakeTurn(Board enemyBoard)
        {
            while (true)
            {
                enemyBoard.PrintEnemy();
                Console.Write("Gdzie chcesz strzelić? Podaj współrzędne (np. A0): ");
                string userEntry = Console.ReadLine().ToUpper();
                if (userEntry.Length < 2)
                {
                    continue;
                }
                int x = userEntry[0] - 'A';
                int y = int.Parse(userEntry.Substring(1));
                if (x < 0 || x > 9 || y < 0 || y > 9)
                {
                    continue;
                }
                if (enemyBoard.Shoot(x, y))
                {
                    Console.WriteLine("Trafiony!");
                    enemyBoard.Print();
                    if (enemyBoard.AllShipsSunk())
                    {
                        Console.WriteLine("Gratulacje! Wygrałeś!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Pudło!");
                    return;
                }
            }
        }
    }
}
