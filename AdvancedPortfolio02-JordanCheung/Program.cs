using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AdvancedPortfolio02_JordanCheung
{
    class Program
    {
        static char[] arr = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        static int player = 1; //By default player 1 is set  
        static int choice; //This holds the choice at which position user want to mark   

        // The flag veriable checks who has won if it's value is 1 then some one has won the match if -1 then Match has Draw if 0 then match is still running  

        static int flag = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("********************");
            Console.WriteLine("* Tic-Tac-Toe Game *");
            Console.WriteLine("********************");
            var game = new TicTacToe();

            Console.WriteLine("The cell numbers for the game are shown below.");
            
            Play(game);
        }

        static void Play(TicTacToe game)
        {
            string playAgain = "y";
            bool sessionDone = false;
            do{
                game.Draw();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = ' ';
                }
                do

                {

                    if (player % 2 == 0)//checking the chance of the player  

                    {

                        Console.Write("Enter cell number (1-9) for player O: ");

                    }

                    else

                    {

                        Console.Write("Enter cell number (1-9) for player X: ");

                    }


                

                    choice = int.Parse(Console.ReadLine());//Taking users choice   
                

                    // checking that position where user want to run is marked (with X or O) or not  

                    if (arr[choice] != 'X' && arr[choice] != 'O')

                    {

                        if (player % 2 == 0) //if chance is of player 2 then mark O else mark X  

                        {

                            arr[choice] = 'O';

                            player++;

                        }

                        else

                        {

                            arr[choice] = 'X';

                            player++;

                        }

                    }

                    else //If there is any possition where user want to run and that is already marked then show message and load board again  

                    {

                        Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);

                        Console.WriteLine("\n");

                

                    }
                    Board();
                    flag = CheckWin();// calling of check win  

                } while (flag != 1 && flag != -1);// This loof will be run until all cell of the grid is not marked with X and O or some player is not win  


                if (flag == 1)// if flag value is 1 then some one has win or means who played marked last time which has win  

                {

                    Console.WriteLine("Player {0} wins!", (arr[choice]));

                }

                else// if flag value is -1 the match will be draw and no one is winner  

                {

                    Console.WriteLine("It's a Draw!");

                }

                do {
                    Console.Write("Do you want to guess another word? Enter y or n > ");
                    playAgain = Console.ReadLine();
                    Console.WriteLine("");
                    if ((playAgain == "y") || (playAgain == "n")){
                        sessionDone = true;
                    }
                    else {
                        Console.WriteLine($"\"{playAgain}\" is not a valid choice. Try Again.");
                        sessionDone = false;
                    }   
                }while (sessionDone != true);
            }while (playAgain != "n");
            Console.WriteLine("Good-bye and thanks for playing my Tic-Tac-Toe game.");
        }

        private static int CheckWin()
        {
            #region Horzontal Winning Condtion

            //Winning Condition For First Row   
            if (arr[1] != ' ' || arr[2] != ' ' || arr[3] != ' ')
                if (arr[1] == arr[2] && arr[2] == arr[3])

                {

                    return 1;

                }

            //Winning Condition For Second Row   
            if (arr[4] != ' ' || arr[5] != ' ' || arr[6] != ' ')
                if (arr[4] == arr[5] && arr[5] == arr[6])

                {

                    return 1;

                }

            //Winning Condition For Third Row   
            if (arr[7] != ' ' || arr[8] != ' ' || arr[9] != ' ')
                if (arr[7] == arr[8] && arr[8] == arr[9])

                {

                    return 1;

                }

            #endregion



            #region vertical Winning Condtion

            //Winning Condition For First Column       
            if (arr[1] != ' ' || arr[4] != ' ' || arr[7] != ' ')
                if (arr[1] == arr[4] && arr[4] == arr[7])

                {

                    return 1;

                }

            //Winning Condition For Second Column  
            if (arr[2] != ' ' || arr[5] != ' ' || arr[8] != ' ')
                if (arr[2] == arr[5] && arr[5] == arr[8])

                {

                    return 1;

                }

            //Winning Condition For Third Column  
            if (arr[3] != ' ' || arr[6] != ' ' || arr[9] != ' ')
                if (arr[3] == arr[6] && arr[6] == arr[9])

                {

                    return 1;

                }

            #endregion



            #region Diagonal Winning Condition
            if (arr[1] != ' ' || arr[5] != ' ' || arr[9] != ' ')
                if (arr[1] == arr[5] && arr[5] == arr[9])

                {

                    return 1;

                }
            if (arr[3] != ' ' || arr[5] != ' ' || arr[7] != ' ')
                if (arr[3] == arr[5] && arr[5] == arr[7])

                {

                    return 1;

                }

            #endregion



            #region Checking For Draw

            // If all the cells or values filled with X or O then any player has won the match  

            if (arr[1] != ' ' && arr[2] != ' ' && arr[3] != ' ' && arr[4] != ' ' && arr[5] != ' ' && arr[6] != ' ' && arr[7] != ' ' && arr[8] != ' ' && arr[9] != ' ')

            {

                return -1;

            }

            #endregion



            else

            {

                return 0;

            }
        }

        private static void Board()

        {

            Console.WriteLine("\n-------------");
            Console.WriteLine($"| {arr[1]} | {arr[2]} | {arr[3]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {arr[4]} | {arr[5]} | {arr[6]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {arr[7]} | {arr[8]} | {arr[9]} |");
            Console.WriteLine("-------------");
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
            Console.WriteLine($"| {Board[0, 0]} | {Board[0, 1]} | {Board[0, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[1, 0]} | {Board[1, 1]} | {Board[1, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[2, 0]} | {Board[2, 1]} | {Board[2, 2]} |");
            Console.WriteLine("-------------");
        }


    }
}
