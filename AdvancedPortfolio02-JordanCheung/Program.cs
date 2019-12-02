using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPortfolio02_JordanCheung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************");
            Console.WriteLine("* Tic-Tac-Toe Game *");
            Console.WriteLine("********************");
            var game = new TicTacToe();

            Console.WriteLine("The cell numbers for the game are shown below.");
            game.Draw();
            Play(game);
        }

        static void Play(TicTacToe game)
        {
            Console.WriteLine($"This feature is not yet implemented");
        }

        private static int CheckWin()
        {
            if arr[1] == arr[2] && 
        }
    }

    public class TicTacToe
    {
        private char[,] _board = new char[3, 3];

        public char[,] Board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
            }
        }

        public TicTacToe()
        {
            int count = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = count.ToString()[0];
                    count++;
                }
            }
        }

        public void Draw()
        {
            Console.WriteLine("\n-------------");
            Console.WriteLine($"| {Board[2, 0]} | {Board[2, 1]} | {Board[2, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[1, 0]} | {Board[1, 1]} | {Board[1, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[0, 0]} | {Board[0, 1]} | {Board[0, 2]} |");
            Console.WriteLine("-------------");
        }

        public void DrawIn()
        {

        }


    }
}
