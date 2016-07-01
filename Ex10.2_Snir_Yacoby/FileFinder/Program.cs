using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                IEnumerable<string> files = new List<string>();
                List<string> filteredFiles = new List<string>();

                try
                {
                    files = Directory.EnumerateFiles(args[0]);
                    foreach (string file in files)
                    {
                        if (file.Contains(args[1]))
                        {
                            filteredFiles.Add(file);
                        }
                    }

                    foreach (string file in filteredFiles)
                    {
                        Console.WriteLine("Filename: " + file);
                    }
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Not enough parameters");
            }
        }
    }
}
