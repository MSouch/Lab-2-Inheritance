class Program
{
    static void Main(string[] args)
    {
        // Create an instance of EmployeeManager to manage employee data.
        EmployeeManager manager = new EmployeeManager();

        // Load employee data from a file named "employees.txt".
        manager.FillListFromFile("employees.txt");

        // Calculate and display the average weekly pay of all employees.
        Console.WriteLine($"Average weekly pay: {manager.CalculateAverageWeeklyPay():C2}");

        // Find and display the highest weekly pay among wage employees.
        var (nameHighestPay, payHighestPay) = manager.GetHighestWeeklyPayForWageEmployees();
        Console.WriteLine($"Highest weekly pay among wage employees: {nameHighestPay} with {payHighestPay:C2}");

        // Find and display the lowest salary among salaried employees.
        var (nameLowestSalary, salaryLowestSalary) = manager.GetLowestSalaryForSalariedEmployees();
        Console.WriteLine($"Lowest salary among salaried employees: {nameLowestSalary} with {salaryLowestSalary:C2}");

        // Calculate and display the percentage of employees in each category (Salaried, Wage, PartTime).
        var percentages = manager.GetPercentageOfEmployeesInEachCategory();
        Console.WriteLine("Percentage of employees in each category:");
        foreach (var category in percentages)
        {
            // The ":N2" format specifier is used to format the output as a number with two decimal places.
            Console.WriteLine($"{category.Key}: {category.Value:N2}%");
        }
    }
}