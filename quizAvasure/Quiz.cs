using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace quizAvasure
{
    public interface IQuiz
    {
        void Calculate(Quiz quiz);
    }
    public class Quiz : IQuiz
    {
        public int score = 0;
        public List<int> inputAnswers = new List<int>();

        public void Calculate(Quiz quiz)
        {
            Console.WriteLine("Enter the file path to your quiz (starting at root)");

            var path = Console.ReadLine();
            var prevc = '0';
            var numQs = 0;

            //check if file exists
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist");
                Environment.Exit(0);
            }

            //open file and begin reading in lines
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    //checks if line is either the question or question options
                    if (s.Length > 1)
                    {
                        if (s[0] == '(')
                        {
                            Console.WriteLine("-------------------------------------------------------------\n");
                        }
                        Console.WriteLine(s);
                        prevc = s[0];
                    }
                    //checks if line has the answer
                    else if (s.Length == 1)
                    {
                        numQs += 1;
                        Console.WriteLine("\nSelect a number 1 through " + prevc + ": ");
                        string answer = Console.ReadLine();
                        Console.WriteLine("\n");

                        //checks if the inputed answer was correct or not
                        if (answer != s[0].ToString())
                        {
                            quiz.inputAnswers.Add(0);
                            Console.WriteLine("Incorrect! The correct answer was " + s[0] + "!\n");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            quiz.inputAnswers.Add(1);
                            Console.WriteLine("Correct!\n");
                            Thread.Sleep(1000);
                        }
                    }
                }
            }

            //calculates score
            for (int i = 0; i < quiz.inputAnswers.Count; i++)
            {
                if (quiz.inputAnswers[i] == 1)
                    quiz.score += 1;
            }
            Console.WriteLine("\nYour final score was " + quiz.score + " out of " + numQs + "\n");
        }

        public static void Main()
        {
            Quiz quiz = new Quiz();
            quiz.Calculate(quiz);
        }
    }
}
