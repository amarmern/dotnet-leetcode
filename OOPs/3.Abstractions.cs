
/*
Abstraction
Definition

Abstraction means showing only the necessary details while hiding implementation 
details.

*/
using System;
using System.Security.Authentication;

abstract class Employee
{
    public void Display()
    {
        Console.WriteLine("Employee Details");
    }

    public abstract void CalculateSalary();
}

class PermanentEmployee : Employee
{
    public override void CalculateSalary()
    {
        Console.WriteLine("Salary: 50000");
    }
}

class Program
{
    static void Main()
    {
        PermanentEmployee emp = new PermanentEmployee();

        emp.Display();
        emp.CalculateSalary();
    }
}

/*
| Interface                                         | Abstract Class                            |
| ------------------------------------------------- | ----------------------------------------- |
| Defines a contract                                | Provides partial implementation           |
| No constructors                                   | Can have constructors                     |
| Multiple interfaces allowed                       | Only one abstract class can be inherited  |
| Best for unrelated classes                        | Best for closely related classes          |
| All members are public by default (traditionally) | Can have private/protected/public members |

*/

//EX:
public abstract class Payment
{
    public abstract void Pay(decimal amount);
}

// Implemenation

public class CreditCard : Payment
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine("Paid using Credit Card");
    }
}

// ussge
class Program
{
    static void Main()
    {
        Payment payment = new CreditCard();
        payment.Pay(1000);

    }
}


/*
When should you choose an Abstract Class over an Interface?

I choose an Abstract Class when multiple closely related classes share common state and behavior, and I want to provide a common base implementation while still forcing derived classes to implement specific functionality.

I choose an Interface when I only need to define a contract that can be implemented by unrelated classes or when a class needs to support multiple behaviors.

Abstract classes can have constructors.
Interfaces cannot have constructors.
public abstract class Person
{
    protected Person(string name)
    {
        Name = name;
    }

    public string Name { get; }
}

Comprision
| Requirement            | Abstract Class        | Interface                                                            |
| ---------------------- | --------------------- | -------------------------------------------------------------------- |
| Shared code            | ✅ Yes                 | ❌ No (except limited default interface methods in newer C# versions) |
| Fields/State           | ✅ Yes                 | ❌ No instance state                                                  |
| Constructors           | ✅ Yes                 | ❌ No                                                                 |
| Protected members      | ✅ Yes                 | ❌ No                                                                 |
| Multiple inheritance   | ❌ One base class only | ✅ Multiple interfaces                                                |
| Defines contract       | ✅ Yes                 | ✅ Yes                                                                |
| Partial implementation | ✅ Yes                 | Limited (default methods)                                            |

When would you choose an Abstract Class over an Interface?
You can answer:

"I choose an abstract class when the derived classes are closely related and need to
share common state or implementation. It allows me to define shared fields, 
constructors, protected methods, and reusable logic while still enforcing derived 
classes to implement specific behavior through abstract methods. If I only need to
define a capability or contract across unrelated classes, or I need multiple 
inheritance of behavior, I prefer an interface."

*/