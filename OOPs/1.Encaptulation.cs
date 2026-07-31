/*Wrapping data (fields) and methods into a single class and controlling access to that 
data using access modifiers or properties.
The main goal is data hiding and protecting data from unauthorized access.
Example

*/

class Employee
{
    private int _salary;

    public int Salary
    {
        get { return _salary; }

        set
        {
            if (value > 0)
                _salary = value;
            else
                Console.WriteLine("Salary will not be negative");
        }
    }
}

class Program
{
    static void Main()
    {
        Employee employee = new Employee();
        employee.Salary = 50000;
        Console.WriteLine(employee.Salary);
    }
}

/*
Advantages of Encapsulation
Protects data
Prevents invalid values
Improves security
Makes code easier to maintain
Allows validation before updating data

Employee
-----------------------
- salary (private)
-----------------------
+ Salary (Property)
+ CalculateSalary()

Users interact with the property, not the private field directly.

Access modifiers in C# are keywords used to define the visibility and accessibility 
of classes, methods, and variables

public -> Accessible from anywhere inside or outside the project.
private -> Accessible only within the same class. This is the default modifier if 
none is specified.
protected -> Accessible within the same class and its child (derived) classes.
internal -> Accessible only within the same assembly (project file / compilation unit).
protected internal ->Accessible within the same assembly OR any child class in another 
assembly.
private protected -> Accessible within the same class AND child classes within the 
same assembly.

*/