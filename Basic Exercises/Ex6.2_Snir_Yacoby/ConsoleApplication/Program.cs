using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsLib;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Account account1 = AccountFactory.CreateAccount(100);
                Account account2 = AccountFactory.CreateAccount(100000);
                Console.WriteLine("Account 1 balance: " + account1.Balance);
                Console.WriteLine("Account 2 balance: " + account2.Balance);
                Console.WriteLine("How much to transfer?");
                account1.Transfer(account2, int.Parse(Console.ReadLine()));
                Console.WriteLine("Account 1 balance: " + account1.Balance);
                Console.WriteLine("Account 2 balance: " + account2.Balance);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
