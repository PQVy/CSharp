using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConn dBConn = new DBConn();
            string name;
            int age;
            bool value = true;


            do
            {
                Console.WriteLine("1. Insert Data");
                Console.WriteLine("2. Delete Data");
                Console.WriteLine("3. Search Data");
                Console.WriteLine("4. View Data");
                Console.WriteLine("5. Exit");
                Console.WriteLine("--------------------");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter your age: ");
                        age = Int32.Parse(Console.ReadLine());
                        dBConn.InsertData(name, age);
                        break;
                    case "2":
                        Console.Write("Enter your name need delete: ");
                        name = Console.ReadLine();
                        dBConn.DeleteData(name);
                        break;
                    case "3":
                        Console.Write("Search by name: ");
                        name = Console.ReadLine();
                        dBConn.SearchData(name);
                        break;
                    case "4":
                        dBConn.ViewData();
                        break;
                    case "5":
                        value = false;
                        Console.WriteLine("Exit!!!");
                        break;
                }
                Console.ReadLine();
                Console.Clear();

            } while (value);

           
        }
    }
}
