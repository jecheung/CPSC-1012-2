/*
Purpose:        Have to menu to allow the user to select one of th two games to play or to quit the program. 
                Game of Craps - pass line bet by rolling two six-sided dice, the first roll of the dice is the "come out roll" If rolled a 7 or 11 you auto win, if rolled 2,3, or 12 you auto lose.
                any other number becomes "the point". The player keeps rolling the dice until either 7 or "the point" is rolled. the point rolled first the player wins, if it a 7 then the player loses
                Game of Pig - two-player dice game which the first player to reach the point total wins. On each turn if the player rolls a 1 then the player gets no new points and becomes the other
                players turn. If the player rolles 2 - 6 then they can either ROLL AGAIN or HOLD(the sum of all rolls is added to the player's score) then its next turn. The computer should play according
                to the rules, keeping rolling when its is the computer's turn until it has accumulated 10 or more points then hold. If the computer wins or rolls a 1 then the turn ends immediately. Human should roll first.

Input:          Amount of money to enter into the slot machine

Output:         3 words from the list: Cherries, Oranges, Plums, Bells, Melons, Bars. Message if words match and amount of money won, total amount deposited, total amount won, net gain/loss total
                playing again message

Author:         Jordan Errol Cheung

Last modified:  2019.11.04
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
        
        static void Main(string[] args)
        {
            Console.WriteLine("|-----------------|");
            Console.WriteLine("| CPSC1012 Casino |");
            Console.WriteLine("|-----------------|");
            Console.WriteLine("| 1. Play Craps   |");
            Console.WriteLine("| 2. Play Pig     |");
            Console.WriteLine("| 0. Exit Program |");
            Console.WriteLine("|-----------------|");
            Console.WriteLine("Enter your menu number choice > ");
            
        }
    }
}
