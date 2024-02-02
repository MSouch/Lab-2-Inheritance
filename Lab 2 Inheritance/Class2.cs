// Defines a Wage employee type, inheriting from the Employee base class.
public class Wage : Employee
{
    // Property to store the hourly rate of pay for the wage employee.
    public decimal HourlyRate { get; set; }

    // Property to store the number of hours worked by the wage employee in a week.
    public int HoursWorked { get; set; }

    // Constructor for creating a new Wage employee instance.
    // It takes employee ID, name, SIN, hourly rate, and hours worked as parameters.
    public Wage(string employeeID, string name, string sin, decimal hourlyRate, int hoursWorked)
        : base(employeeID, name, sin) // Calls the base class constructor with employeeID, name, and sin.
    {
        // Initializes the HourlyRate property with the provided hourlyRate argument.
        HourlyRate = hourlyRate;

        // Initializes the HoursWorked property with the provided hoursWorked argument.
        HoursWorked = hoursWorked;
    }

    // Overrides the CalculateWeeklyPay method from the Employee base class.
    // This method calculates the weekly pay for a wage employee, including overtime pay.
    public override decimal CalculateWeeklyPay()
    {
        // Checks if the hours worked are 40 or less.
        if (HoursWorked <= 40)
        {
            // For 40 or fewer hours, pay is simply the hourly rate times the number of hours worked.
            return HourlyRate * HoursWorked;
        }
        else
        {
            // For hours worked over 40, pay includes time and a half for overtime.
            // The first 40 hours are paid at the regular hourly rate.
            // Overtime hours (hours over 40) are paid at 1.5 times the hourly rate.
            return (HourlyRate * 40) + ((HoursWorked - 40) * HourlyRate * 1.5M);
        }
    }
}