//sample Data
using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
}

class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
}

List<Employee> employees = new List<Employee>
{
    new Employee { Id = 1, Name = "John", DepartmentId = 1 },
    new Employee { Id = 2, Name = "David", DepartmentId = 2 },
    new Employee { Id = 3, Name = "Alice", DepartmentId = 1 },
    new Employee { Id = 4, Name = "Bob", DepartmentId = 4 }   // No matching department
};

List<Department> departments = new List<Department>
{
    new Department { Id = 1, DepartmentName = "IT" },
    new Department { Id = 2, DepartmentName = "HR" },
    new Department { Id = 3, DepartmentName = "Finance" }
};
var res = employees
.OrderByDescending(e => e.Salary)
.Skip(1)
.First();


//1.Inner Join(Query Syntax)
var result = from emp in employees
             join dept in departments
             on emp.DepartmentId equals dept.Id
             select new
             {
                 emp.Name,
                 dept.DepartmentName
             };

foreach (var item in result)
{
    Console.WriteLine($"{item.Name} - {item.DepartmentName}");
}

/* o/p:
John - IT
David - HR
Alice - IT
*/

//Left Join

var result =
    from emp in employees
    join dept in departments
        on emp.DepartmentId equals dept.Id
        into deptGroup
    from dept in deptGroup.DefaultIfEmpty()
    select new
    {
        emp.Name,
        Department = dept?.DepartmentName ?? "No Department"
    };

foreach (var item in result)
{
    Console.WriteLine($"{item.Name} - {item.Department}");
}

