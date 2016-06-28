using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence.");
            string sentence = Console.ReadLine().Trim();
            while(sentence != string.Empty)
            {
                string[] words = sentence.Split(' ');
                Console.WriteLine("Number of words: " + words.Length);
                Array.Reverse(words);
                foreach (var item in words)
                {
                    Console.Write(item);
                }

                Console.WriteLine();
                Array.Sort(words);
                foreach (var item in words)
                {
                    Console.Write(item);
                }

                Console.WriteLine();
                Console.WriteLine("Enter a sentence.");
                sentence = Console.ReadLine();
            }
        }
    }
}
