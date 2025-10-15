using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }
}

public interface ISalaryCalculator
{
    double CalculateSalary(Employee employee);
}

public class PermanentSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.2;
    }
}

public class ContractSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.1;
    }
}

public class InternSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 0.8;
    }
}

public class EmployeeSalaryService
{
    private readonly Dictionary<string, ISalaryCalculator> calculators = new Dictionary<string, ISalaryCalculator>();

    public void RegisterCalculator(string type, ISalaryCalculator calculator)
    {
        calculators[type] = calculator;
    }

    public double Calculate(string type, Employee employee)
    {
        if (!calculators.ContainsKey(type))
            throw new NotSupportedException("Employee type not supported");
        return calculators[type].CalculateSalary(employee);
    }
}

