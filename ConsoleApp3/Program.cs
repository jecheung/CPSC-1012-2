using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = GetLength("Enter the number of rows", 1, 10);
            char c = GetCharacter("Enter a character to print: ");
            DisplayBox(num, c);
        }

        static int GetLength(string prompt, int low, int high)
        {
            bool invalidInput = true;
            int num = 0;

            while (invalidInput)
            {
                Console.WriteLine($"{prompt} between {low} and {high}: ");
                num = int.Parse(Console.ReadLine());
                if (num >= low && num <= high)
                    invalidInput = false;
                else
                    Console.WriteLine("Error: Invalid Input.");
            }
            return num;
        }

        static char GetCharacter(string prompt)
        {
            bool validInput = false;
            char c = 'c';

            while (!validInput)
            {
                Console.Write(prompt);
                c = char.Parse(Console.ReadLine());
                validInput = true;
            }
            return c;
        }

        static void DisplayBox(int length, char fillChar)
        {
            for (int i = 1; i <= length; i++)
            {
                DrawRow(length, fillChar);
                Console.Write("\n");
            }
        }

        static void DrawRow(int len, char c)
        {
            for (int i = 1; i <= len; i++)
            {
                Console.Write($"{c}");
            }

        }
    }
}
