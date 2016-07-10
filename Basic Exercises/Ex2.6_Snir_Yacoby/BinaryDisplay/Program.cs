using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number:");
            int num = int.Parse(Console.ReadLine());
            int countOfOnes = 0;
            StringBuilder numAsBinaryString = new StringBuilder();

            while(num > 0)
            {
                if(num % 2 == 1)
                {
                    countOfOnes++;
                }

                numAsBinaryString.Append(num % 2);
                num /= 2;
            }

            char[] binaryNum = numAsBinaryString.ToString().Reverse().ToArray();
            foreach (var item in binaryNum)
            {
                Console.Write(item);
            }

            Console.WriteLine("\nNumber of 1's: " + countOfOnes);
        }
    }
}
