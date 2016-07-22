using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LINQ_to_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            ExerciseMethods em = new ExerciseMethods();
            int choice;

            do
            {
                Console.WriteLine("1. Print Mscorlib exercises\n2. Print Processes\n3. Print System Threads\n4. Test method CopyTo\n0. Exit");
                var input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            em.PrintMscorlibInterfaces();
                            break;
                        case 2:
                            em.PrintProcesses();
                            break;
                        case 3:
                            em.PrintSystemThreads();
                            break;
                        case 4:
                            em.CopyToTest();
                            break;
                        case 0:
                            Console.WriteLine("Goodbye");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
            } while (choice != 0);
        }  
    }
}
