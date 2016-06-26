using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>();

            dictionary.Add(1, "one");
            dictionary.Add(2, "two");
            dictionary.Add(3, "three");
            dictionary.Add(1, "ich");
            dictionary.Add(2, "nee");
            dictionary.Add(3, "sun");

            foreach(KeyValuePair<int, string> kvp in dictionary)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }

            Console.WriteLine("Count: " + dictionary.Count);
            dictionary.Remove(1, "one");
            dictionary.Remove(3);
            foreach (KeyValuePair<int, string> kvp in dictionary)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }

            Console.WriteLine("Count: " + dictionary.Count);
        }
    }
}
