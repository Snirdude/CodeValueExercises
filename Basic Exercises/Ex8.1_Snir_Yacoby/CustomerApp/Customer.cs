using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    delegate bool CustomerFilter(Customer customer);

    class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public string Address { get; private set; }

        public Customer(string name, int id, string address)
        {
            Name = name;
            Id = id;
            Address = address;
        }

        public int CompareTo(Customer other)
        {
            return string.Compare(Name, other?.Name, true);
        }

        public bool Equals(Customer other)
        {
            return Name.Equals(other?.Name) && Id.Equals(other?.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                return Equals((Customer)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
