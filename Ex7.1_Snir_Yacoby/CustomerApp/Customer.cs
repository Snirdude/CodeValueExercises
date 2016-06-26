using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }

        public Customer(string name, int id, string address)
        {
            Name = name;
            Id = id;
            Address = address;
        }

        public int CompareTo(Customer other)
        {
            return string.Compare(Name, other.Name, true);
        }

        public bool Equals(Customer other)
        {
            return Name.Equals(other.Name) && Id.Equals(other.Id);
        }
    }
}
