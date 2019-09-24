using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string prov = "";
            double bfTax, total, tax;

            Console.Write("Please Enter your total sale: ");
            bfTax = double.Parse(Console.ReadLine());

            Console.Write("Please Enter your Province (BC,AB,SK,MB...): ");
            prov = Console.ReadLine().ToLower();

            switch (prov)
            {
                case "bc":
                    tax = bfTax * 0.12;
                    total = bfTax + tax;
                    Console.WriteLine($"Your purchase amount is: {bfTax:c}");
                    Console.WriteLine("The sales tax is: 12%");
                    Console.WriteLine($"Your total cost is: {total:c}");
                    break;

                case "ab":
                case "yt":
                case "nt":
                case "nu":
                    tax = bfTax * 0.05;
                    total = bfTax + tax;
                    Console.WriteLine($"Your purchase amount is: {bfTax:c}");
                    Console.WriteLine("The sales tax is: 5%");
                    Console.WriteLine($"Your total cost is: {total:c}");
                    break;

                case "sk":
                    tax = bfTax * 0.11;
                    total = bfTax + tax;
                    Console.WriteLine($"Your purchase amount is: {bfTax:c}");
                    Console.WriteLine("The sales tax is: 11%");
                    Console.WriteLine($"Your total cost is: {total:c}");
                    break;

                case "mb":
                case "on":
                    tax = bfTax * 0.13;
                    total = bfTax + tax;
                    Console.WriteLine($"Your purchase amount is: {bfTax:c}");
                    Console.WriteLine("The sales tax is: 13%");
                    Console.WriteLine($"Your total cost is: {total:c}");
                    break;

                case "qc":
                    tax = bfTax * 0.14975;
                    total = bfTax + tax;
                    Console.WriteLine($"Your purchase amount is: {bfTax:c}");
                    Console.WriteLine("The sales tax is: 14.975%");
                    Console.WriteLine($"Your total cost is: {total:c}");
                    break;

                case "nl":
                case "nb":
                case "ns":
                case "pe":
                    tax = bfTax * 0.15;
                    total = bfTax + tax;
                    Console.WriteLine($"Your purchase amount is: {bfTax:c}");
                    Console.WriteLine("The sales tax is: 15%");
                    Console.WriteLine($"Your total cost is: {total:c}");
                    break;

                default:
                    Console.WriteLine("You didn't enter a correct province");
                    break;
            }
        }
    }
}
