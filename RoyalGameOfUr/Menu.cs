using System;
using System.Collections.Generic;
using System.Text;

namespace Royal_Game_of_Ur
{
    class Menu
    {
        private Game game;

        public Menu()
        {
            game = new Game();
        }

        public void DrawMenu()
        {
            Console.WriteLine("!!! Welcome to the Royale Game Of Ur !!!");
            Console.WriteLine();
            Console.WriteLine("\t  ----------------");
            Console.WriteLine("\t  |   1 - Play   |");
            Console.WriteLine("\t  |   2 - Quit   |");
            Console.WriteLine("\t  ----------------");

            PlayerChoice();
        }

        //The choice that the player makes (Play or Quit)
        private void PlayerChoice()
        {
            ConsoleKey playerChoice;
            do
            {
                playerChoice = Console.ReadKey().Key;

                switch (playerChoice)
                {
                    case ConsoleKey.D1:
                        game.GameLoop();
                        break;
                    case ConsoleKey.D2:
                        Environment.Exit(0);
                        break;
                }
            } while (playerChoice != ConsoleKey.D1 && playerChoice != ConsoleKey.D2);
        }
    }
}