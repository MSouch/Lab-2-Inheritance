using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class EmployeeManager
{
    public List<Employee> Employees { get; } = new List<Employee>();

    public void FillListFromFile(string filePath)
    {
        var lines = File.ReadAllLines("C:\\Users\\msouc\\OneDrive\\Desktop\\employees.txt");
        foreach (var line in lines)
        {
            var parts = line.Split(':');
            var id = parts[0].Trim();
            var name = parts[1].Trim();
            var sin = parts[4].Trim(); // Assuming the SIN is the fifth element
            var lastPart = parts.Last().Trim();
            var secondLastPart = parts[^2].Trim();

            if (decimal.TryParse(secondLastPart, out decimal rateOrSalary) && int.TryParse(lastPart, out int hoursOrNotUsed))
            {
                // This is a Wage or PartTime employee
                if (id.StartsWith("5") || id.StartsWith("6") || id.StartsWith("7"))
                {
                    // Wage Employee
                    Employees.Add(new Wage(id, name, sin, rateOrSalary, hoursOrNotUsed));
                }
                else if (id.StartsWith("8") || id.StartsWith("9"))
                {
                    // PartTime Employee
                    Employees.Add(new PartTime(id, name, sin, rateOrSalary, hoursOrNotUsed));
                }
            }
            else if (decimal.TryParse(secondLastPart, out decimal salary))
            {
                // This is a Salaried employee
                Employees.Add(new Salaried(id, name, sin, salary));
            }
        }
    }

    public decimal CalculateAverageWeeklyPay()
    {
        if (!Employees.Any()) return 0;
        return Employees.Average(emp => emp.CalculateWeeklyPay());
    }

    public (string Name, decimal Pay) GetHighestWeeklyPayForWageEmployees()
    {
        var highestPaid = Employees.OfType<Wage>()
                                   .Select(emp => new { emp.Name, Pay = emp.CalculateWeeklyPay() })
                                   .OrderByDescending(emp => emp.Pay)
                                   .FirstOrDefault();
        return highestPaid != null ? (highestPaid.Name, highestPaid.Pay) : ("None", 0);
    }

    public (string Name, decimal Salary) GetLowestSalaryForSalariedEmployees()
    {
        var lowestSalary = Employees.OfType<Salaried>()
                                    .Select(emp => new { emp.Name, emp.WeeklySalary })
                                    .OrderBy(emp => emp.WeeklySalary)
                                    .FirstOrDefault();
        return lowestSalary != null ? (lowestSalary.Name, lowestSalary.WeeklySalary) : ("None", 0);
    }

    public Dictionary<string, double> GetPercentageOfEmployeesInEachCategory()
    {
        int totalEmployees = Employees.Count;
        if (totalEmployees == 0) return new Dictionary<string, double> { { "Salaried", 0 }, { "Wage", 0 }, { "PartTime", 0 } };

        var percentages = new Dictionary<string, double>
    {
        { "Salaried", Employees.OfType<Salaried>().Count() * 100.0 / totalEmployees },
        { "Wage", Employees.OfType<Wage>().Count() * 100.0 / totalEmployees },
        { "PartTime", Employees.OfType<PartTime>().Count() * 100.0 / totalEmployees }
    };

        return percentages;
    }
}