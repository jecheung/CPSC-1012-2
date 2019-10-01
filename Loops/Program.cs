using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGuess = 0;
            int guess;
            Random rnd = new Random();
            int randomNum = rnd.Next(1, 101);
            bool correct = true;

            //Console.WriteLine($"{randomNum}");
            while (correct && numGuess < 10)
            {
                Console.Write($"Guess a number between 1-100 you have {10 - numGuess} guesses: ");
                guess = int.Parse(Console.ReadLine());
                numGuess++;
                if (guess < randomNum)
                {
                    Console.WriteLine("Too Low!");
                }
                else if (guess > randomNum)
                {
                    Console.WriteLine("Too High!");
                }
                else
                    correct = false;
            }
            if (correct)
                Console.WriteLine($"No more guesses, the number was {randomNum}.");
            else
                Console.WriteLine($"You got the correct number in {numGuess} guessess");

        }
    }
}
