using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_to_Objects
{
    class B
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char Class { get; set; }

        public B(string name, int id, char iClass)
        {
            Name = name;
            Id = id;
            Class = iClass;
        }
    }
}
