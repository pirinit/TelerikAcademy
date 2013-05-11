using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalcInterestAmount(uint months)
        {
            if (this.Customer is IndividualCustomer)
            {
                if (months <= 3)
                {
                    //no interest for the first 3 months
                    return 0;
                }
                else
                {
                    return base.CalcInterestAmount(months);
                }
            }
            else if (this.Customer is CompanyCustomer)
            {
                if (months <= 2)
                {
                    //no interest for the first 2 months
                    return 0;
                }
                else
                {
                    return base.CalcInterestAmount(months);
                }
            }
            return base.CalcInterestAmount(months);
        }

        public void Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                this.Balance -= amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can not deposit negative amount of money.");
            }
        }
    }
}
