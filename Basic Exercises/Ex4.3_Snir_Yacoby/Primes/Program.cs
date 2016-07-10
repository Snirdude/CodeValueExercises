using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two positive integers seperated by comma: ");
            string[] input = Console.ReadLine().Split(',');
            int a, b;

            if(int.TryParse(input[0].Trim(), out a) && int.TryParse(input[1].Trim(), out b))
            {
                if (a < 0 || b < 0)
                {
                    Console.WriteLine("Can't accept negative values");
                    return;
                }

                Stopwatch sw = Stopwatch.StartNew();
                int[] primes = CalcPrimes(a, b);

                sw.Stop();
                Console.WriteLine("Prime numbers between " + a + " and " + b);
                foreach (var item in primes)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
                Console.WriteLine("Time took to calculate: " + sw.ElapsedMilliseconds + " ms");
            }
            else
            {
                Console.WriteLine("Invalid arguments format");
            }
        }

        static int[] CalcPrimes(int i_RangeMin, int i_RangeMax)
        {
            ArrayList primes = new ArrayList();
            bool isPrime;
            int[] arrayPrimes;

            if (i_RangeMin % 2 == 0)
            {
                i_RangeMin++;
            }

            for(int i = i_RangeMin; i <= i_RangeMax; i = i + 2)
            {
                isPrime = true;

                for(int j = 2; j * j < i; j++)
                {
                    if(i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                }
            }

            arrayPrimes = new int[primes.Count];
            primes.CopyTo(arrayPrimes);

            return arrayPrimes;
        }
    }
}
