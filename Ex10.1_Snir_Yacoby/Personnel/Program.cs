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
            Program p = new Program();
            List<string> names = p.ReadStringsFromFile();

            foreach(string name in names)
            {
                Console.WriteLine("Name: " + name);
            }
        }

        List<string> ReadStringsFromFile()
        {
            FileStream fs = new FileStream("Names.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            List<string> answer = new List<string>();

            while (!reader.EndOfStream)
            {
                answer.Add(reader.ReadLine());
            }

            reader.Close();
            fs.Close();

            return answer;
        }
    }
}
