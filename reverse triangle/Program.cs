using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverse_triangle
{
    class Program
    {
        /*
         * Purpose: 
         *      - Draw triangles on the screen using a specificed character
         *        while handling invalid inputs.
         * 
         * Input: 
         *    - Size of Triangle
         *    - Character to draw triangle with.
         * 
         * Process:
         *      - Use a for loop to draw the correct number of characters. 
         *
         * Output:
         *    - Display Asterix Triangle
         *    - Display Custom Triangle
         *         
         * Written By: Robbin Law
         * Date Modified: 2019-10-07
         * */
        static void Main(string[] args)
        {
            int num = GetNumber("Enter the number of rows between 1 and 10: ");
            char c = GetCharacter("Enter a character to print: ");
            Console.WriteLine("\nDefault");
            DrawTriangle(num);
            Console.WriteLine("\nCustom");
            DrawTriangle(num, c);
        }

        static int GetNumber(string msg)
        {
            bool invalidInput = true;
            int num = 0;

            while (invalidInput)
            {
                Console.Write(msg);
                num = int.Parse(Console.ReadLine());
                if (num > 0 && num <= 10)
                    invalidInput = false;
                else
                    Console.WriteLine("Invalid Input. Number must be bigger than zero.");
            }
            return num;
        }

        static char GetCharacter(string msg)
        {
            bool validInput = false;
            char c = 'c';

            while (!validInput)
            {
                Console.Write(msg);
                c = char.Parse(Console.ReadLine());
                validInput = true;
            }
            return c;
        }

        static void DrawTriangle(int rows)
        {
            char c = '*';
            DrawTriangle(rows, c);
        }

        static void DrawTriangle(int rows, char drawChar)
        {
            for (int i = rows; i >= 1; i--)
            {
                DrawRow(i, drawChar);
            }
        }

        static void DrawRow(int len, char c)
        {
            for (int i = len; i > 0; i--)
            {
                Console.Write(c);
            }
            Console.Write("\n");
        }
    }
}
