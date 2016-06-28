using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public static class AccountFactory
    {
        private static int s_GlobalId;

        static AccountFactory()
        {
            s_GlobalId = 1;
        }

        public static Account CreateAccount(int i_InitialBalance)
        {
            Account account = new Account(s_GlobalId++);

            account.Deposit(i_InitialBalance);

            return account;
        }
    }
}
