/*
Purpose:        To create slot machine, a gambling device that the user inserts money and presses a key to simulate a lever on a slot machine. When two or more
                images matches, the user wins an amount of money that the slot machine dispenses back to the user.

Input:          Amount of money to enter into the slot machine

Output:         3 words from the list: Cherries, Oranges, Plums, Bells, Melons, Bars. Message if words match and amount of money won, total amount deposited, total amount won, net gain/loss total
                playing again message

Author:         Jordan Errol Cheung

Last modified:  2019.10.31
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CorePortfolio03_JordanCheung
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("| Slot Machine Simulator |");
            Console.WriteLine("--------------------------");
            Console.WriteLine("This program simulators a slot machine.\n");

            double amount = 0;
            double net = 0, totalWon = 0, totalDeposited = 0;
            double winAmount;
            string slot1 = "", slot2 = " ", slot3 = " ";
            string msg = "", playAgain = "yes";
            bool sessionDone = false;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.CurrencyNegativePattern = 1;
            
            do {
                Console.Write("Enter the amount to deposit into the slot machine: ");
                amount = int.Parse(Console.ReadLine());
                
                if(amount > 0){
                    Random rnd = new Random();
                    int ranNum1 = rnd.Next(0, 6);
                    int ranNum2 = rnd.Next(0, 6);
                    int ranNum3 = rnd.Next(0, 6);
                    totalDeposited = totalDeposited + amount;
                    switch (ranNum1)
                    {
                        case 0:
                            slot1 = "Cherries";
                            break;
                        case 1:
                            slot1 = "Oranges";
                            break;
                        case 2:
                            slot1 = "Plums";
                            break;
                        case 3:
                            slot1 = "Bells";
                            break;
                        case 4:
                            slot1 = "Melons";
                            break;
                        case 5:
                            slot1 = "Bars";
                            break;
                    }
                    switch (ranNum2)
                    {
                        case 0:
                            slot2 = "Cherries";
                            break;
                        case 1:
                            slot2 = "Oranges";
                            break;
                        case 2:
                            slot2 = "Plums";
                            break;
                        case 3:
                            slot2 = "Bells";
                            break;
                        case 4:
                            slot2 = "Melons";
                            break;
                        case 5:
                            slot2 = "Bars";
                            break;
                    }
                    switch (ranNum3)
                    {
                        case 0:
                            slot3 = "Cherries";
                            break;
                        case 1:
                            slot3 = "Oranges";
                            break;
                        case 2:
                            slot3 = "Plums";
                            break;
                        case 3:
                            slot3 = "Bells";
                            break;
                        case 4:
                            slot3 = "Melons";
                            break;
                        case 5:
                            slot3 = "Bars";
                            break;
                    }
                    Console.WriteLine($"{slot1} {slot2} {slot3}");
                    
                    if (slot1 == slot2 && slot1 == slot3)
                    {
                        winAmount = amount * 3;
                        totalWon = totalWon + winAmount;
                        msg = "Three words match. You won 3x.";
                        sessionDone = true;
                    }
                    else if (slot1 == slot2 || slot1 == slot3 || slot2 == slot3)
                    {
                        winAmount = amount * 2;
                        totalWon = totalWon + winAmount;
                        msg = "Two words match. You won 2x.";
                        sessionDone = true;
                    }
                    
                    else{ 
                        amount = 0;
                        msg = "No words match. You won $0";
                        sessionDone = true;
                        }
                    net = totalWon - totalDeposited;
                    Console.WriteLine($"{msg}");
                    
                    do{
                        Console.Write("Do you want to play again (yes|no)? ");
                        playAgain = Console.ReadLine();
                        if ((playAgain == "yes") || (playAgain == "no")){
                            sessionDone = true;
                        }
                        else {
                            Console.WriteLine($"\"{playAgain}\" is not a valid choice. Try again.");
                            sessionDone = false;
                        }
                    }while (sessionDone != true);

                }
                else{
                    Console.WriteLine($"\"{amount}\" is not a valid amount. Try again.");
                }
               
            }while (playAgain != "no");
            string formatted = string.Format(culture, "{0:C2}", net);

            Console.WriteLine($"Total amount desposited: {totalDeposited:c}");
            Console.WriteLine($"Total amount won: {totalWon:c}");
            Console.WriteLine($"Net gain/loss total: {formatted}");      
        }
            

    }
}