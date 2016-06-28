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
            m_Balance += i_Amount;
        }

        public bool Withdraw(int i_Amount)
        {
            bool success = false;

            if(i_Amount <= m_Balance)
            {
                m_Balance -= i_Amount;
                success = true;
            }

            return success;
        }

        public void Transfer(Account i_TargetAccount, int i_Amount)
        {
            if (this.Withdraw(i_Amount))
            {
                i_TargetAccount.Deposit(i_Amount);
            }
        }
    }
}
