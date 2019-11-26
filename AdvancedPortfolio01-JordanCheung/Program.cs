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
            string myDir = "temp";
            string myFile = "test.txt";
            string myDirPath = @"C:\temp";
            string path = @"C:\temp\test.txt";

            Console.WriteLine($"CurrentDirectory: {Environment.CurrentDirectory}\n");
            Console.WriteLine($"SystemDirectory: {Environment.SystemDirectory}\n");
            Console.WriteLine($"TempDirectory: {Environment.GetEnvironmentVariable("TEMP")}\n");

            //string fname = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
            if(Directory.Exists(myDirPath))
            {
                Console.WriteLine($"{myDirPath} is a valid directory\n");
            }

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("izone");
                    sw.WriteLine("yena");
                    sw.WriteLine("sakura");
                    sw.WriteLine("minju");
                    sw.WriteLine("yuri");
                    sw.WriteLine("nako");
                    sw.WriteLine("hitomi");
                    sw.WriteLine("eunbi");
                    sw.WriteLine("chaewon");
                    sw.WriteLine("chaeyeon");
                    sw.WriteLine("wonyoung");
                    sw.WriteLine("yujin");
                    sw.WriteLine("hyewon");

                }
                
            }

            List<string> wordsInFile = new List<string>();
            List<char> charsInWord = new List<char>();
            int wordCount = 0;
            char hiddenChar = '*'; 
            bool WordIsHidden = true; //keep word as *
            
            var guessed = new List<char>(); //need a list for * to fill with correct characters
            var retry = true; //play again?

            // check if File exists
            if (File.Exists(path))
            {
                
                StreamReader reader = new StreamReader(path);
                string curLine;
                while ((curLine = reader.ReadLine()) != null)
                { 
                    wordsInFile.Add(curLine);
                }
                reader.Close();
                for(int i = 0; i < wordsInFile.Count(); i++)
                {
                    Console.WriteLine($"word index: {i}, word: {wordsInFile[i]}");
                }
                Console.WriteLine($"");
                newRandNum = randNum.Next(0, wordsInFile.Count() - 1);
                Console.WriteLine($"Random word index: {newRandNum}\n");
                string data = wordsInFile[newRandNum];
                charsInWord.AddRange(data);
                for (int i = 0; i < charsInWord.Count(); i++)
                {
                    Console.WriteLine($"char index: {i}, char: {charsInWord[i]}");
                }
                Console.WriteLine("");

               for (int i = 0; i < charsInWord.Count()-1; i++)
                {
                    guessed.Add(hiddenChar);
                }
                Console.WriteLine("");

                Console.Write("\n(Guess) Enter a Letter in word ");
                for (int i = 0; i < guessed.Count(); i++)
                {
                    Console.Write($"{guessed[i]}" );
                }
                Console.Write(" > ");
                char letter = char.Parse(Console.ReadLine());
                if (charsInWord.Contains(letter))
                {
                    
                }
                for (int i = 0; i < charsInWord.Count()-1; i++)
                {
                    if (charsInWord[i] == char)
                    else
                        Console.Write(hiddenChar);
                }

            }
            else
            {
                Console.WriteLine($"The filename {path} does not exist.");
            }
        }
    }
}
