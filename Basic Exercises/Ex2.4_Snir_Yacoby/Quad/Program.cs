using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 3)
            {
                double a, b, c;

                if (double.TryParse(args[0], out a) && double.TryParse(args[1], out b) && double.TryParse(args[2], out c))
                {
                    double discriminant = Math.Pow(b, 2) - (4 * a * c);

                    if (discriminant > 0)
                    {
                        double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

                        Console.WriteLine("x = " + x1 + ", " + x2);
                    }
                    else if (discriminant == 0)
                    {
                        double x = -b / (2 * a);

                        Console.WriteLine("x = " + x);
                    }
                    else
                    {
                        Console.WriteLine("No solution");
                    }
                }
            }
            else
            {
                Console.WriteLine("Not enough arugments");
            }
        }
    }
}
