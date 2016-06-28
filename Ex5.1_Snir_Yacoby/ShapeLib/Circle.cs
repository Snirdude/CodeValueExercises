using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        public double Radius { get; set; }

        public Circle(double i_Radius, ConsoleColor i_Color) : base(i_Radius, i_Radius, i_Color)
        {
            Radius = i_Radius;
        }

        public Circle(double i_Radius) : base(i_Radius, i_Radius)
        {
            Radius = i_Radius;
        }

        public override void Display()
        {
            Console.BackgroundColor = Color;
            Console.WriteLine("Circle:");
            Console.WriteLine("Radius: " + Radius);
        }
    }
}
