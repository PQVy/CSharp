using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageExam
{
    class Program
    {
        static void Main(string[] args)
        {
            DBQuery dBQuery = new DBQuery();
            //dBQuery.DBConnection();

            int question = 1, markTest = 0;
            dBQuery.LoadExamCode();

            Console.WriteLine("");
            Console.WriteLine("-------------------");
            Console.WriteLine("Question and Answer");
            Console.WriteLine("-------------------");
            Console.Write("Please input Exam code above: ");
            string examCode = Console.ReadLine();
            List<QAContent> qAContentList = dBQuery.LoadQAContent(examCode);

            foreach (var item in qAContentList)
            {
                Console.Write("Question {0}: ", question);
                Console.WriteLine(item.Question);
                Console.WriteLine(" " + item.Answer1);
                Console.WriteLine(" " + item.Answer2);
                Console.WriteLine(" " + item.Answer3);
                Console.WriteLine(" " + item.Answer4);

                Console.Write("Your Answer (A/B/C/D): ");
                string answer = Console.ReadLine();

                if (item.AnswerTrue.Equals(answer))
                {
                    markTest++;
                }
                question++;
            }
            Console.WriteLine("\n");
            Console.WriteLine("*******RESULT**********");
            Console.WriteLine("You answer {0} question and your point is {1}" , markTest, markTest);
            Console.ReadLine();

        }
    }
}
