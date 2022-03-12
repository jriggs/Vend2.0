using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Capstone
{
    class ConsoleIO : IWrite
    {
        //this class has a dependency on Console -> which comes from System
        public void Welcome()
        {
            //Console.Clear();
            Console.WriteLine("Welcome to the Vend-O Matic 2.0");
            Console.WriteLine("Please Select From the Menu Below");
            Console.WriteLine("");
            Console.WriteLine("1) Display Vending Machine Items");
            Console.WriteLine("2) Purchase");
            Console.WriteLine("3) Exit");
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public int GetNumber()
        {
            Print("Please Enter a number");
            string response = Console.ReadLine();
            if (int.TryParse(response, out int responseNumber) && responseNumber > 0)
            {
                return responseNumber;
            }
            else
            {
                return -1;
            }
        }

        public int GetNumber(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Print($"{i + 1}) {numbers[i]}");
            }

            //  Print($"Please Enter a Number");

            //  string response = Console.ReadLine();
            int responseNumber = GetNumber();

            if (responseNumber > -1 && responseNumber - 1 < numbers.Length)
            {
                return numbers[responseNumber - 1];
            }
            
            return -1;
        }
    }
}
