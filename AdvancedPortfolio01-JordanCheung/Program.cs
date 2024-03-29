﻿using System;
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
          //  Console.WriteLine($"CurrentDirectory: {Environment.CurrentDirectory}\n");
          //  Console.WriteLine($"SystemDirectory: {Environment.SystemDirectory}\n");
          //  Console.WriteLine($"TempDirectory: {Environment.GetEnvironmentVariable("TEMP")}\n");

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
                    bool won = false;
                    int letterRevealed = 0;
                    int missed = 0;
                    string input;
                    char letter;

                    newRandNum = randNum.Next(0, wordsInFile.Count() - 1);
                    Console.WriteLine($"I have picked a random word on IZ*ONE.\nYour task is to guess the correct word.\n");
                    string data = wordsInFile[newRandNum];
                    charsInWord.AddRange(data);
                  /*  for (int i = 0; i < charsInWord.Count(); i++)
                    {
                        Console.WriteLine($"char index: {i}, char: {charsInWord[i]}");
                    }
                    Console.WriteLine("");*/
                    StringBuilder displayToPlayer = new StringBuilder(charsInWord.Count());
                    for (int i = 0; i < charsInWord.Count(); i++)
                    {
                        displayToPlayer.Append(hiddenChar);
                    }
                    while (!won)
                    {
                        Console.Write("(Guess) Enter a Letter in word ");
                        Console.Write(displayToPlayer.ToString());
                        Console.Write(" > ");
                        input = Console.ReadLine();
                        letter = input[0];
                        if (correctGuesses.Contains(letter))
                        {
                            Console.WriteLine($"{letter} is already in the word");
                            continue;
                        }
                        /*else if (incorrectGuesses.Contains(letter)){
                            Console.WriteLine($"{letter} is not in the word");
                            missed++;
                            continue;
                        }*/

                        if (charsInWord.Contains(letter))
                        {
                            correctGuesses.Add(letter);
                            for (int i = 0; i < charsInWord.Count(); i++)
                            {
                                if (charsInWord[i] == letter)
                                {
                                    displayToPlayer[i] = charsInWord[i];
                                    letterRevealed++;
                                }
                            }

                            if (letterRevealed == charsInWord.Count())
                                won = true;
                        }
                        else
                        {
                            incorrectGuesses.Add(letter);

                            Console.WriteLine($"{letter} is not in the word");
                        }
                        
                    }

                    if (won)
                        Console.WriteLine($"The word is {displayToPlayer.ToString()}. You missed {incorrectGuesses.Count()} times.");


                    do {
                        Console.Write("Do you want to guess another word? Enter y or n > ");
                        playAgain = Console.ReadLine();
                        Console.WriteLine("");
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
            Console.WriteLine("Good-bye and thanks for playing my Hangman game.");
            
        }
    }
}
