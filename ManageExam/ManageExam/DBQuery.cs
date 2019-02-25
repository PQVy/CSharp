using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageExam
{
    class DBQuery
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        public SqlDataReader DataReader { get; set; }
        private string connectionString;
        private string query;

        public SqlConnection DBConnection()
        {
            try
            {
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study\MicrosoftVisualStudio\ManageExam\ManageExam\ManageExam.mdf;Integrated Security=True";
                //connectionString = @"Data Source = DESKTOP-EK7VJ2S;Initial Catalog = ManageExams; User ID = sa; Password = sa";
                conn = new SqlConnection(connectionString);
                conn.Open();
                //Console.WriteLine("Connection success.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return conn;
        }

        public SqlDataReader LoadExamCode()
        {
            try
            {
                conn = DBConnection();
                query = "SELECT * FROM ExamNumbers";
                cmd = new SqlCommand(query, conn);
                DataReader = cmd.ExecuteReader();
                Console.WriteLine("Exam Code: ");
                while (DataReader.Read())
                {
                    Console.Write(DataReader.GetValue(1).ToString() + " | ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return DataReader;
        }

        public List<QAContent> LoadQAContent(string examCode)
        {
            List<QAContent> qAContentList = new List<QAContent>();
            try
            {
                conn = DBConnection();
                query = "SELECT * FROM ExamNumbers";
                cmd = new SqlCommand(query, conn);
                DataReader = cmd.ExecuteReader();
                while (DataReader.Read())
                {
                    if (DataReader.GetValue(1).Equals(examCode))
                    {
                        try
                        {
                            conn = DBConnection();
                            query = "SELECT * FROM QAContent WHERE ExamId = @ExamId";
                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@ExamId", DataReader.GetInt32(0));
                            SqlDataReader dataReaderQA = cmd.ExecuteReader();
                            while (dataReaderQA.Read())
                            {
                                int qaId = dataReaderQA.GetInt32(0);
                                string question = (string)dataReaderQA.GetValue(1);
                                string answer1 = (string)dataReaderQA.GetValue(2);
                                string answer2 = (string)dataReaderQA.GetValue(3);
                                string answer3 = (string)dataReaderQA.GetValue(4);
                                string answer4 = (string)dataReaderQA.GetValue(5);
                                string answerTrue = (string)dataReaderQA.GetValue(7);

                                qAContentList.Add(new QAContent(qaId, question, answer1, answer2, answer3, answer4, answerTrue));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return qAContentList;
        }
    }
}
