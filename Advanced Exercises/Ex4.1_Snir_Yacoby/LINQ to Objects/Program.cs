using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_to_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetAssembly(typeof(string));
            var interfacesNames = from x in assembly.GetTypes()
                                  where x.IsInterface;

            foreach(string name in interfacesNames)
            {
                Console.WriteLine($"Interface Name: {name}, Number of methods: {Type.GetType(name).GetMethods().Count()}");
            }
        }
    }
}
