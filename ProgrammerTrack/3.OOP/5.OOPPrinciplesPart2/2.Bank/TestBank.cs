using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class TestBank
    {
        static void Main(string[] args)
        {
            IndividualCustomer pesho = new IndividualCustomer("Pesho");
            CompanyCustomer company = new CompanyCustomer("Pesho Corp.");

            DepositAccount peshoAcc = new DepositAccount(pesho, 1550m, 0.005m);
            LoanAccount companyAcc = new LoanAccount(company, 20000m, 0.01m);

            //calculating interest
            Console.WriteLine("Interest amount for pesho's account for 10 months is {0}.",peshoAcc.CalcInterestAmount(10));
            Console.WriteLine("Interest amount for pesho company's account for 10 months is {0}.", companyAcc.CalcInterestAmount(10));


            //checking withdraw/deposit functionality
            Console.WriteLine("Pesho's deposit account balance is: {0}", peshoAcc.Balance);
            Console.WriteLine("Pesho company's loan account balance is: {0}", companyAcc.Balance);

            peshoAcc.Withdraw(1800m);
            companyAcc.Deposit(5000m);

            Console.WriteLine("Pesho's deposit account balance is: {0}", peshoAcc.Balance);
            Console.WriteLine("Pesho company's loan account balance is: {0}", companyAcc.Balance);
        }
    }
}
