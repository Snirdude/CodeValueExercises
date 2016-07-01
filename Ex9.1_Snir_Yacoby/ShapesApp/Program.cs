using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeManager sm = new ShapeManager();

            sm.Add(new Rectangle(3.4, 5.2, ConsoleColor.Red));
            sm.Add(new Rectangle(4, 5, ConsoleColor.DarkBlue));
            sm.Add(new Ellipse(2.5, 4, ConsoleColor.Blue));
            sm.Add(new Circle(5));
            sm.DisplayAll();
        }
    }
}
