/*
Purpose: To calculate the balance of the account after a specified number years with accumulated interest over time that has been deposited into a saving account

Input: investment amount, annual interest rate in percentage, compound periods, number of years

Output: Future value, investmnet amount, annual interest rate, compounds per year

Author:         Jordan Errol Cheung
Last modified:  2019.09.18

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double invested, principalAmount, annualIR, compoundP, years;
            double compoundY, rateCompound, percentIR;

            Console.WriteLine("-------------------------");
            Console.WriteLine("| Compound Interest App |");
            Console.WriteLine("-------------------------");

            Console.WriteLine("\n This program is used to calulate the future investment value.");

            Console.WriteLine("Enter investment amount: ");
            principalAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter annual interest rate in percentage: ");
            annualIR = double.Parse(Console.ReadLine());
            percentIR = annualIR / 100;

            Console.WriteLine("Compound periods can be 1 for yearly, 2 for semi-annually, 4 for quarterly, or 12 for monthly");
            Console.WriteLine("Enter number of compound periods (1, 2, 4, 12): ");
            compoundP = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of years: ");
            years = double.Parse(Console.ReadLine());

            compoundY = compoundP * years;
            rateCompound = percentIR / compoundP;

            invested = principalAmount * Math.Pow((1 + rateCompound),compoundY);
            
            Console.WriteLine($"\n Future Value is {invested:C}");
            Console.WriteLine($"Investment amount: {principalAmount:C}");
            Console.WriteLine($"Annual Interest Rate: {annualIR:n}%");
            Console.WriteLine($"Compounds per year: {compoundP}");
        }
    }
}
