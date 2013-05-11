using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Human
{
    class Worker : Human
    {
        public decimal WeekSalary { get; set; }
        public double WorkHoursPerDay { get; set; }
        public int WorkDaysPerWeek { get; set; }

        public Worker(string firstName, string lastName, decimal weekSalary = 0, double workHoursPerDay = 0, int workDaysPerWeek = 0)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
            this.WorkDaysPerWeek = workDaysPerWeek;
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = this.WeekSalary / (decimal)(this.WorkHoursPerDay * this.WorkDaysPerWeek);
            return moneyPerHour;
        }
    }
}
