using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Rectangle(double i_Height, double i_Width, ConsoleColor i_Color) : base(i_Color)
        {
            Height = i_Height;
            Width = i_Width;
        }

        public Rectangle(double i_Height, double i_Width)
        {
            Height = i_Height;
            Width = i_Width;
        }

        public override double Area
        {
            get
            {
                return Height * Width;
            }
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Rectangle:");
            Console.WriteLine("Height: " + Height);
            Console.WriteLine("Width: " + Width);
        }
    }
}
