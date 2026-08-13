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
class Program
{
    static void Main()
    {
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
        //Returns all employees, even if they don't have a matching department.
        /*
            Left Join (Query Syntax)
        */
        var result = from emp in employees
                     join dept in departments
                     on emp.DepartmentId equals dep.Id into deptGroup
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

        //Left Join (Method Syntax)
        var result = employees
                    .GroupJoin(
                        departments,
                        emp => emp.DepartmentId,
                        dept => dept.Id,
                        (emp, deptGroup) => new { emp, deptGroup })
                        .SelectMany(
                             x => x.deptGroup.DefaultIfEmpty(),
                            (x, dept) => new
                            {
                                x.emp.Name,
                                Department = dept?.DepartmentName ?? "No Department"
                            });

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} - {item.Department}");
        }

    }

}


