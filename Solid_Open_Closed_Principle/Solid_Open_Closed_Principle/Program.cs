// See https://aka.ms/new-console-template for more information
using Solid_Open_Closed_Principle;

var devCalculations = new List<BaseSalaryCalculator>
{
    new SeniorDevSalarycalculator(new DeveloperReport{Id=1,Name="Dev1",Level="Senior Developer",HourlyRate=30.5,Workinghours=160}),
    new JuniorDevSalaryCalculator(new DeveloperReport{Id=2,Name="Dev2",Level="Junior Developer",HourlyRate=20,Workinghours=150}),
    new SeniorDevSalarycalculator(new DeveloperReport{Id=3,Name="Dev3",Level="Senior Developer",HourlyRate=30.5,Workinghours=180})
};
var calculator = new SalaryCalculator(devCalculations);
Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");
