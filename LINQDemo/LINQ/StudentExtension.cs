using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    delegate bool FinStudent(Student std);
    class StudentExtension
    {
        public static Student[] where (Student[] stdArray, FinStudent del)
        {
            int i = 0;
            Student[] result = new Student[10];
            foreach (Student std in stdArray)
                if (del(std))
                {
                    result[i] = std;
                    i++;
                }

            return result;
        }
    }
}
