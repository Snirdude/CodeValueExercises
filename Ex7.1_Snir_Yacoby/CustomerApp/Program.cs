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

            array[0] = new Customer("Snir Yacoby", 10, "Zrubavel 4");
            array[1] = new Customer("Aviel Moshe Yosef", 15, "Najara 51");
            array[2] = new Customer("Ronen Eliav", 20, "Eshel 24");
            array[3] = new Customer("Yossi Yadgar", 5, "Hatizmoret 40");
            array[4] = new Customer("Asi Abergel", 7, "Menashe Tselach 12");

            Console.WriteLine("Before sort:");
            foreach(Customer customer in array)
            {
                Console.WriteLine("Name: " + customer.Name);
                Console.WriteLine("Id:" + customer.Id);
                Console.WriteLine("Address:" + customer.Address);
                Console.WriteLine();
            }

            Array.Sort(array);

            Console.WriteLine("After first sort:");
            foreach (Customer customer in array)
            {
                Console.WriteLine("Name: " + customer.Name);
                Console.WriteLine("Id:" + customer.Id);
                Console.WriteLine("Address:" + customer.Address);
                Console.WriteLine();
            }

            Array.Sort(array, new AnotherCustomerComparer());

            Console.WriteLine("After second sort:");
            foreach (Customer customer in array)
            {
                Console.WriteLine("Name: " + customer.Name);
                Console.WriteLine("Id:" + customer.Id);
                Console.WriteLine("Address:" + customer.Address);
                Console.WriteLine();
            }
        }
    }
}
