using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        private int m_Id;
        private int m_Balance;

        public int Id
        {
            get
            {
                return m_Id;
            }
        }

        public int Balance
        {
            get
            {
                return m_Balance;
            }
        }

        public Account(int i_Id)
        {
            m_Id = i_Id;
            m_Balance = 0;
        }

        public void Deposit(int i_Amount)
        {
            if(i_Amount <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            m_Balance += i_Amount;
        }

        public void Withdraw(int i_Amount)
        {
            if (i_Amount <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if(i_Amount <= m_Balance)
            {
                m_Balance -= i_Amount;
                
            }
            else
            {
                throw new InsufficientFundsException("Insufficient Funds");
            }
        }

        public void Transfer(Account i_TargetAccount, int i_Amount)
        {
            Console.WriteLine("Amount before: " + Balance);
            try
            {
                this.Withdraw(i_Amount);
                i_TargetAccount.Deposit(i_Amount);
            }
            finally
            {
                Console.WriteLine("Amount after: " + Balance);
                Console.WriteLine("Attempted a transfer.");
            }
        }
    }
}
