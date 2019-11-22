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
            List<int> lottoMAX = new List<int>();
            List<int> lotto649 = new List<int>();
            List<int> lottoEXTRA = new List<int>();
            lottoMAX = generateMAX();
            lotto649 = generate649();
            lottoEXTRA = generateEXTRA();
            while (invalidInput) //keeps the game going
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Enter your menu number choice > ");
                    choice = Console.ReadLine();
                    Console.Write("\n");
                    switch (choice)
                    {
                        case "0":
                            Console.WriteLine("Good-bye and thanks for coming to the CPSC1012 Lotto Centre.");
                            invalidInput = false;
                            break;
                        case "1":
                            
                            lottoMAX = changeLottoMAX(lottoMAX);
                            break;
                        case "2":
                            lotto649 = changeLotto649(lotto649);
                            break;
                        case "3":
                            lottoEXTRA = changeLottoEXTRA(lottoEXTRA);
                            break;
                        case "4":
                            playMAX(lottoMAX, lottoEXTRA);
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

        static void playMAX(List<int> lottonumbers, List<int> extra)
        {
            Console.Write("The current Lotto MAX winning numbers are: ");
            displayLottoMAX(lottonumbers);
            Console.Write("The current Lotto EXTRA winning numbers are: ");
            displayLottoEXTRA(extra);
            int count = 0;
            bool bonus = false;
            Console.Write("\nYour Lotto MAX quick pick numbers are: ");
            List<int> quickpick = generateQuickMAX();
            displayQuickLottoMAX(quickpick);
            Console.Write("\nYour Lotto EXTRA number is: ");
            List<int> quickExtra = generateEXTRA();
            displayLottoEXTRA(quickExtra);
            Console.Write("\n");
            for (int i = 0; i < quickpick.Count()-1; i++)
            {
                if (quickpick.Contains(lottonumbers[i]))
                    count++;
            }
            if (quickpick.Contains(lottonumbers[7])){
                bonus = true;
            }
            if (bonus==true){
                count++;
                Console.Write($"Your Lotto MAX Match: {count} / 7");
            }
            else
                Console.Write($"Your Lotto MAX Match: {count} / 7");
            prizeMAX(count, bonus);
            Console.Write("\n");
        }

        static void prizeMAX(int count, bool bonus)
        {
            Console.Write("\n");
            if (count < 3)
            {
                Console.Write($"Your Lotto MAX Prize: Please play again");
            }
            else if (count == 3)
            {
                Console.Write($"Your Lotto MAX Prize: Free Play");
            }
            else if (count == 3 && bonus == true)
            {
                Console.Write($"Your Lotto MAX Prize: $20");
            }
            else if (count == 4)
            {
                Console.Write($"Your Lotto MAX Prize: $20");
            }
            else if (count == 4 && bonus == true)
            {
                Console.Write($"Your Lotto MAX Prize: Share of 2.75% of Pools Fund");
            }
            else if (count == 5)
            {
                Console.Write($"Your Lotto MAX Prize: Share of 3.5% of Pools Fund");
            }
            else if (count == 5 && bonus == true)
            {
                Console.Write($"Your Lotto MAX Prize: Share of 1.5% of Pools Fund");
            }
            else if (count == 6)
            {
                Console.Write($"Your Lotto MAX Prize: Share of 2.5% of Pools Fund");
            }
            else if (count == 6 && bonus == true)
            {
                Console.Write($"Your Lotto MAX Prize: Share of 2.5% of Pools Fund");
            }
            else if (count == 7)
            {
                Console.Write($"Your Lotto MAX Prize: Win or share Jackpot of at least $10 Million or 87.25% of Pools Fund");
            }

        }

        static List<int> generateEXTRA()
        {
            List<int> lottonumbers = new List<int>();
            Random rnd = new Random();
            int i = 0;
            int randomNumb;
            
            for(i = 0; i < 7; i++)
            {
                randomNumb = rnd.Next(1,10);
                lottonumbers.Add(randomNumb);
            }
            
            return lottonumbers;
        }
        /* FIX THIS */
        static List<int> changeLottoEXTRA(List<int> Current)
        {
            List<int> lottonumbers = new List<int>();
            Console.Write("The current Lotto EXTRA winning numbers are: ");
            displayLottoEXTRA(Current);
            Console.Write("The new Lotto EXTRA winning numbers are: ");
            lottonumbers = generateEXTRA();
            displayLottoEXTRA(lottonumbers);
            Console.Write("\n");
            return lottonumbers;
        }
        

        static void displayLottoEXTRA(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count(); i++)
            {
                Console.Write($"{numbers[i]}");
            }
            Console.Write("\n");
        }


        static List<int> generate649()
        {
            List<int> lottonumbers = new List<int>();
            Random rnd = new Random();
            int i = 0;
            int randomNumb;
            
            for(i = 0; i < 6; i++)
            {
                do {
                    randomNumb = rnd.Next(1,50);                  
                }while (lottonumbers.Contains(randomNumb));
                lottonumbers.Add(randomNumb);
                
            }
            lottonumbers.Sort();
            do {
                randomNumb = rnd.Next(1,51);                  
            }while (lottonumbers.Contains(randomNumb));
            lottonumbers.Add(randomNumb);


            
            return lottonumbers;
        }

        static List<int> changeLotto649(List<int> Current)
        {
            List<int> lottonumbers = new List<int>();
            Console.Write("The current Lotto 649 winning numbers are: ");
            displayLottoMAX(Current);
            
            Console.Write("Would you like to generate or enter the winning numbers (g/e): ");
            string decide = Console.ReadLine();
            if (decide == "g")
            {
                Console.Write("The new Lotto 649 winning numbers are: ");
                lottonumbers = generate649();
                displayLottoMAX(lottonumbers);
            }
            else if (decide == "e"){
                for (int i = 1; i < 7; i++)
                {
                    Console.Write($"Enter number #{i}: ");
                    lottonumbers.Add(int.Parse(Console.ReadLine()));
                }
                Console.Write("Enter bonus number: ");
                lottonumbers.Add(int.Parse(Console.ReadLine()));
                Console.Write("The new Lotto 649 winning numbers are: ");
                for (int i = 0; i < lottonumbers.Count-1; i++)
                {
                    Console.Write($"{lottonumbers[i]} ");
                }
                Console.WriteLine($"(Bonus: {lottonumbers[lottonumbers.Count()-1]})");

            }
            Console.Write("\n");
            return lottonumbers;
        }

        static List<int> generateMAX()
        {
            List<int> lottonumbers = new List<int>();
            Random rnd = new Random();
            int i = 0;
            int randomNumb;
            
            for(i = 0; i < 7; i++)
            {
                do {
                    randomNumb = rnd.Next(1,51);                  
                }while (lottonumbers.Contains(randomNumb));
                lottonumbers.Add(randomNumb);
                
            }
            lottonumbers.Sort();
            do {
                randomNumb = rnd.Next(1,51);                  
            }while (lottonumbers.Contains(randomNumb));
            lottonumbers.Add(randomNumb);

            return lottonumbers;
        }

        static List<int> generateQuickMAX()
        {
            List<int> lottonumbers = new List<int>();
            Random rnd = new Random();
            int i = 0;
            int randomNumb;
            
            for(i = 0; i < 7; i++)
            {
                do {
                    randomNumb = rnd.Next(1,51);                  
                }while (lottonumbers.Contains(randomNumb));
                lottonumbers.Add(randomNumb);
                
            }
            lottonumbers.Sort();
            return lottonumbers;
        }

        static List<int> changeLottoMAX(List<int> Current)
        {
            List<int> lottonumbers = new List<int>();
            Console.Write("The current Lotto MAX winning numbers are: ");
            displayLottoMAX(Current);
            
            Console.Write("Would you like to generate or enter the winning numbers (g/e): ");
            string decide = Console.ReadLine();
            if (decide == "g")
            {
                Console.Write("The new Lotto MAX winning numbers are: ");
                lottonumbers = generateMAX();
                displayLottoMAX(lottonumbers);
            }
            else if (decide == "e"){
                for (int i = 1; i < 8; i++)
                {
                    Console.Write($"Enter number #{i}: ");
                    lottonumbers.Add(int.Parse(Console.ReadLine()));
                }
                Console.Write("Enter bonus number: ");
                lottonumbers.Add(int.Parse(Console.ReadLine()));
                Console.Write("The new Lotto MAX winning numbers are: ");
                for (int i = 0; i < lottonumbers.Count-1; i++)
                {
                    Console.Write($"{lottonumbers[i]} ");
                }
                Console.WriteLine($"(Bonus: {lottonumbers[7]})");

            }
            Console.Write("\n");
            return lottonumbers;
        }

        static void displayLottoMAX(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count()-1; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine($"(Bonus: {numbers[numbers.Count()-1]})");
            
        }

        static void displayQuickLottoMAX(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count(); i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            
        }

        static void Main(string[] args)
        {
            selectMenu(); //starts the menu
        }
    }
}
/* make sure if i run play lotto max it should be the same set of numbers and when i run the change they should be the same
 make a print numbers
     */