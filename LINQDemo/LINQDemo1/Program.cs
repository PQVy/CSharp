using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });

            var stringResult = from s in mixedList.OfType<string>() select s;
            var intResult = from i in mixedList.OfType<int>() select i;
            var stdResult = from stu in mixedList.OfType<Student>() select stu;

            foreach (var str in stringResult)
            {
                Console.WriteLine(str);
            }

            foreach (var integer in intResult)
            {
                Console.WriteLine(integer);
            }

            foreach (var stu in stdResult)
            {
                Console.WriteLine(stu.StudentName);
            }
        }
    }
}
