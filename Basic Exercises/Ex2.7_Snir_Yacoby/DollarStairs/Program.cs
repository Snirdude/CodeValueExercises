using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number:");
            int num = int.Parse(Console.ReadLine());

            for(int i = 1; i <= num; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    Console.Write("$");
                }
                Console.WriteLine();
            }
        }
    }
}
