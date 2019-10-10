using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inclass3
{
    class Program
    {
        static void Main(string[] args)
        {
            int month, year, days=0;
            string monthName = " ";
            Console.Write("Please enter the month number (1-12): ");
            month = int.Parse(Console.ReadLine());
            Console.Write("Please enter the year: ");
            year = int.Parse(Console.ReadLine());

            switch(month)
            {
                case 1:
                    monthName = "January";
                    days = 31;
                    break;
                case 2:
                    monthName = "February";
                    if ((year % 4 == 0 && year % 100 !=0) || (year % 400 == 0))
                    {
                        days = 29;
                    }
                    else
                        days = 28;
                    break;
                case 3:
                    monthName = "March";
                    days = 31;
                    break;
                case 4:
                    monthName = "April";
                    days = 30;
                    break;
                case 5:
                    monthName = "May";
                    days = 31;
                    break;
                case 6:
                    monthName = "June";
                    days = 30;
                    break;
                case 7:
                    monthName = "July";
                    days = 31;
                    break;
                case 8:
                    monthName = "August";
                    days = 31;
                    break;
                case 9:
                    monthName = "September";
                    days = 30;
                    break;
                case 10:
                    monthName = "October";
                    days = 31;
                    break;
                case 11:
                    monthName = "November";
                    days = 30;
                    break;
                case 12:
                    monthName = "December";
                    days = 31;
                    break;
            }
            Console.WriteLine($"There are {days} days in {monthName} {year}");
        }
    }
}
