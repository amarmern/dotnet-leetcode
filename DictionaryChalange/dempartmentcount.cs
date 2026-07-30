using System;
using System.Collections.Generic;

class Employee
{
    public string Name;
    public string Department;
}

class Program
{
    static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee{Name="A",Department="IT"},
            new Employee{Name="B",Department="HR"},
            new Employee{Name="C",Department="IT"}
        };

        Dictionary<string, int> dict = new Dictionary<string, int>();

        foreach (var emp in employees)
        {
            dict[emp.Department] =
                dict.ContainsKey(emp.Department)
                ? dict[emp.Department] + 1
                : 1;
        }

        foreach (var item in dict)
            Console.WriteLine($"{item.Key}:{item.Value}");
    }
}