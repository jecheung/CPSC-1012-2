using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_Exercise4_JordanCheung
{
    class Program
    {
        static void Main(string[] args)
        {
            double interestRatePercent, interestRate, balance;
            int totalYears, year;

            Console.Write("Enter amount deposited(in dollars): ");
            int principal = int.Parse(Console.ReadLine());
            Console.Write("Enter year(s) to invest: ");
            totalYears = int.Parse(Console.ReadLine());
            Console.Write("Enter the interest rate percentage: ");
            interestRatePercent = double.Parse(Console.ReadLine());

            interestRate = interestRatePercent / 100;

            Console.WriteLine("Year\tBalance");
            for (int i = 1; i <= totalYears; i++)
            {
                year = i;
                balance = principal * Math.Pow((1 + interestRate),year);
                Console.WriteLine($"{year}\t{balance:c}");
            }
        }
    }
}
