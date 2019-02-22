using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return this.StudentID +" "+this.StudentName +" "+this.Age;
        }
    }
}
