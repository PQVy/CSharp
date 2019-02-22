using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            IList<Student> studentList = new List<Student>() 
            {
                new Student() {StudentID=1, StudentName="John",Age=18 },
                new Student() {StudentID=2, StudentName="Steve",Age=21},
                new Student() {StudentID=3, StudentName="Bill",Age=25},
                new Student() {StudentID=4, StudentName="Ram",Age=20},
                new Student() {StudentID=5, StudentName="Ron",Age=31},
                new Student() {StudentID=6, StudentName="Chris", Age=17},
                new Student() {StudentID=7, Age=19, StudentName="Rob"},
            };

            //IList<Student> students = new List<Student>();
            //int i = 0;
            //foreach (Student std in studentArray)
            //{
            //    if(std.Age > 12 && std.Age < 20)
            //    {
            //        students.Add(std);
            //        i++;
            //    }
            //}
            //Console.WriteLine(students.Count);
            //foreach (Student stu in students)
            //{
            //    Console.WriteLine(stu.Age);
            //}

            //// Use LINQ to find teenager students
            //Student[] teenAgerStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();

            //// Use LINQ to find first student whose name is Bill 
            //Student bill = studentArray.Where(s => s.StudentName == "Bill").FirstOrDefault();

            //// Use LINQ to find student whose StudentID is 5
            //Student student5 = studentArray.Where(s => s.StudentID == 5).FirstOrDefault();

            IList<string> stringList = new List<string>()
            {
                    "C# Tutorials",
                    "VB.NET Tutorials",
                    "Learn C++",
                    "MVC Tutorials" ,
                    "Java",
            };

            var result = from s in stringList
                         where s.Contains("Tutorials")
                         select s;

            var teenAge = from stu in studentList
                          where stu.Age > 12 && stu.Age < 20
                          select stu;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            foreach (var item in teenAge)
            {
                Console.WriteLine(item);
            }

            var teenAgeStudent = studentList.Where(s => s.Age > 12 && s.Age < 20).ToList<Student>();

            foreach (var item in teenAgeStudent)
            {
                Console.WriteLine(item);
            }

        }
    }
}
