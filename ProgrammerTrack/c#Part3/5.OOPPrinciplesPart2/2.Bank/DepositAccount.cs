using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class DepositAccount : Account, IWithdrawable, IDepositable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }
        public override decimal CalcInterestAmount(uint months)
        {
            if (0 <= this.Balance && this.Balance <= 1000)
            {
                //no interest
                return 0;
            }
            return base.CalcInterestAmount(months);
        }

        public void Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                this.Balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can not deposit negative amount of money.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount >= 0)
            {
                this.Balance -= amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can not withdraw negative amount of money.");
            }
        }
    }
}
