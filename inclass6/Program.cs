using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inclass6
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = GetNumber("Length of side = ", 1, 100);
            string c = GetCharacter("Fill box with ");
            Console.WriteLine("Empty Box");
            DrawBox(num);
            Console.WriteLine("\nFilled Box");
            DrawBox(num, c);
        }

        static int GetNumber(string prompt, int low, int high)
        {
            bool invalidInput = true;
            int num = 0;

            while (invalidInput)
            {
                try
                {
                    Console.Write($"{prompt}");
                    num = int.Parse(Console.ReadLine());
                    if (num >= low && num <= high)
                        invalidInput = false;
                    else
                        Console.WriteLine("Error: Invalid Input.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return num;
        }

        static string GetCharacter(string msg)
        {
            bool validInput = false;
            string c = "c";

            while (!validInput)
            {
                Console.Write(msg);
                try
                {
                    c = Console.ReadLine();
                    validInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return c;
        }

        static void DrawBox(int rows)
        {
            string c = " ";
            DrawBox(rows, c);
        }

        static void DrawBox(int rows, string drawChar)
        {
            int i, j;
            for (int k = 1; k <= rows; k++)
            {  
                Console.Write("-");
            }
            Console.Write("\n");
            for (i = 2; i <= rows-1; i++)
            {
                for (j = 1; j <= rows; j++)
                {
                    if (i == 1 || i == rows || j == 1 || j == rows)
                        Console.Write("|");
                    else
                        Console.Write($"{drawChar}");
                }
                Console.Write("\n");
            }
            for (int l = 1; l <= rows; l++)
            {  
                Console.Write("-");
            }
        }
    }
}
/*
static void DrawRow(int rows, char drawChar)
{
    for (int i = 1; i <= rows; i++)
    {
        if (i == 1 || i == rows)
            Console.Write($"|");
        else
            Console.Write($"{drawChar}");
    }
}
*/