using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPortfolio05_JordanCheung
{
    class Program
    {
        static void Main(string[] args)
        {
            selectMenu();
            
        }

        static void DisplayMenu()
        {
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("| CPSC1012 Adv. Portfolio #5  |");
            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("| 1. Add Fuel                 |");
            Console.WriteLine("| 2. Drive Car                |");
            Console.WriteLine("| 0. Exit                     |");
            Console.WriteLine("|-----------------------------|");
        }

        static void selectMenu()
        {
            bool invalidInput = true;
            string choice = " ";
            double currentfuel = FuelGauge.getLiters();
            while (invalidInput)
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Option: ");
                    choice = Console.ReadLine();
                    
                    switch (choice)
                    {
                        case "0":
                            Console.WriteLine("Good-bye - please come again ...");
                            invalidInput = false;
                            break;
                        case "1":
                            currentfuel += FuelGauge.setFuel();
                            break;
                        case "2":
                            Odometer.setDistance(driveCar());
                            break;
                        default:
                            Console.WriteLine($"Please enter a valid number between 0 and 2 inclusive");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static int driveCar()
        {
            bool invalid = true;
            int n = 0;

            while (invalid)
            {
                try
                {
                    Console.Write("Enter distance to drive: ");
                    n = int.Parse(Console.ReadLine());
                    invalid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return n;
        }
    }

    class Odometer
    {

        private static int distance = 1;

        public static void setDistance(int n)
        {
            bool running = true;
            for (int i = 0; running && i < n; i++)
            {
                running = FuelGauge.burnFuel();

                if (running == true)
                {
                    Console.WriteLine($"Km: {distance} \t\tFuel: {FuelGauge.getLiters():n2} L");
                    distance++;
                }
                if (distance == 1000)
                {
                    distance = 0;
                }
            }
        }
    }

    class FuelGauge
    {
        private static double liters = 0;
        
        public static double getLiters()
        {
            return liters;
        }

        public static double setFuel()
        {
            bool invalid = true;
            double n = 0;

            while (invalid)
            {
                try
                {
                    Console.Write("Enter amount of fuel to add: ");
                    n = int.Parse(Console.ReadLine());

                    double total = liters + n;

                    if (total > 60)
                    {
                        liters = 60;
                        Console.WriteLine("Added 60L of fuel");
                        invalid = false;
                    }
                    else if (n <= 0)
                    {
                        Console.WriteLine("You need to add more gas, 0 L is not allowed!");
                    }
                    else
                    {
                        liters = total;
                        Console.WriteLine("");
                        invalid = false;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return liters;
        }

        public static bool burnFuel()
        {
            if (liters >= 0.12)
            {
                liters = liters - 0.12;
                return true;
            }
            else
            {
                Console.WriteLine("Out of Fuel ... please add fuel");
                return false;
            }
        }

    }
}
