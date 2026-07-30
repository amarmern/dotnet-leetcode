using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public String Name { get; set; }
    public String Department { get; set; }

}
class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
      {
        new Employee {Id= 1, Name="Amrendra", Department="IT"},
        new Employee {Id= 1, Name="Amrendra", Department="HR"},
        new Employee {Id= 1, Name="Amrendra", Department="IT"},
      };

        var res = employees.GroupBy(g => g.Department)
                                .Select(e => new
                                {
                                    Deprtment = e.Key,
                                    DepCount = e.Count()
                                });

        foreach (var item in res)
        {
            Console.WriteLine($"{item.Deprtment}=> {item.DepCount}");
        }
    }
}

