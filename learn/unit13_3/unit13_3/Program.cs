using System;
using static System.Console;

namespace unit13_3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("BenjaminCards: a new and exciting card game.");
            WriteLine("To win you must have 7 cards of the same suit in" + " your hand.");
            WriteLine();
            bool inputOK = false;
            int choice = -1;
            do
            {
                WriteLine("How many players (2-7)?");
                string input = ReadLine();
                try
                {
                    choice = Convert.ToInt32(input);
                    if (choice >= 2 && choice <= 7)
                        inputOK = true;
                }
                catch
                {

                }
            } while (inputOK == false);
            Player[] players = new Player[choice];
            for (int p = 0; p < players.Length; p++)
            {
                WriteLine($"Player {p + 1},enter your name:");
                string playerName = ReadLine();
                players[p] = new Player(playerName);
            }
            Game newGame = new Game();
            newGame.setPlayers(players);
            int whoWon = newGame.PlayGame();
            WriteLine($"{players[whoWon].Nmae} has won the game!");
            ReadKey();
        }
    }
}
