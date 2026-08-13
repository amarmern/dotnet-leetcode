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
        // page 3 , page size 10
        int Page = 3;
        int pageSize = 10;

        var result = employees
                    .Select(e => e)
                    .Skip((Page - 1) * pageSize)
                    .Take(pageSize);
    }


}

