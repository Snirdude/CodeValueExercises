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
            Rational b = new Rational(3, 6);
            Rational c = Rational.Add(a, b);
            Rational d = Rational.Mul(a, b);
            Console.WriteLine("a = " + a + ", value: " + a.Value);
            Console.WriteLine("b = " + b + ", value: " + b.Value);
            Console.WriteLine("a + b = " + c + ", value: " + c.Value);
            Console.WriteLine("a * b = " + d + ", value: " + d.Value);
            Console.WriteLine("a == b? " + a.Equals(b).ToString());
        }
    }
}
