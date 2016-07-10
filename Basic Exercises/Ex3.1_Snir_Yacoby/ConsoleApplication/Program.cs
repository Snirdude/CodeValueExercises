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
            Account account1 = AccountFactory.CreateAccount(100);
            Console.WriteLine("Account 1 balance: " + account1.Balance);
            Console.WriteLine("1. Deposit\n2. Withdraw\n3. Balance");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Amount? ");
                    account1.Deposit(int.Parse(Console.ReadLine()));
                    break;
                case "2":
                    Console.WriteLine("Amount? ");
                    account1.Withdraw(int.Parse(Console.ReadLine()));
                    break;
                case "3":
                    Console.WriteLine("Balance: " + account1.Balance);
                    break;
            }

            Account account2 = AccountFactory.CreateAccount(100000);
            Console.WriteLine("Account 1 balance: " + account1.Balance);
            Console.WriteLine("Account 2 balance: " + account2.Balance);
            Console.WriteLine("How much to transfer?");
            account1.Transfer(account2, int.Parse(Console.ReadLine()));
            Console.WriteLine("Account 1 balance: " + account1.Balance);
            Console.WriteLine("Account 2 balance: " + account2.Balance);
        }
    }
}
