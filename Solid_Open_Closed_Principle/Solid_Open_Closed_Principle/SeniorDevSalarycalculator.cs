namespace Solid_Open_Closed_Principle
{
    public class SeniorDevSalarycalculator : BaseSalaryCalculator
    {
        public SeniorDevSalarycalculator(DeveloperReport report) : base(report) { }

        public override double CalculateSalary()
        {
            return DeveloperReport.HourlyRate * DeveloperReport.Workinghours * 1.2;
        }
    }
}