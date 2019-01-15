using System;
using System.Collections;
using System.Collections.Generic;

namespace CheckCanadaSIN
{
    class MainProgram
    {
        static void Main(string[] args)
        {  
            Console.Write("Input your SIN: ");
            int a = int.Parse(Console.ReadLine());
            ConvertIntToList convertIntToArray = new ConvertIntToList();
            List<int> intArr = convertIntToArray.ConvertToList(a);
            if (intArr.Count == 9)
            {
                CheckSINTrue check = new CheckSINTrue();
                if (check.checkSIN(intArr))
                {
                    Console.WriteLine("This is the valid SIN");
                }
                else
                {
                    Console.WriteLine("This is not valid SIN");
                }
                
            }
            else
            {
                Console.WriteLine("Have a nice day!!!!");
            }

            Console.ReadLine();
        }

    }
}
