using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using quizAvasure;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class QuizTests
    {

        [TestMethod]
        public void quiz_3_out_of_3()
        {
            using (var sw = new StringWriter())
            {
                using (var response1 = new StringReader("C:/Users/Christian/Desktop/ChrisitianThompsonAvaSure/repo/quizAvasure/questionFile.txt" + Environment.NewLine + "3" + Environment.NewLine + "1" + Environment.NewLine + "1" + Environment.NewLine))
                {
                    Console.SetOut(sw);
                    Console.SetIn(response1);

                    Quiz quizTest = new Quiz();
                    quizTest.Calculate(quizTest);

                    //confirms all answers were correct
                    Assert.IsTrue(quizTest.inputAnswers[0] == 1 && quizTest.inputAnswers[1] == 1 && quizTest.inputAnswers[2] == 1);
                    Assert.IsTrue(quizTest.score == 3);
                }
            }
        }

        [TestMethod]
        public void quiz_2_out_of_3()
        {
            using (var sw = new StringWriter())
            {
                using (var response1 = new StringReader("C:/Users/Christian/Desktop/ChrisitianThompsonAvaSure/repo/quizAvasure/questionFile.txt" + Environment.NewLine + "3" + Environment.NewLine + "3" + Environment.NewLine + "1" + Environment.NewLine))
                {
                    Console.SetOut(sw);
                    Console.SetIn(response1);

                    Quiz quizTest = new Quiz();
                    quizTest.Calculate(quizTest);

                    //confirms only the second answer was incorrect
                    Assert.IsTrue(quizTest.inputAnswers[0] == 1 && quizTest.inputAnswers[1] == 0 && quizTest.inputAnswers[2] == 1);
                    Assert.IsTrue(quizTest.score == 2);
                }
            }
        }

        [TestMethod]
        public void quiz_1_out_of_3()
        {
            using (var sw = new StringWriter())
            {
                using (var response1 = new StringReader("C:/Users/Christian/Desktop/ChrisitianThompsonAvaSure/repo/quizAvasure/questionFile.txt" + Environment.NewLine + "3" + Environment.NewLine + "3" + Environment.NewLine + "2" + Environment.NewLine))
                {
                    Console.SetOut(sw);
                    Console.SetIn(response1);

                    Quiz quizTest = new Quiz();
                    quizTest.Calculate(quizTest);

                    //confirms only the first answer was correct
                    Assert.IsTrue(quizTest.inputAnswers[0] == 1 && quizTest.inputAnswers[1] == 0 && quizTest.inputAnswers[2] == 0);
                    Assert.IsTrue(quizTest.score == 1);
                }
            }
        }

        [TestMethod]
        public void quiz_0_out_of_3()
        {
            using (var sw = new StringWriter())
            {
                using (var response1 = new StringReader("C:/Users/Christian/Desktop/ChrisitianThompsonAvaSure/repo/quizAvasure/questionFile.txt" + Environment.NewLine + "1" + Environment.NewLine + "3" + Environment.NewLine + "2" + Environment.NewLine))
                {
                    Console.SetOut(sw);
                    Console.SetIn(response1);

                    Quiz quizTest = new Quiz();
                    quizTest.Calculate(quizTest);

                    //confirms all 3 were incorrect
                    Assert.IsTrue(quizTest.inputAnswers[0] == 0 && quizTest.inputAnswers[1] == 0 && quizTest.inputAnswers[2] == 0);
                    Assert.IsTrue(quizTest.score == 0);
                }
            }
        }

        [TestMethod]
        public void quiz_input_letters_instead_of_numbers()
        {
            using (var sw = new StringWriter())
            {
                using (var response1 = new StringReader("C:/Users/Christian/Desktop/ChrisitianThompsonAvaSure/repo/quizAvasure/questionFile.txt" + Environment.NewLine + "hi" + Environment.NewLine + "ava" + Environment.NewLine + "sure" + Environment.NewLine))
                {
                    Console.SetOut(sw);
                    Console.SetIn(response1);

                    Quiz quizTest = new Quiz();
                    quizTest.Calculate(quizTest);

                    //confirms no errors were thrown, only incorrect answers
                    Assert.IsTrue(quizTest.inputAnswers[0] == 0 && quizTest.inputAnswers[1] == 0 && quizTest.inputAnswers[2] == 0);
                    Assert.IsTrue(quizTest.score == 0);
                }
            }
        }

        [TestMethod]
        public void quiz_file_not_found()
        {
            using (var sw = new StringWriter())
            {
                using (var response1 = new StringReader("no_file" + Environment.NewLine))
                {
                    Console.SetOut(sw);
                    Console.SetIn(response1);

                    Quiz quizTest = new Quiz();
                    quizTest.Calculate(quizTest);

                    var result = sw.ToString();
                    Assert.IsTrue(result.Contains("File does not exist"));
                }
            }
        }
    }
}
