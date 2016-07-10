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
                List<FileInfo> files, filteredFiles = new List<FileInfo>();
                Program p = new Program();

                try
                {
                    files = p.EnumerateFilesWithinDirectory(args[0]);
                    foreach (FileInfo file in files)
                    {
                        if (file.Name.Contains(args[1]))
                        {
                            filteredFiles.Add(file);
                        }
                    }

                    foreach (FileInfo file in filteredFiles)
                    {
                        Console.WriteLine($"Filename: {file.Name}, Size: {file.Length} Bytes");
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

        List<FileInfo> EnumerateFilesWithinDirectory(string path)
        {
            IEnumerable<string> subdirectories = Directory.GetDirectories(path);
            DirectoryInfo currentDirectory = new DirectoryInfo(path);
            List<FileInfo> files = currentDirectory.GetFiles().ToList();
            
            foreach(string subdirectory in subdirectories)
            {
                files.AddRange(EnumerateFilesWithinDirectory(subdirectory));
            }

            return files;
        }
    }
}
