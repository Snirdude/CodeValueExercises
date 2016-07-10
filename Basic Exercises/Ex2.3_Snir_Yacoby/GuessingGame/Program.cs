using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int secret = new Random().Next(1, 100);
            int i;

            Console.WriteLine("Guess my number :)");
            for(i = 1; i <= 7; i++)
            {
                int guess = int.Parse(Console.ReadLine());
                if (guess > secret)
                {
                    Console.WriteLine("Too big");
                }
                else if (guess < secret)
                {
                    Console.WriteLine("Too small");
                }
                else
                {
                    break;
                }
            }

            if(i == 8)
            {
                Console.WriteLine("You failed, my number was " + secret);
            }
            else
            {
                Console.WriteLine("Success! Number of guesses: " + i);
            }
        }
    }
}
