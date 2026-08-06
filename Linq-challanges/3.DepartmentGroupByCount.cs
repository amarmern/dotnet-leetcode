using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Department = "IT" },
            new Employee { Id = 2, Name = "David", Department = "HR" },
            new Employee { Id = 3, Name = "Alice", Department = "IT" },
            new Employee { Id = 4, Name = "Bob", Department = "Finance" },
            new Employee { Id = 5, Name = "Peter", Department = "HR" },
            new Employee { Id = 6, Name = "Tom", Department = "IT" }
        };

        /*
            Employee Count by Department
            IT : 3
            HR : 2
            Finance : 1
        */
        var result = employees.GroupBy(d => d.Department)
                    .Select(e => new
                    {
                        name = e.Key,
                        count = e.Count()
                    });

        foreach (var item in result)
        {
            Console.Write($"{item.name} {item.count}");
        }

        /*
             Find the Maximum employee by Deoartment wise
             Department: IT
             Employees: 3
        */
        var result = employees.GroupBy(d => d.Department)
                                .OrderByDescending(g => g.Count())
                                .First();
        Console.WriteLine(result.Key);
        Console.WriteLine(result.Count());

        /*
        Average Salary by department
        */

        var result = employees
            .GroupBy(e => e.Department)
            .Select(g => new
            {
                Department = g.Key,
                AverageSalary = g.Average(e => e.Salary)
            });
    }

}