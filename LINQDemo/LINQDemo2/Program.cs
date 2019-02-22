using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_OrderBy
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>()
            {
                new Student() {StudentID = 1, StudentName= "Jhon", StudentAge=  18},
                new Student() {StudentID = 1, StudentName= "Steven", StudentAge=  15},
                new Student() {StudentID = 1, StudentName= "Bill", StudentAge=  25},
                new Student() {StudentID = 1, StudentName= "Ron", StudentAge=  20},
                new Student() {StudentID = 1, StudentName= "Ram", StudentAge=  21},

            };

            //Query syntax
            //var orderByResult = from s in studentList orderby s.StudentName select s;
            //Method syntax
            var orderByResult = studentList.OrderBy(s => s.StudentName);
            


            foreach (var stu in orderByResult)
            {
                Console.WriteLine(stu.StudentName);
            }

            //var orderByResultDes = from s in studentList orderby s.StudentName descending select s;

            //Method syntax 
            var orderByResultDes = studentList.OrderByDescending(s => s.StudentName);

            foreach (var stu in orderByResultDes)
            {
                Console.WriteLine(stu.StudentName);
            }
        }
    }
}
