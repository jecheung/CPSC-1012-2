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
            //string path = @"C:\temp\test.txt";
            string path = @"C:\Windows\Temp\test.txt";
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
            
            //int wordCount = 0;
            char hiddenChar = '*'; 
            
            string playAgain = "y";
            bool sessionDone = false;
            //need a list for * to fill with correct characters
            
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
                
                do {
                    List<char> correctGuesses = new List<char>();
                    List<char> incorrectGuesses = new List<char>();
                    List<char> charsInWord = new List<char>();
                    List<char> correctlyGuess = new List<char>();
                    bool won = false;
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

                   for (int i = 0; i < charsInWord.Count(); i++)
                    {
                        correctGuesses.Add(hiddenChar);
                    }
                    Console.WriteLine("");
                    while (!won)
                    {
                        Console.Write("\n(Guess) Enter a Letter in word ");
                        for (int i = 0; i < correctGuesses.Count(); i++)
                        {
                            Console.Write($"{correctGuesses[i]}" );
                        }
                        Console.Write(" > ");
                        char letter = char.Parse(Console.ReadLine());
                        if (incorrectGuesses.Contains(letter))
                        {
                            Console.WriteLine($"{letter} is not in the word");
                        }
                        else {
                            Console.WriteLine($"{letter} is already in the word");
                        }
                        for (int i = 0; i < correctGuesses.Count(); i++)
                        {
                            if (charsInWord[i] == letter)
                            {
                                correctGuesses[i] = letter;
                                correctlyGuess.Add(letter);
                                break;
                            }
                            else
                                incorrectGuesses.Add(letter);
                        }


                        if (!correctGuesses.Contains('*'))
                        {
                            won = true;
                        }
                    }
                    do {
                        Console.Write("Do you want to guess another word? Enter y or n > ");
                        playAgain = Console.ReadLine();
                        if ((playAgain == "y") || (playAgain == "n")){
                            sessionDone = true;
                        }
                        else {
                            Console.WriteLine($"\"{playAgain}\" is not a valid choice. Try Again.");
                            sessionDone = false;
                        }   
                    }while (sessionDone != true);
                }while (playAgain != "n");
            }
            else
            {
                Console.WriteLine($"The filename {path} does not exist.");
            }

            
        }
    }
}
