using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_to_Objects
{
    class ExerciseMethods
    {
        public void PrintMscorlibInterfaces()
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

        public void PrintProcesses()
        {
            var processes = Process.GetProcesses();
            var processGroups = from x in processes
                               where x.Threads.Count < 5 && !IsSystem(x)
                               orderby x.Id
                               group new
                               {
                                   x.ProcessName,
                                   x.Id,
                                   x.StartTime
                               }
                               by x.BasePriority;

            foreach (var processGroup in processGroups)
            {
                foreach (var process in processGroup)
                {
                    Console.WriteLine(process);
                }
            }
        }

        private bool IsSystem(Process process)
        {
            try
            {
                var item = process.StartTime;
                return false;
            }
            catch
            {
                return true;
            }
        }

        public void PrintSystemThreads()
        {
            var totalThreads = Process.GetProcesses().Select(x => x.Threads.Count).Sum();
            Console.WriteLine($"Total threads: {totalThreads}");
        }

        public void CopyToTest()
        {
            A a = new A("Snir", 2015, 12.5);
            B b = new B("Ronen", 2016, 'A');
            b.CopyTo(a);
            ObjectExtensions.CopyTo(a, b);
            Console.WriteLine($"b copied to a :{a.Name} {a.Id} {a.Balance}");
            a = new A("Snir", 2015, 12.5);
            a.CopyTo(b);
            Console.WriteLine($"a copied to b :{b.Name} {b.Id} {b.Class}");
        }
    }
}
