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
using System.Globalization;

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

        static int DiceRoll()
        {
            Random rnd = new Random(); //create random number
            int die = rnd.Next(1, 7); //first dice roll
            return die;
        }


        static void GameofCraps()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.CurrencyNegativePattern = 1;
            Console.WriteLine("|---------------|");
            Console.WriteLine("| Game of Craps |");
            Console.WriteLine("|---------------|\n");

            string playAgain = "y";
            //string msg = " ";
            double netWin = 0;
            do {
                Random rnd = new Random(); //create random number
                int die1 = DiceRoll(); //first dice roll
                int die2 = DiceRoll(); //second dice roll
                int sum = die1 + die2;
                double bet = 0;
                int newsum = 0;

                bool sessionDone = false;
                Console.Write("Enter amount to bet: ");
                bet = double.Parse(Console.ReadLine());
                Console.WriteLine($"You rolled {die1} + {die2} = {sum}");
                if ((sum == 7) || (sum == 11)) {
                    Console.WriteLine($"You win {bet:c}");
                    netWin+=bet;
                }
                else if ((sum == 2) || (sum == 3) ||(sum == 12)) {
                    Console.WriteLine($"You lost {bet:c}");
                    netWin-=bet;
                }
                else{
                    int point = sum;
                    int die3 = DiceRoll(); //first dice roll
                    int die4 = DiceRoll(); //second dice roll
                    newsum = die3 + die4;
                    Console.WriteLine($"Point is {sum}");
                    Console.WriteLine($"You rolled {die3} + {die4} = {newsum}");

                    while ((point != newsum) || (newsum != 7)){
                        if (newsum == point){
                            Console.WriteLine($"You win {bet:c}");
                            netWin+=bet;
                            break;
                        }
                        else if (newsum == 7){
                            Console.WriteLine($"You lost {bet:c}");
                            netWin-=bet;
                            break;
                        }
                        int die5 = DiceRoll(); //first dice roll
                        int die6 = DiceRoll(); //second dice roll

                        newsum = die5 + die6;
                        Console.WriteLine($"You rolled {die5} + {die6} = {newsum}");

                    }

                }

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
            string formatted = string.Format(culture, "{0:C2}", netWin);
            Console.WriteLine($"Your net winning is {formatted}");
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
