namespace Solid_Open_Closed_Principle
{
    public abstract class BaseSalaryCalculator
    {
        protected DeveloperReport DeveloperReport { get; set; }
        public BaseSalaryCalculator(DeveloperReport developerReport)
        {
            DeveloperReport = developerReport;
        }

        public abstract double CalculateSalary();
    }
}
