// Defines a Salaried employee type, inheriting from the Employee base class.
public class Salaried : Employee
{
    // Property to store the fixed weekly salary of the salaried employee.
    public decimal WeeklySalary { get; set; }

    // Constructor for creating a new Salaried employee instance.
    // It takes employee ID, name, SIN, and weekly salary as parameters.
    public Salaried(string employeeID, string name, string sin, decimal weeklySalary)
        : base(employeeID, name, sin) // Calls the base class constructor with employeeID, name, and sin.
    {
        // Initializes the WeeklySalary property with the provided weeklySalary argument.
        WeeklySalary = weeklySalary;
    }

    // Overrides the CalculateWeeklyPay method from the Employee base class.
    // For salaried employees, this simply returns their fixed weekly salary.
    public override decimal CalculateWeeklyPay()
    {
        // Returns the weekly salary as the weekly pay for a salaried employee.
        // Since salaried employees have a fixed salary, no additional calculation is needed.
        return WeeklySalary;
    }
}
