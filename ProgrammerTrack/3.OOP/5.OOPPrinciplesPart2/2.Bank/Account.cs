using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    abstract class Account
    {
        public Customer Customer { get; protected set; }
        public decimal Balance { get; protected set; }
        public decimal InterestRate { get; protected set; }

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            if (balance >= 0)
            {
                this.Balance = balance;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Balance can not be negative.");
            }
            if (interestRate >= 0)
            {
                this.InterestRate = interestRate;
            }
            else
            {
                throw new ArgumentOutOfRangeException("InterestRate can not be negative.");
            }
        }
        public virtual decimal CalcInterestAmount(uint months)
        {
            return this.InterestRate * months;
        }
    }
}
