/*
Purpose:        To play LOTTO MAX, LOTTO 6/49, and LOTTA EXTRA. LOTTO MAX: picking 7 unique numbers 1 to 50 To win a prize, numbers matched must appear in the same selection (line)
                LOTTO 6/49: picking 6 unique numbers from 1 to 49. numbers matched must appear in the same selection (line).
                LOTTO EXTRA: getting the system to generate 7 digits. To win the number drawn in exact order from the right-hand side to win (if the number doesnt match ends the check)

Input:          menu number of choice, 1. Change Lotto MAX winning numbers, 2. Change Lotto 6/49 winning numbers, 3. Change Lotto EXTRA winning numbers, 4. Play Lotto MAX, 5. Play Lotto 6/49
                0. Exit Program. generate or enter new numbers

Output:         Menu: the game. Change Lotto MAX/6/49/EXTRA winning numbers: new winning numbers. 
                Play Lotto MAX: current winning numbers plus bonus, new extra winning number, your quick pick numbers, your EXTRA number, MAX match, MAX prize, EXTRA match, EXTRA Prize
                Play 6/49: current winning numbers plus bonus, new extra winning, your quick pick numbers, your EXTRA number, 649 match, prize , EXTRA match and prize. Exit program message

Author:         Jordan Errol Cheung

Last modified:  2019.11.18
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePortfolio05_JordanCheung
{
    class Program
    {
        static void DisplayMenu()
        {
            Console.WriteLine("|-------------------------------------------|");
            Console.WriteLine("| CPSC1012 Lotto Centre                     |");
            Console.WriteLine("|-------------------------------------------|");
            Console.WriteLine("| 1. Change Lotto MAX winning numbers       |");
            Console.WriteLine("| 2. Change Lotto 6/49 winning numbers      |");
            Console.WriteLine("| 3. Change Lotto EXTRA winning numbers     |");
            Console.WriteLine("| 4. Play Lotto MAX                         |");
            Console.WriteLine("| 5. Play Lotto 6/49                        |");
            Console.WriteLine("| 0. Exit Program                           |");
            Console.WriteLine("|-------------------------------------------|");
        }

        static void selectMenu()
        {
            bool invalidInput = true;
            string choice = " ";
            while (invalidInput) //keeps the game going
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Enter your menu number choice > ");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "0":
                            Console.WriteLine("Good-bye and thanks for coming to the CPSC1012 Lotto Centre.");
                            invalidInput = false;
                            break;
                        case "1":
                            changeLottoMAX()
                            Console.WriteLine("The current Lotto MAX winning numbers are: ");
                            break;
                        case "2":
                            Console.WriteLine("The current Lotto 6/49 winning numbers are: ");
                            break;
                        case "3":
                            Console.WriteLine("The current Lotto EXTRA winning numbers are: ");
                            break;
                        case "4":
                            Console.WriteLine("Play Lotto MAX");
                            break;
                        case "5":
                            Console.WriteLine("Play Lotto 6/49");
                            break;
                        default:
                            Console.WriteLine($"{choice} is not a valid menu choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void changeLottoMAX()
        {
            List<int> lottonumbers = new List<string>();
            List<int> lottonumbers = new List<string>();
            dt = DateTime.Now;
            Random rnd = new Random(dt.Millisecond);
            int i = 0;
            while(i < 7)
            {
                int randomNumb = rnd.Next(1,51);
                for (i)
                if randomNumb
            }






            /* int c = 7;
            int [] numb = new int[c];
            int [] result = new int[c];
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            Random rnd = new Random(dt.Millisecond);
            for (int i = 1; i < c; i++)
            {
                numb[i] = rnd.Next(1,50);
            }
            Array.Sort(numb);
            int k = 0;
            int j = 0;
            for (int i =0; i < c -1; i++)
            {
                if (numb[i] == numb[i+1])
                {
                    result[k] = numb[i];
                    lottonumbers[k] = j += 1;
                }                
                else
                {
                    k += 1;
                    j = 0;
                }
            }
            for (int i = 0; i < lottonumbers) */
        }

        static void Main(string[] args)
        {
            selectMenu(); //starts the menu
        }
    }
}
