/*
Inheritance allows one class to reuse properties and methods of another class.
 Key Rules of C# InheritanceSingle Inheritance Only:
  A class can only inherit from one direct parent class. 
  It cannot inherit from multiple classes simultaneously.
  The : Syntax: The colon operator (:) is used to establish the inheritance relationship.
  Constructors are Not Inherited: Child classes do not inherit parent constructors, 
  but they must call them using the base keyword. 
*/


using System;

namespace InheritanceDemo
{
    // 1. Base Class (Parent)
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        // Constructor
        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        // Virtual method allows child classes to override its behavior
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Employee: {Name}, Salary: {Salary}");
        }
    }

    // 2. Derived Class (Child)
    class Manager : Employee
    {
        public string Department { get; set; }

        // Child constructor passing data up to the parent using 'base'
        public Manager(string name, int salary, string department) : base(name, salary)
        {
            Department = department;
        }

        // Overriding the parent method to inject custom behavior
        public override void DisplayInfo()
        {
            Console.WriteLine($"Manager: {Name}, Dept: {Department}, Salary: {Salary}");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Employee emp = new Employee("Alice", 50000);
            Manager mgr = new Manager("Bob", 85000, "IT Engineering");

            emp.DisplayInfo(); // Outputs standard employee layout
            mgr.DisplayInfo(); // Outputs specialized manager layout
        }
    }
}

/*
Core Keywords Reference
virtual: Placed on a method in the base class to declare that child classes are allowed
 to change its behavior.

override: Used in the child class to rewrite a method marked as virtual or abstract 
in the parent class.

base: Used to access members, methods, or constructors of the parent class from inside
the child class.

sealed: Placed on a class to completely prevent any other classes from inheriting from it.

*/