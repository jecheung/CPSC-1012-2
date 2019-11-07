/*
Purpose:        Have to menu to allow the user to select one of th two games to play or to quit the program. 
                Game of Craps - pass line bet by rolling two six-sided dice, the first roll of the dice is the "come out roll" If rolled a 7 or 11 you auto win, if rolled 2,3, or 12 you auto lose.
                any other number becomes "the point". The player keeps rolling the dice until either 7 or "the point" is rolled. the point rolled first the player wins, if it a 7 then the player loses
                Game of Pig - two-player dice game which the first player to reach the point total wins. On each turn if the player rolls a 1 then the player gets no new points and becomes the other
                players turn. If the player rolles 2 - 6 then they can either ROLL AGAIN or HOLD(the sum of all rolls is added to the player's score) then its next turn. The computer should play according
                to the rules, keeping rolling when its is the computer's turn until it has accumulated 10 or more points then hold. If the computer wins or rolls a 1 then the turn ends immediately. Human should roll first.

Input:          menu number of choice, game of craps: enter bet and y/n to play again. Game of Pig: enter point total to play for, enter r/h for roll or hold

Output:         Menu: the game. Game of Craps: The outcome of the two dice rolls, your point, how much you win/lose, net winning. Game of Pig: one die outcome, turn score, total points, computers turn.  

Author:         Jordan Errol Cheung

Last modified:  2019.11.05
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePortfolio04_JordanCheung
{
    class Program
    {
        static void DisplayMenu()
        {
            Console.WriteLine("|-----------------|");
            Console.WriteLine("| CPSC1012 Casino |");
            Console.WriteLine("|-----------------|");
            Console.WriteLine("| 1. Play Craps   |");
            Console.WriteLine("| 2. Play Pig     |");
            Console.WriteLine("| 0. Exit Program |");
            Console.WriteLine("|-----------------|");
        }

        static void selectMenu()
        {
            bool invalidInput = true;
            string choice = " ";
            while (invalidInput) //keeps the game going
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Enter your menu number choice > ");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "0":
                            Console.WriteLine("Good-bye and thanks for coming to the CPSC1012 casino.");
                            invalidInput = false;
                            break;
                        case "1":
                            GameofCraps();
                            break;
                        case "2":
                            GameofPig();
                            break;
                        default:
                            Console.WriteLine($"{choice} is not a valid menu choice. Try again."); 
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }



        static void GameofCraps()
        {

            Console.WriteLine("|---------------|");
            Console.WriteLine("| Game of Craps |");
            Console.WriteLine("|---------------|\n");

            string playAgain = "y";
            //string msg = " ";

            do {
                Random rnd = new Random(); //create random number
                int die1 = rnd.Next(1, 7); //first dice roll
                int die2 = rnd.Next(1, 7); //second dice roll
                int sum = die1 + die2;
                int bet = 0;

                bool sessionDone = false;
                Console.Write("Enter amount to bet: ");
                bet = int.Parse(Console.ReadLine());
                Console.WriteLine($"You rolled {die1} + {die2} = {sum}");
                do{
                    Console.Write("Do you want to play again (y/n): ");
                    playAgain = Console.ReadLine();
                    if ((playAgain == "n") || (playAgain == "y")){
                        sessionDone = true;
                    }
                    else {
                        Console.WriteLine($"\"{playAgain}\" is not a valid choice. Try again.");
                        sessionDone = false;
                    }
                }while (sessionDone != true);

            }while (playAgain != "n");
        }


        static void  GameofPig()
        {
            Console.WriteLine("|-------------|");
            Console.WriteLine("| Game of Pig |");
            Console.WriteLine("|-------------|\n");
        }

        static void Main(string[] args)
        {

            selectMenu(); //starts the menu

        }
    }
}
