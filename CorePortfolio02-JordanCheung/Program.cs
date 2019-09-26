/*
Purpose:        To calculate the overestimate or underestimate if the estimated flight time is too large or too small to the actual flight time

Input:          Estimated flight time in minutes, actual flight time in minutes

Output:         Estimated time acceptability or estimated time too large or small and by how much

Author:         Jordan Errol Cheung

Last modified:  2019.09.26
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePortfolio02_JordanCheung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("| Flight Time Estimate |");
            Console.WriteLine("------------------------");
            Console.WriteLine("This program is used to determine if the estimated flight time is acceptable.");

            int estimatedFT, actualFT, difference, acceptError = 0, estimatedTime;

            Console.Write("Enter estimated flight time in minutes: ");
            estimatedFT = int.Parse(Console.ReadLine());
            Console.Write("Enter actual flight time in minutes: ");
            actualFT = int.Parse(Console.ReadLine());

            if (estimatedFT >= 0 && estimatedFT <= 29)
                acceptError = 1;
            else if (estimatedFT >= 30 && estimatedFT <= 59)
                acceptError = 2;
            else if (estimatedFT >= 60 && estimatedFT <= 89)
                acceptError = 3;
            else if (estimatedFT >= 90 && estimatedFT <= 119)
                acceptError = 4;
            else if (estimatedFT >= 120 && estimatedFT <= 179)
                acceptError = 6;
            else if (estimatedFT >= 180 && estimatedFT <= 239)
                acceptError = 8;
            else if (estimatedFT >= 240 && estimatedFT <= 359)
                acceptError = 13;
            else if (estimatedFT >= 360)
                acceptError = 17;
            else 
                Console.WriteLine("Invalid Input");

            difference = estimatedFT - actualFT;
            //fix this it is going pass the first if
            if (difference >= acceptError && difference <= acceptError)
                Console.WriteLine("Estimated time is acceptable");
            else if (difference > acceptError){
                estimatedTime = difference - acceptError;
                Console.WriteLine($"Estimated time too large (by {estimatedTime} minutes)");
                }
            else if (difference < acceptError ){
                estimatedTime = Math.Abs(difference + acceptError);
                Console.WriteLine($"Estimated time too small (by {estimatedTime} minutes)");
                }
            else
                {
                Console.WriteLine("Invalid input");
                }
        }
    }
}
