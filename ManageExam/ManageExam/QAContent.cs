using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageExam
{
    class QAContent
    {
        public int QAId { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int ExamId { get; set; }
        public string AnswerTrue { get; set; }

        public QAContent(int qaID, string question, string answer1, string answer2, string answer3, string answer4, string answerTrue)
        {
            QAId = qaID;
            Question = question;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;
            AnswerTrue = answerTrue;
        }
    }
}
