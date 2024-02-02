public abstract class Employee
{
    public string EmployeeID { get; set; }
    public string Name { get; set; }
    public string SIN { get; set; }

    // Constructor to initialize common properties
    protected Employee(string employeeID, string name, string sin)
    {
        EmployeeID = employeeID;
        Name = name;
        SIN = sin;
    }

    // Abstract method to calculate weekly pay, to be implemented by derived classes
    public abstract decimal CalculateWeeklyPay();
}