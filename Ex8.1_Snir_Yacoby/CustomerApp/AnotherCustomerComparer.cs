using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    class AnotherCustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            if(x == null)
            {
                return -1;
            }
            else
            {
                return x.Id.CompareTo(y?.Id);
            }
        }
    }
}
