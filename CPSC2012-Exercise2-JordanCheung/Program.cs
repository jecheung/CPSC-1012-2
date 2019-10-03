/*
Purpose:        To calculate the weekly pay of an employee

Input:          Employee Number, Annual Salary(for employee number >= 1000), Hours Worked(for employee number < 1000), Hourly Rate(for employee number < 1000)

Output:         Employee Number, Employee's weekly wage

Author:         Jordan Errol Cheung

Last modified:  2019.10.03
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC2012_Exercise2_JordanCheung
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeenumber;
            double annual, hours, hourRate, wage = 0, hourDiff, overtime;

            Console.Write("Please enter your Employee Number: ");
            employeenumber = int.Parse(Console.ReadLine());

            if (employeenumber >= 1000)
                {
                    Console.Write("Enter your Annual Salary: ");
                    annual = double.Parse(Console.ReadLine());
                    wage = annual / 52;

                }
            else if (employeenumber < 1000)
                {
                    Console.Write("Enter your Hours Worked: ");
                    hours = double.Parse(Console.ReadLine());
                    Console.Write("Enter your Hourly Rate: ");
                    hourRate = double.Parse(Console.ReadLine());
                    if (hours > 44)
                    {
                        hourDiff = hours - 44;
                        overtime = hourDiff * (hourRate * 1.5);
                        wage = overtime + (44 * hourRate);

                    }
                    else if (hours <= 44)
                    {
                        wage = hours * hourRate;

                    }
                    
                }             
            else
                Console.WriteLine("Not a employee number");
            Console.WriteLine($"Wage for employee #{employeenumber} is {wage:c2}");
        }
    }
}
