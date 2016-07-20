using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new Reader().ReadStringsFromFile();

            foreach(string name in names)
            {
                if(name != string.Empty)
                {
                    Console.WriteLine("Name: " + name);
                }
            }
        }
    }
}
