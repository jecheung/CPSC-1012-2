using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_while
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents = 0;
            double curMark = 0;
            double minMark = 101;
            double maxMark = -1;
            double sumOfMarks = 0;
            double avgMark;

            // Grab our input
            do
            {
                Console.Write("Enter a grade for student or 999 to exit: ");
                curMark = double.Parse(Console.ReadLine());
                if (curMark >= 0 && curMark <= 100)
                {
                    if (curMark < minMark)
                        minMark = curMark;
                    if (curMark > maxMark)
                        maxMark = curMark;
                    sumOfMarks += curMark;
                    numStudents++;
                }
                else if (curMark == 999)
                {
                    if (sumOfMarks != 0)
                    {
                        avgMark = sumOfMarks / (double)numStudents;
                        Console.WriteLine($"\nAverage Mark: {avgMark}, Highest Mark: {maxMark}, Lowest Mark: {minMark}");
                    }
                }
                else
                    Console.WriteLine("Invalid Mark entered");
            } while (curMark != 999);

        }
    }
}
