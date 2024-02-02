// Inherits from Employee
public class PartTime : Employee
{
    // Property to store the hourly rate of pay for the part-time employee.
    public decimal HourlyRate { get; set; }

    // Property to store the number of hours worked by the part-time employee in a week.
    public int HoursWorked { get; set; }

    // Constructor for creating a new PartTime employee instance.
    // It takes employee ID, name, SIN, hourly rate, and hours worked as parameters.
    public PartTime(string employeeID, string name, string sin, decimal hourlyRate, int hoursWorked)
        : base(employeeID, name, sin) // Calls the base class constructor with employeeID, name, and sin.
    {
        // Initializes the HourlyRate property with the provided hourlyRate argument.
        HourlyRate = hourlyRate;

        // Initializes the HoursWorked property with the provided hoursWorked argument.
        HoursWorked = hoursWorked;
    }

    // Overrides the CalculateWeeklyPay method from the Employee base class.
    // This method calculates the weekly pay for a part-time employee based on their hourly rate and hours worked.
    public override decimal CalculateWeeklyPay()
    {
        // Calculates pay by multiplying the hourly rate by the number of hours worked.
        return HourlyRate * HoursWorked;
    }
}