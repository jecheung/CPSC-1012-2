using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedPortfolio03_JordanCheung
{
    class Program
    {
        private static string file = Path.Combine(Directory.GetCurrentDirectory(), "questions.txt");
        private static int count = 0;
        private static List<Data> list = new List<Data>();

        static void Main(string[] args)
        {
            Console.WriteLine("|---------------------------|");
            Console.WriteLine("| CPSC1012 Trivia Game      |");
            Console.WriteLine("|---------------------------|");
            createFile();
            playTrivia();
        }

        static void createFile()
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            if (!File.Exists(file))
            {
                using (StreamWriter sw = File.CreateText(file))
                {
                    sw.WriteLine("What is my name?,jordan,1");
                    sw.WriteLine("What school am I enrolled in?,nait,2");
                    sw.WriteLine("Who is my bias in IZ*ONE?,yena,2");
                    sw.WriteLine("What color is my backpack?,black,1");
                    sw.Close();
                }
            }
        }

        static List<string> getQuestions()
        {
            List<string> words = new List<string>();
            string currentWord;

            using (StreamReader sr = File.OpenText(file))
            {
                while ((currentWord = sr.ReadLine()) != null)
                {
                    words.Add(currentWord);
                }
                sr.Close();
            }
            return words;
        }

        static Data loadQuestion()
        {
            string[] questions = getQuestions().ToArray();
            string question = questions[count];
            string[] split = question.Split(',');

            var trivia = new Data();
            trivia.setQuestion(split[0]);
            trivia.setAnswer(split[1]);
            trivia.setPoint(int.Parse(split[2]));

            return trivia;
        }

        static string getInput(String prompt)
        {
            bool invalid = true;
            string msg = "";

            while (invalid)
            {
                try
                {
                    Console.Write(prompt);
                    msg = Console.ReadLine();
                    invalid = false;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return msg.ToLower();
        }

        static void playTrivia()
        {
            string question = "", answer = "";
            int point = 0, playerPoints = 0, total = 0;
            bool playing = true;

            while (playing)
            {
                if (count == 4)
                {
                    playing = false;
                }

                if (playing == true)
                {
                    list.Add(loadQuestion());

                    list.ForEach(s =>
                    {
                        question = s.getQuestion();
                        answer = s.getAnswer();
                        point = s.getPoint();
                    });

                    total += point;

                    string guess = getInput($"{question} ");

                    if (guess == answer)
                    {
                        playerPoints += point;
                        Console.WriteLine($"\nPoints earned: {playerPoints}\n");
                    }
                    else
                    {
                        Console.WriteLine($"\nThe actual answer is: {answer}");
                        Console.WriteLine($"Points earned: 0\n");
                    }
                    count++;
                }
            }
            Console.WriteLine("You have answered all the Trivia Questions!");
            Console.WriteLine($"Total Points: {playerPoints}/{total}");
            Console.WriteLine("Good-bye and thanks for playing my Trivia game.");
            
        }
    }

    class Data
    {
        private string question, answer;
        private int point;

        public void setQuestion(String s)
        {
            question = s;
        }

        public void setAnswer(String s)
        {
            answer = s;
        }

        public void setPoint(int i)
        {
            point = i;
        }

        public string getQuestion()
        {
            return question;
        }

        public string getAnswer()
        {
            return answer;
        }

        public int getPoint()
        {
            return point;
        }
    }
}
