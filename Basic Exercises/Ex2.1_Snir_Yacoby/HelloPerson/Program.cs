using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name);
            Console.WriteLine("Enter number 1-10");
            int num = int.Parse(Console.ReadLine());
            for(int i = 1; i <= num; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(name);
            }
        }
    }
}
