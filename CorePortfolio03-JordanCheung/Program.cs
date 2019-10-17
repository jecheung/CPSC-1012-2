/*
Purpose:        To create slot machine, a gambling device that the user inserts money and presses a key to simulate a lever on a slot machine. When two or more
                images matches, the user wins an amount of money that the slot machine dispenses back to the user.

Input:          Amount of money to enter into the slot machine

Output:         3 words from the list: Cherries, Oranges, Plums, Bells, Melons, Bars. Message if words match and amount of money won, total amount deposited, total amount won, net gain/loss total
                playing again message

Author:         Jordan Errol Cheung

Last modified:  2019.10.17
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePortfolio03_JordanCheung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("| Slot Machine Simulator |");
            Console.WriteLine("--------------------------");
            Console.WriteLine("This program simulators a slot machine.");

            int amount = 0;
            int net, totalWon, totalDeposited;
            Random rnd = new Random();
            int ranNum1 = rnd.Next(0, 6);
            int ranNum2 = rnd.Next(0, 6);
            int ranNum3 = rnd.Next(0, 6);
            string word1 = "", word2 = " ", word3 = " ";
            for (int i = 1; i <= 3; i++)
            {
                switch (ranNum1)
                {
                    case 0:
                        word1 = "Cherries";
                        break;
                    case 1:
                        word1 = "Oranges";
                        break;
                    case 2:
                        word1 = "Plums";
                        break;
                    case 3:
                        word1 = "Bells";
                        break;
                    case 4:
                        word1 = "Melons";
                        break;
                    case 5:
                        word1 = "Bars";
                        break;
                }
            //need to find a easier way to random the numbers
            //get the word then save the amount deposited, ask for play again everytime after the play, error messages, 2x for two copies 3x for three copies
            }
            Console.Write("Enter the amount to deposit into the slot machine: ");
            amount = int.Parse(Console.ReadLine());



        }
    }
}
