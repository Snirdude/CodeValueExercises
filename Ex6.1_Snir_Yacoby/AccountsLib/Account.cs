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
        private long m_Balance;

        public int Id
        {
            get
            {
                return m_Id;
            }
        }

        public long Balance
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

        public void Deposit(long i_Amount)
        {
            if(i_Amount <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            m_Balance += i_Amount;
        }

        public bool Withdraw(long i_Amount)
        {
            if (i_Amount <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            bool success = false;

            if(i_Amount <= m_Balance)
            {
                m_Balance -= i_Amount;
                success = true;
            }

            return success;
        }

        public void Transfer(Account i_TargetAccount, long i_Amount)
        {
            Console.WriteLine("Amount before: " + Balance);
            try
            {
                if (this.Withdraw(i_Amount))
                {
                    i_TargetAccount.Deposit(i_Amount);
                }
            }
            finally
            {
                Console.WriteLine("Amount after: " + Balance);
                Console.WriteLine("Attempted a transfer.");
            }
        }
    }
}
