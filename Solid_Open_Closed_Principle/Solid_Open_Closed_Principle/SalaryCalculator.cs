using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Open_Closed_Principle
{
    public class SalaryCalculator
    {
        private readonly IEnumerable<BaseSalaryCalculator> _salaryCalculators;
        public SalaryCalculator(IEnumerable<BaseSalaryCalculator> salaryCalculators)
        {
            _salaryCalculators = salaryCalculators;
        }
        public double CalculateTotalSalaries()
        {
            double totalSalaries = 0;
            foreach(var devCalc in _salaryCalculators)
            {
                totalSalaries=totalSalaries+devCalc.CalculateSalary();
            }
            return totalSalaries;
        }
    }
}
