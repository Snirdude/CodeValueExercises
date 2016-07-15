using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_to_Objects
{
    class A
    {
        public string Name { get; set; }
        public int Id { get; }
        public double Balance { get; set; }

        public A(string name, int id, double balance)
        {
            Name = name;
            Id = id;
            Balance = balance;
        }
    }
}
