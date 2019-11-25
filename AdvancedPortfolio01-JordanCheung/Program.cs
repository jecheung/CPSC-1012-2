using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPortfolio01_JordanCheung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|----------------------------|");
            Console.WriteLine("| CPSC1012 Hangman Game      |");
            Console.WriteLine("|----------------------------|");
            Hangman();
        }

        static void Hangman()
        {
            Random randNum = new Random();
            int newRandNum = 0;
            string fname = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
            List<string> wordsInFile = new List<string>();
            List<char> charsInWord = new List<char>();
            char hiddenChar = '*'; 
            bool WordIsHidden = true; //keep word as *
            int wordCount = 0;
            var guessed = new List<char>(); //need a list for * to fill with correct characters
            var retry = true; //play again?

            // check if File exists
            if (File.Exists(fname))
            {
                Console.WriteLine("CurrentDirectory: " + Environment.CurrentDirectory);
                Console.WriteLine("SystemDirectory: " + Environment.SystemDirectory);
                Console.WriteLine("TempDirectory: " + Environment.GetEnvironmentVariable("TEMP"));
                StreamReader reader = new StreamReader(fname);
                string curLine;
                while ((curLine = reader.ReadLine()) != null)
                {
                    wordsInFile.Add(curLine);
                }
                reader.Close();
                foreach(var c in charsInWord)
                {
                    if (guessed.Contains(c))
                        Console.Write(c);
                    else
                        Console.Write(hiddenChar);
                }
                Console.Write("\n(Guess) Enter a Letter in word ");
                foreach(var c in guessed)
                {
                    Console.Write($"{c} >" );
                }
                char letter = char.Parse(Console.ReadLine());
                for (int i = 0; i < wordsInFile.Count; i++)
                {
                    Console.WriteLine($"word index: {i}, word: {wordsInFile[i]}");
                }
                newRandNum = randNum.Next(0, wordsInFile.Count - 1);
                Console.WriteLine($"Random word index: {newRandNum}");
                string data = wordsInFile[newRandNum];
                charsInWord.AddRange(data);
                for (int i = 0; i < charsInWord.Count; i++)
                {
                    Console.WriteLine($"char index: {i}, char: {charsInWord[i]}");
                }
                Console.WriteLine("");
                for (int i = 0; i < charsInWord.Count; i++)
                {
                    Console.Write($"{charsInWord[i]}");
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine($"The filename {fname} does not exist.");
            }
        }
    }
}
