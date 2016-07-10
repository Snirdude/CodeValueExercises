using ShapeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    class ShapeManager
    {
        private ArrayList m_Shapes;

        public Shape this[int i_Index]
        {
            get
            {
                return (Shape)m_Shapes[i_Index];
            }
        }

        public int Count
        {
            get
            {
                return m_Shapes.Count;
            }
        }

        public ShapeManager()
        {
            m_Shapes = new ArrayList();
        }

        public void Add(Shape i_Shape)
        {
            m_Shapes.Add(i_Shape);
        }

        public void DisplayAll()
        {
            foreach(Shape shape in m_Shapes)
            {
                shape.Display();
                Console.WriteLine("Area: " + shape.Area);
            }
        }
    }
}
