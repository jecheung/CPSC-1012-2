using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dowhile2
{
    class Program
    {
        static void Main(string[] args)
        {
            double total, num = 0;
            bool play = false;
            Console.WriteLine("***Welcome to the Adding Machine.***");
            do
            {
                do
                {
                    Console.WriteLine("Enter = when done.");
                    Console.Write("Enter a number: ");
                    num = double.Parse(Console.ReadLine());

                } while (num != '=');
            } while (play != true);
        }
    }
}
