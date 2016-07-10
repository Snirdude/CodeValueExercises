using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational a = new Rational(2, 4);
            Rational b = new Rational(3, 9);
            Rational c = a + b;
            Rational d = a * b;
            Rational e = a - b;
            Rational f = a / b;
            double g = f;
            Rational h = (Rational)3;
            Console.WriteLine("a = " + a + ", value: " + a.Value);
            Console.WriteLine("b = " + b + ", value: " + b.Value);
            Console.WriteLine("a + b = " + c + ", value: " + c.Value);
            Console.WriteLine("a * b = " + d + ", value: " + d.Value);
            Console.WriteLine("a - b = " + e + ", value: " + e.Value);
            Console.WriteLine("a / b = " + f + ", value: " + f.Value);
            Console.WriteLine($"f:{f} converted implicitly to double - {g}");
            Console.WriteLine($"number 3 converted explicitly to Rational - {h}");
        }
    }
}
