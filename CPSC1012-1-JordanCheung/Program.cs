/* 
Purpose:        This program is to take your weight in pounds and height in inches to calculate your BMI(Body mass index)

Input:          weight, height

Ouput:          BMI(body mass index)

Author:         Jordan Errol Cheung

Last modified:  2019.09.19
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_1_JordanCheung
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight,height,bmi;
            double constant = 703;
          

            Console.Write("Please enter your weight in pounds: ");
            weight = double.Parse(Console.ReadLine());

            Console.Write("Please enter your height in inches: ");
            height = double.Parse(Console.ReadLine());

            bmi = (703 * weight) / (height * height);

            Console.WriteLine($"Your BMI is: {bmi:n1}");

        }
    }
}
