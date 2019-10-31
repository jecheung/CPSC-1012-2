using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generate a random number between 1 and 100.
            

            // Ask the user to guess the number until it is correct.
            // for each guess indicate if guess is "too high" "too low" or "correct".

            int guess;
            int playedGames = 0;
            bool guessNotCorrect = true;
            string playAgain = "y";

            do
            {
                int numAttempts = 0;
                Random rnd = new Random();
                int num = rnd.Next(1, 100);
                playedGames++;
                do
                {
                    Console.Write("Guess a number (0-100): ");
                    guess = int.Parse(Console.ReadLine());
                    numAttempts++;
                    guessNotCorrect = true;
                    if (guess < num)
                    {
                        Console.WriteLine("Too Low!");
                    }
                    else if (guess > num)
                    {
                        Console.WriteLine("Too high!");
                    }
                    else
                    {
                        Console.WriteLine("Hooray! You got the number!");
                        Console.WriteLine($"Took you {numAttempts} tries to get the correct number.");
                        guessNotCorrect = false;
                    }
                } while (guessNotCorrect);
                Console.Write("Would you like to play again y or n? ");
                playAgain = Console.ReadLine();
            } while (playAgain != "n");
            Console.WriteLine($"You have played this game {playedGames} times");
        }
    }
}
