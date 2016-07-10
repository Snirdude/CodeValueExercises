using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape, IPersist, IComparable
    {
        public double HorizontalRadius { get; set; }
        public double VerticalRadius { get; set; }

        public Ellipse(double i_HorizontalR, double i_VerticalR, ConsoleColor i_Color) : base(i_Color)
        {
            HorizontalRadius = i_HorizontalR;
            VerticalRadius = i_VerticalR;
        }

        public Ellipse(double i_HorizontalR, double i_VerticalR)
        {
            HorizontalRadius = i_HorizontalR;
            VerticalRadius = i_VerticalR;
        }

        public override double Area
        {
            get
            {
                return Math.PI * HorizontalRadius * VerticalRadius;
            }
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Ellipse:");
            Console.WriteLine("Horizontal Radius: " + HorizontalRadius);
            Console.WriteLine("Vertical Radius: " + VerticalRadius);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("Horizontal Radius: " + HorizontalRadius + ", Vertical Radius: " + VerticalRadius + ".");
        }

        public int CompareTo(object obj)
        {
            int result;

            if(this.Area > ((Ellipse)obj).Area)
            {
                result = 1;
            }
            else if (this.Area < ((Ellipse)obj).Area)
            {
                result = -1;
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}
