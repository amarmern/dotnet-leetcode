using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Salary = 50000 },
                new Employee { Id = 2, Name = "David", Salary = 80000 },
                new Employee { Id = 3, Name = "Alice", Salary = 70000 },
                new Employee { Id = 4, Name = "Bob", Salary = 90000 },
                new Employee { Id = 4, Name = "Sam", Salary = 90000 }
            };
        //LinQ Query
        var res = employees
                    .Select(s => s.Salary) // when duplicate salary value
                    .Distinct() // when duplicate salary value
                    .OrderByDescending(e => e.Salary)
                    .Take(2);

        Console.WriteLine(res.Name);
        Console.WriteLine(res.Salary);

        //Heigest Salary
        var employee = employees
                        .OrderByDescending(e => e.Salary)
                        .First();

        //Lowest Salary
        var employee = employees
                     .OrderBy(e => e.Salary)
                     .First();

        //Skip two records
        var result = employees.Skip(2);

    }


}

