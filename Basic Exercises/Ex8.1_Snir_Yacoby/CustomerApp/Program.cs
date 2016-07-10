using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] array = new Customer[5];

            array[0] = new Customer("Snir Yacoby", 100, "Zrubavel 4");
            array[1] = new Customer("Aviel Moshe Yosef", 15, "Najara 51");
            array[2] = new Customer("Ronen Eliav", 20, "Eshel 24");
            array[3] = new Customer("Yossi Yadgar", 5, "Hatizmoret 40");
            array[4] = new Customer("Asi Abergel", 7, "Menashe Tselach 12");

            CustomerFilter filter = new CustomerFilter(AKFirstLetterFilter);

            ICollection<Customer> filteredArray = GetCustomers(array, filter);

            Console.WriteLine("Filter using function\n");
            foreach(Customer customer in filteredArray)
            {
                Console.WriteLine("Name: " + customer.Name);
                Console.WriteLine("Id: " + customer.Id);
                Console.WriteLine("Address: " + customer.Address);
                Console.WriteLine();
            }

            filteredArray = GetCustomers(array, delegate (Customer customer)
            {
                char firstLetter = customer.Name[0];
                bool filterAnswer = false;

                if (firstLetter >= 'L' && firstLetter <= 'Z')
                {
                    filterAnswer = true;
                }

                return filterAnswer;
            });

            Console.WriteLine("Filter using anonymous delegate\n");
            foreach (Customer customer in filteredArray)
            {
                Console.WriteLine("Name: " + customer.Name);
                Console.WriteLine("Id: " + customer.Id);
                Console.WriteLine("Address: " + customer.Address);
                Console.WriteLine();
            }

            filteredArray = GetCustomers(array, customer =>
            {
                bool filterAnswer = false;

                if (customer.Id < 100)
                {
                    filterAnswer = true;
                }

                return filterAnswer;
            });

            Console.WriteLine("Filter using lambda expression\n");
            foreach (Customer customer in filteredArray)
            {
                Console.WriteLine("Name: " + customer.Name);
                Console.WriteLine("Id: " + customer.Id);
                Console.WriteLine("Address: " + customer.Address);
                Console.WriteLine();
            }
        }

        static ICollection<Customer> GetCustomers(ICollection<Customer> i_Collection, CustomerFilter i_Filter)
        {
            List<Customer> toReturn = new List<Customer>();

            foreach(Customer customer in i_Collection)
            {
                if (i_Filter(customer))
                {
                    toReturn.Add(customer);
                }
            }

            return toReturn;
        }

        static bool AKFirstLetterFilter(Customer i_Customer)
        {
            char firstLetter = i_Customer.Name[0];
            bool filterAnswer = false;

            if (firstLetter >= 'A' && firstLetter <= 'K')
            {
                filterAnswer = true;
            }

            return filterAnswer;
        }
        
    }
}
