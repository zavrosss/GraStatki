using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraStatki
{
    public class Game
    {
        private Player player;
        private Computer computer;

        public Game()
        {
            player = new Player();
            computer = new Computer();
        }

        public void Start()
        {
            Console.WriteLine("Witaj w grze!");
            Console.WriteLine("Rozpocznij ustawianie swoich statków");
            player.SetShips();
            computer.SetShips();
            Console.Clear();
            Console.WriteLine("Ustawianie statków zakończone. Rozpoczynamy grę.");

            while (true)
            {
                Console.WriteLine("Twoja tura.");
                player.TakeTurn(computer.Board);
                if (computer.Board.AllShipsSunk())
                {
                    Console.WriteLine("Gratulacje! Wygrałeś!");
                    WaitForKeypressAndClear();
                    break;
                }

                Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Tura komputera.");
                computer.TakeTurn(player.Board);
                if (player.Board.AllShipsSunk())
                {
                    Console.WriteLine("Niestety, przegrałeś.");
                    WaitForKeypressAndClear();
                    break;
                }

                Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Koniec gry. Naciśnij dowolny klawisz, aby zakończyć.");
            Console.ReadKey();
        }

        private void WaitForKeypressAndClear()
        {
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
