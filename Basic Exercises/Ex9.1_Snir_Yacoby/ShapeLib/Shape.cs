using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        public ConsoleColor Color
        {
            get; set;
        }

        public Shape(ConsoleColor i_Color)
        {
            Color = i_Color;
        }

        public Shape() : this(ConsoleColor.White) { }

        public virtual void Display()
        {
            Console.BackgroundColor = Color;
        }

        public abstract double Area { get; }
    }
}
