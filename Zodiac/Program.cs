using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zodiac
{
    class Program
    {
        static void Main(string[] args)
        {
            double offset;
            double year;
            double preyear;
            string zodiac = "";

            Console.Write("Please Enter your birth year: ");
            year = double.Parse(Console.ReadLine());
            preyear = year - 1900;
            offset = preyear % 12;

            switch (offset)
            {
                case 0:
                    zodiac = "Rat";
                    break;

                case 1:
                    zodiac = "Ox";
                    break;

                case 2:
                    zodiac = "Tiger";
                    break;

                case 3:
                    zodiac = "Rabbit";
                    break;

                case 4:
                    zodiac = "Dragon";
                    break;

                case 5:
                    zodiac = "Snake";
                    break;

                case 6:
                    zodiac = "Horse";
                    break;

                case 7:
                    zodiac = "Goat";
                    break;

                case 8:
                    zodiac = "Monkey";
                    break;

                case 9:
                    zodiac = "Rooster";
                    break;

                case 10:
                    zodiac = "Dog";
                    break;

                case 11:
                    zodiac = "Pig";
                    break;

                default:
                    Console.WriteLine("Invalid (enter 1900 or higher");
                    break;
            }

            Console.WriteLine($"Your Zodiac sign is the {zodiac}");
        }
    }
}
