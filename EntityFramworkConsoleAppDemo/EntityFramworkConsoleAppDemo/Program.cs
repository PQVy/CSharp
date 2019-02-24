using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool value = true;

            do
            {
                Menu();
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewData();
                        break;
                    case "2":
                        InsertData();
                        break;
                    case "3":
                        UpdateData();
                        break;
                    case "4":
                        DeleteData();
                        break;
                    case "5":
                        value = false;
                        Console.WriteLine("Exited !!!!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Please insert value from 1 to 5");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();

            } while (value);
        }

        public static void Menu()
        {
            Console.WriteLine("Manager Student");
            Console.WriteLine("----------------");
            Console.WriteLine("1. View list Student");
            Console.WriteLine("2. Insert new Student");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Detele Studnet");
            Console.WriteLine("5. Exit");
            Console.WriteLine("----------------");
        }

        public static void ViewData()
        {
            using (var db = new StudentDemoEntities())
            {
                var select = from s in db.Students select s;
                foreach (var data in select)
                {
                    Console.WriteLine("ID: {0}", data.StudentID);
                    Console.WriteLine("Student name: {0}", data.StudentName);
                    Console.WriteLine("Student gender: {0}", data.StudentGender);
                    Console.WriteLine("Address: {0}", data.Address);
                }
            }
            Console.ReadLine();
        }

        public static void InsertData()
        {
            Console.WriteLine("Add new Student");
            Console.Write("StudnetID: ");
            int studentID = Int32.Parse(Console.ReadLine());
            Console.Write("Student name: ");
            string studentName = Console.ReadLine();
            Console.Write("Student gender: ");
            string studentGender = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();

            var student = new Student(studentID, studentName, studentGender, address);

            using (var db = new StudentDemoEntities())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
            Console.WriteLine("Created!!!");
            Console.ReadLine();
        }

        public static void DeleteData()
        {
            Console.Write("Input a StudnetID that you want delete: ");
            int studentID = Int32.Parse(Console.ReadLine());
            using(var db = new StudentDemoEntities())
            {
                var delete = (from d in db.Students where d.StudentID == studentID select d).Single();
                db.Students.Remove(delete);
                db.SaveChanges();
            }
            Console.WriteLine("Deleted!!!");
            Console.ReadLine();
        }

        public static void UpdateData()
        {
            Console.Write("Select student id that you want update information: ");
            int studentId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Select information student need update");
            Console.WriteLine("1. Update name");
            Console.WriteLine("2. Update gender");
            Console.WriteLine("3. Update address");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("New Student Name: ");
                    string StudentNameNew = Console.ReadLine();
                    using (var db = new StudentDemoEntities())
                    {
                        var updateName = (from u in db.Students where u.StudentID == studentId select u).Single();
                        updateName.StudentName = StudentNameNew;
                        db.SaveChanges();
                    }
                    Console.WriteLine("Update Success!!!");
                    break;
                case "2":
                    Console.Write("New Student Gender: ");
                    string StudentGenderNew = Console.ReadLine();
                    using (var db = new StudentDemoEntities())
                    {
                        var updateName = (from u in db.Students where u.StudentID == studentId select u).Single();
                        updateName.StudentGender = StudentGenderNew;
                        db.SaveChanges();
                    }
                    Console.WriteLine("Update Success!!!");
                    break;
                case "3":
                    Console.Write("New Student Address: ");
                    string StudentAddressNew = Console.ReadLine();
                    using (var db = new StudentDemoEntities())
                    {
                        var updateName = (from u in db.Students where u.StudentID == studentId select u).Single();
                        updateName.Address = StudentAddressNew;
                        db.SaveChanges();
                    }
                    Console.WriteLine("Update Success!!!");
                    break;
                default:
                    Console.WriteLine("Input from 1 to 3");
                    Console.ReadLine();
                    break;
            }

        }
    }
}
