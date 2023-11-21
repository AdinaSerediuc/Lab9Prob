using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9Prob
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "John Doe", Id = Guid.NewGuid(), Salary = 6000, Department = new Development() },
            new Employee { Name = "Jane Smith", Id = Guid.NewGuid(), Salary = 5500, Department = new Testing() },
            new Employee { Name = "Bob Johnson", Id = Guid.NewGuid(), Salary = 7000, Department = new HumanResources() },
            new Employee { Name = "Alice Brown", Id = Guid.NewGuid(), Salary = 4800, Department = new Maintenance() },
            new Employee { Name = "Charlie White", Id = Guid.NewGuid(), Salary = 5200, Department = new Logistics() },
        };

        // noOfWellPayedEmployees
        double salaryThreshold = 6000;
        var wellPaidEmployees = employees.FindAll(e => e.Salary > salaryThreshold);
        Console.WriteLine("Employees with salary greater than {0}:", salaryThreshold);
        wellPaidEmployees.ForEach(Console.WriteLine);

        // employeesFromMaintenance
        var maintenanceEmployees = employees.FindAll(e => e.Department == "Maintenance");
        Console.WriteLine("\nEmployees from Maintenance:");
        maintenanceEmployees.ForEach(Console.WriteLine);

        // maxSalary
        var maxSalaryEmployee = employees.OrderByDescending(e => e.Salary).FirstOrDefault();
        Console.WriteLine("\nEmployee(s) with the highest salary:");
        Console.WriteLine(maxSalaryEmployee);

        // maxSalaryForDevelopment
        var maxSalaryDevelopmentEmployee = employees.Where(e => e.Department == "Development")
                                                   .OrderByDescending(e => e.Salary)
                                                   .FirstOrDefault();
        Console.WriteLine("\nEmployee(s) with the highest salary in Development:");
        Console.WriteLine(maxSalaryDevelopmentEmployee);

        // totalCost
        double totalCost = employees.Sum(e => e.Salary);
        Console.WriteLine("\nTotal cost of salaries in the company: {0}", totalCost);

        // costForDepartment
        string department = "Logistics";
        double departmentCost = employees.Where(e => e.Department == department).Sum(e => e.Salary);
        Console.WriteLine("\nTotal cost of salaries in {0} department: {1}", department, departmentCost);

        // IncreaseSalary
        Guid employeeIdToIncrease = employees.First().Id;
        var employeeToIncrease = employees.Find(e => e.Id == employeeIdToIncrease);
        employeeToIncrease.Salary *= 1.25;
        Console.WriteLine("\nSalary increased by 25% for employee with Id {0}:", employeeIdToIncrease);
        Console.WriteLine(employeeToIncrease);

        // IncreaseSalaryForTesting
        double increasePercentage = 0.10;
        employees.Where(e => e.Department == "Testing")
                 .ToList()
                 .ForEach(e => e.Salary *= (1 + increasePercentage));
        Console.WriteLine("\nSalaries increased by {0}% for employees in Testing department:", increasePercentage * 100);
        employees.Where(e => e.Department == "Testing").ForEach(Console.WriteLine);

        // Ordered HumanResources
        var orderedHREmployees = employees.Where(e => e.Department == "HumanResources")
                                         .OrderBy(e => e.Name)
                                         .ThenByDescending(e => e.Salary);
        Console.WriteLine("\nOrdered HumanResources employees (alphabetical and descending salary):");
        orderedHREmployees.ForEach(Console.WriteLine);

        // PoorestDevelopmentEmployee
        var poorestDevelopmentEmployee = employees.Where(e => e.Department == "Development")
                                                 .OrderBy(e => e.Salary)
                                                 .FirstOrDefault();
        Console.WriteLine("\nPoorest employee in Development department:");
        Console.WriteLine(poorestDevelopmentEmployee);

        // LogisticsWithRangeExists
        bool logisticsInRangeExists = employees.Any(e => e.Department == "Logistics" && e.Salary >= 5000 && e.Salary <= 6000);
        Console.WriteLine("\nLogistics employees with salary in the range [5000, 6000] exist: {0}", logisticsInRangeExists);
    }
}
