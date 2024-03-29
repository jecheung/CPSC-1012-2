﻿/*
Purpose:        Have to menu to allow the user to select one of th two games to play or to quit the program. 
                Game of Craps - pass line bet by rolling two six-sided dice, the first roll of the dice is the "come out roll" If rolled a 7 or 11 you auto win, if rolled 2,3, or 12 you auto lose.
                any other number becomes "the point". The player keeps rolling the dice until either 7 or "the point" is rolled. the point rolled first the player wins, if it a 7 then the player loses
                Game of Pig - two-player dice game which the first player to reach the point total wins. On each turn if the player rolls a 1 then the player gets no new points and becomes the other
                players turn. If the player rolles 2 - 6 then they can either ROLL AGAIN or HOLD(the sum of all rolls is added to the player's score) then its next turn. The computer should play according
                to the rules, keeping rolling when its is the computer's turn until it has accumulated 10 or more points then hold. If the computer wins or rolls a 1 then the turn ends immediately. Human should roll first.

Input:          menu number of choice, game of craps: enter bet and y/n to play again. Game of Pig: enter point total to play for, enter r/h for roll or hold

Output:         Menu: the game. Game of Craps: The outcome of the two dice rolls, your point, how much you win/lose, net winning. Game of Pig: one die outcome, turn score, total points, computers turn.  

Author:         Jordan Errol Cheung

Last modified:  2019.11.14
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

        static int DiceRoll(Random rnd)
        {
            int die = rnd.Next(1, 7); //pass rnd through to roll the dice
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
            double netWin = 0;
            Random rnd = new Random(); //create random number

            do {
                int die1 = DiceRoll(rnd); //first dice roll
                int die2 = DiceRoll(rnd); //second dice roll
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

                    Console.WriteLine($"Point is {sum}");
                    bool stopRoll = false;

                    do {
                        int die3 = DiceRoll(rnd); //first dice roll
                        int die4 = DiceRoll(rnd); //second dice roll
                        newsum = die3 + die4;

                        Console.WriteLine($"You rolled {die3} + {die4} = {newsum}");
                        if (newsum == point){
                            Console.WriteLine($"You win {bet:c}");
                            netWin+=bet;
                            stopRoll = true;
                        }
                        else if (newsum == 7){
                            Console.WriteLine($"You lost {bet:c}");
                            netWin-=bet;
                            stopRoll = true;
                        }
                    }while(stopRoll != true);
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


        static int ComputerTurn(int computersPoints, int point)
        {
            Random rnd = new Random();
            int points = 0;//computers turn points
            bool quit = false;

            Console.WriteLine("\nIts the computers turn.");

            do {
                int die = DiceRoll(rnd);
                Console.WriteLine($"Computer rolled a {die}");

                switch(die)
                {
                    case 1:
                        points = 0;
                        Console.WriteLine($"Computer turn total is {points}");
                        quit = true;
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:                
                        points+=die;
                        break;
                }
            }while((points < 10) && (quit != true) && (points < point));

            computersPoints+=points;
            if (points != 0 && computersPoints < point){
                Console.WriteLine($"Computer HOLD");
                Console.WriteLine($"Computer turn total is {points}");
            }
            
            return computersPoints;
        }

        static void  GameofPig()
        {
            Console.WriteLine("|-------------|");
            Console.WriteLine("| Game of Pig |");
            Console.WriteLine("|-------------|\n");

            int point = 0;
            Console.Write("Enter the point total to play for: ");
            point = int.Parse(Console.ReadLine());

            string playAgain = "y"; //reroll r/h
            Random rnd = new Random(); //create random number
            bool end = false;
            int playerPoints = 0;
            int totalPlayerPoints = 0;
            int compPoints = 0;
            bool sessionDone = false;
            int temp = 0;

            Console.WriteLine("It's your turn.");
            do {
                int die = DiceRoll(rnd);
                Console.WriteLine($"You rolled a {die}");
                
                switch(die)
                {
                    case 1:
                        playerPoints = 0;
                        temp = 0;
                        Console.WriteLine($"Your turn score is {playerPoints}");

                        if (compPoints >= point)
                            Console.WriteLine("Computer WIN");
                        else if (totalPlayerPoints >= point)
                            Console.WriteLine("You WIN");

                        Console.WriteLine($"\nYour total points: {totalPlayerPoints}");
                        Console.WriteLine($"Computer total points: {compPoints}");
                        compPoints = ComputerTurn(compPoints,point);

                        if (compPoints >= point)
                           Console.WriteLine("Computer WIN");
                        Console.WriteLine($"\nYour total points: {totalPlayerPoints}");
                        Console.WriteLine($"Computer total points: {compPoints}");

                        if (compPoints < point)
                            Console.WriteLine("\nIt's your turn.");
                        
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:                
                        playerPoints+=die;
                        temp = playerPoints + totalPlayerPoints;
                        
                        while ((playerPoints < point) && (compPoints < point) && (temp < point)){

                            Console.Write("Enter r to roll or h to hold (r/h): ");
                            playAgain = Console.ReadLine();
                            if (playAgain == "r"){
                                

                                break;
                            }
                            else if (playAgain == "h"){
                                Console.WriteLine($"You HOLD");
                                totalPlayerPoints+=playerPoints;
                                Console.WriteLine($"Your turn score is {playerPoints}");
                                
                                if (totalPlayerPoints >= point)
                                    Console.WriteLine("You WIN");

                                Console.WriteLine($"\nYour total points: {totalPlayerPoints}");
                                Console.WriteLine($"Computer total points: {compPoints}");
                                compPoints = ComputerTurn(compPoints,point);
                                temp = 0;

                                if (compPoints >= point)
                                    Console.WriteLine("Computer WIN");
                                Console.WriteLine($"\nYour total points: {totalPlayerPoints}");
                                Console.WriteLine($"Computer total points: {compPoints}");
                                
                                playerPoints = 0;
                                if (compPoints < point)
                                    Console.WriteLine("\nIt's your turn.");
                                break;
                            }
                            else {
                                Console.WriteLine($"\"{playAgain}\" is not a valid choice. Try again.");

                            }
                        }
                        if (temp >= point){
                            Console.WriteLine($"Your turn score is {temp}");
                            Console.WriteLine("You WIN");
                            Console.WriteLine($"\nYour total points: {temp}");
                            Console.WriteLine($"Computer total points: {compPoints}");
                        }
                        break;
                }
            }while((totalPlayerPoints < point) && (compPoints < point) && (temp < point));

        }
      
        static void Main(string[] args)
        {
            selectMenu(); //starts the menu
        }
    }
}
