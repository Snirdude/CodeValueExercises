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
            A a = new A("Snir", 2015, 12.5);
            B b = new B("Ronen", 2016, 'A');
            b.CopyTo(a);
            Console.WriteLine($"{a.Name} {a.Id} {a.Balance}");
        }

        private void PrintMscorlibInterfaces()
        {
            var assembly = Assembly.GetAssembly(typeof(string));
            var interfaces = from x in assembly.GetTypes()
                                  where x.IsInterface
                                  orderby x.Name
                                  select new { x.Name, x.GetMethods().Length };

            foreach (var interfacee in interfaces)
            {
                Console.WriteLine($"Interface Name: {interfacee.Name}, Number of methods: {interfacee.Length}");
            }
        }

        private void PrintProcesses()
        {
            var processes = Process.GetProcesses().Where(x => x.Threads.Count < 5).OrderBy(x => x.Id)
                .GroupBy(x => x.BasePriority);
            foreach(var processGroup in processes)
            {
                foreach (var process in processGroup)
                {
                    Console.WriteLine($"Process name: {process.ProcessName}, Process id: {process.Id}");
                }
            }
        }

        private void PrintSystemThreads()
        {
            var totalThreads = Process.GetProcesses().Select(x => x.Threads.Count).Sum();
            Console.WriteLine($"Total threads: {totalThreads}");
        }
    }
}
