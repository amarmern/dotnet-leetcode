Overdriven Concepts in c#

- Creating the reference of parent class and object of parent class. Then ,
  parent class method only it will call, even virtual and override also.

          using System;
          using System.Collections.Generic;
          using System.Linq;
          using System.Text.RegularExpressions;

          namespace HelloWorld
          {
          public class Program
          {
          class Animal
          {
          public virtual void Sound(){
          Console.WriteLine("Animal makes a sound");
          }
          }

          class Dog : Animal
          {
              public override void Sound()
              {
                  Console.WriteLine("Dog is Barking");
              }
          }

          public static void Main(string[] args)
          {
              Animal animal = new Animal();
              animal.Sound();

          }
          }

      }

// o/p: Animal makes a sound

- When creating the reference of parent and object of child class after override ,child class method will be call. If not virtual and override then parent class methods will call.

        public class Program
        {
        class Animal
        {
        public virtual void Sound(){
        Console.WriteLine("Animal makes a sound");
        }
        }

        class Dog : Animal
        {
            public override void Sound()
            {
                Console.WriteLine("Dog is Barking");
            }
        }

        public static void Main(string[] args)
        {
            Animal animal = new Dog();
            animal.Sound();

        }

  }

o/p: Dog is Barking

- When, child class reference will associate with child class object then child class method only call.

        public class Program
        {
        class Animal
        {
        public virtual void Sound(){
        Console.WriteLine("Animal makes a sound");
        }
        }

        class Dog : Animal
        {
            public override void Sound()
            {
                Console.WriteLine("Dog is Barking");
            }
        }

        public static void Main(string[] args)
        {
            Dog animal = new Dog();
            animal.Sound();

        }

  }

• Note when, we create the child class reference and parent class of object then it will be the error.

- Method Hiding
  Hiding the Parent methods to override in child. Using the New Keword.

          public class Program
          {
          class Animal
          {
          public virtual void Sound(){
          Console.WriteLine("Animal makes a sound");
          }
          }

          class Dog : Animal
          {
              public new void Sound()
              {
                  Console.WriteLine("Dog is Barking");
              }
          }

          public static void Main(string[] args)
          {
              Animal animal = new Dog();
              animal.Sound();

          }
      }

// Animal makes a sound

 
What is delegate?
Delegate in c# is a type safe function pointer.
I allows you to store a reference of a method and invoke that method later.
Simple Definition:
A delegate is an object that holds a reference to one or more methods with the same signature.
Why we need a delegate normally, we call the method directly?

With a delegate , you can pass the method as a parameter or a store in a variable.
This is useful for
Callback
Event
LINQ
Asynchronous Programming
Real-Time Example
Suppose you an order placed:
You want to send
Email
SMS
Update Inventory

Order Placed
|
Delegate
|

---

| | |
Email SMS Inventory

        namespace HelloWorld
        {
        public delegate void Notify();
        public class Program
        {
        static void SMS()
        {
        Console.WriteLine("SMS Sent");
        }

        static void Email()
        {
            Console.WriteLine("Email has Sent");
        }

        public static void Main(string[] args)
        {
            Notify notify = SMS;
            notify += Email;
            notify();

        }
    }

}

Advantages
• Type-safe
• Supports callbacks
• Supports multicast
• Loose coupling
• Used in event-driven programming

Built-in Delegates

1. Action
   Used when no return value
   Action<string> greet = name =>
   {
   Console.WriteLine($"Hello {name}");
   };

greet("Amrendra");

2. Func
   Used when a value is returned.
   Func<int, int, int> add = (a, b) => a + b;

Console.WriteLine(add(10, 20));

3. Predicate
   Used for methods that return bool.
   Predicate<int> isEven = x => x % 2 == 0;

Console.WriteLine(isEven(10));

What is CLR?
CLR = Common Language Runtime.
It manages:
• Memory
• Garbage Collection
• Exception handling
• Threading
• Security
Flow

C# Code
↓
IL (Intermediate Language)
↓
CLR + JIT Compiler
↓
Machine Code

What is JIT Compiler?
JIT converts IL code into machine code during runtime.
Type Meaning
Normal JIT Compiles method when called
Econo JIT Removes unused code
Pre-JIT Entire code compiled before execution

What is Garbage Collection?
Automatic memory cleanup.
Generations
Generation Purpose
Gen 0 Temporary objects
Gen 1 Medium lifetime
Gen 2 Long-lived objec
“How to improve GC performance?”
Answer
• Avoid unnecessary object creation
• Use pooling
• Dispose objects correctly
• Use structs when appropriate
Boxing and Unboxing
Boxing
Value type → object
int x = 10;
object obj = x;
Unboxing
object → value type
int y = (int)obj;
Interview Point
Avoid excessive boxing because of performance cost.

String vs StringBuilder
String StringBuilder
Immutable Mutable
Slow for modifications Faster
Ex:
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
API Gateway
Single entry point for microservices.
Tools
• Ocelot
• YARP
• Kong

Distributed Transactions
Hard in microservices.
Solution
Saga Pattern.

Saga Pattern
Choreography
Services communicate through events.
Orchestration
Central coordinator controls flow.

stack vs heap memory in c#
In C#, the stack manages short-lived data like method parameters and local variables, while the heap stores long-lived data, dynamically allocated objects, and reference types.

Memory architecture in the .NET runtime divides allocation into these two separate structures to balance execution speed with data flexibility.

Stack Memoryand Heap Memory

task vs thread vs threadpool in c#
• Thread: A low-level operating system (OS) execution unit. When you create a manual new Thread(), you spin up a dedicated worker with its own memory stack, which carries heavy creation and context-switching overhead.

• ThreadPool: A managed collection of background threads maintained by the .NET runtime. Instead of constantly spawning and destroying threads, the system borrows an idle thread from this pool to execute work and returns it when done.

• Task: A high-level abstraction belonging to the Task Parallel Library (TPL). It represents an asynchronous operation ("a promise of future completion") and automatically leverages the ThreadPool under the hood to run its workloads. =

---

Direct Comparison
Feature Thread (System.Threading) ThreadPool (ThreadPool) Task (System.Threading.Tasks)
Abstraction Level Low-level OS wrapper Managed thread container High-level job wrapper
Creation Cost Very High (Allocates ~1MB stack) Medium (Pre-allocated by CLR) Very Low (Lightweight object)
Lifecycle Control Full manual control (Start, Abort) Managed by the .NET CLR Managed via the TaskScheduler
Return Values No direct way to return values No direct way to return values Directly returns data via Task<T>
Async/Await Support No No Yes (Native foundation)
Chaining / Pipeline No No Yes (via ContinueWith or await)
Cancellation Difficult (manual flags) Difficult Native (via CancellationToken)
https://www.google.com/search?q=task+vs+thread+vs+threadpool+in+c%23&rlz=1C1JJTC_enIN989IN989&oq=task+vs+thread+vs+threadpool+in+c%23&gs_lcrp=EgZjaHJvbWUyBggAEEUYOTIHCAEQIRigAdIBCTEzODE0ajBqN6gCALACAA&sourceid=chrome&source=chrome.ob&ie=UTF-8

how will do pagination in Linq
var data = await \_context.Products.OrderBy(p => p.Id) .Skip((validParams.PageNumber - 1) \* validParams.PageSize) .Take(validParams.PageSize) .ToListAsync();
[HttpGet]
public IActionResult Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "")
{
var query = \_articles.AsQueryable();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(article => article.Title.Contains(filter) || article.Category.Contains(filter));
        }

        var totalCount = query.Count();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        var result = new
        {
            TotalCount = totalCount,
            TotalPages = totalPages,
            CurrentPage = page,
            PageSize = pageSize,
            Articles = query.ToList()
        };

        return Ok(result);
    }

- Interface in C#

## What is an Interface?

An **interface** in C# is a contract that defines **what a class must do**, but not **how it should do it**.

- It contains method, property, event, or indexer declarations.
- It cannot contain instance field implementations.
- Any class implementing an interface **must provide the implementation** for all its members.

---

# Syntax

```csharp
public interface IEmployee
{
    void Work();
}
```

Implementing the interface:

```csharp
public class Developer : IEmployee
{
    public void Work()
    {
        Console.WriteLine("Developer is writing code.");
    }
}

class Program
{
    static void Main()
    {
        IEmployee employee = new Developer();
        employee.Work();
    }
}
```

### Output

```
Developer is writing code.
```

---

# Why Do We Use Interfaces?

Interfaces help to:

- Achieve abstraction
- Support loose coupling
- Enable dependency injection (DI)
- Make applications easier to test
- Allow multiple classes to follow the same contract

---

# Real-Time Example

## Payment Gateway

```csharp
public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}
```

### Credit Card

```csharp
public class CreditCardPayment : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Credit Card Payment: {amount}");
    }
}
```

### UPI

```csharp
public class UpiPayment : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"UPI Payment: {amount}");
    }
}
```

### Client Code

```csharp
class Program
{
    static void Main()
    {
        IPaymentGateway payment = new CreditCardPayment();
        payment.ProcessPayment(1000);

        payment = new UpiPayment();
        payment.ProcessPayment(500);
    }
}
```

### Output

```
Credit Card Payment: 1000
UPI Payment: 500
```

---

# Multiple Interface Implementation

A class can implement multiple interfaces.

```csharp
public interface IFly
{
    void Fly();
}

public interface ISwim
{
    void Swim();
}

public class Duck : IFly, ISwim
{
    public void Fly()
    {
        Console.WriteLine("Duck is flying");
    }

    public void Swim()
    {
        Console.WriteLine("Duck is swimming");
    }
}
```

---

# Interface with Dependency Injection (ASP.NET Core)

```csharp
public interface IProductService
{
    List<string> GetProducts();
}

public class ProductService : IProductService
{
    public List<string> GetProducts()
    {
        return new List<string> { "Laptop", "Mobile" };
    }
}
```

Register the service:

```csharp
builder.Services.AddScoped<IProductService, ProductService>();
```

Inject it into a controller:

```csharp
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_productService.GetProducts());
    }
}
```

This is one of the most common real-world uses of interfaces in ASP.NET Core.

---

# Interface vs Abstract Class

| Interface                                  | Abstract Class                              |
| ------------------------------------------ | ------------------------------------------- |
| Defines a contract                         | Can define both contract and implementation |
| Supports multiple interface implementation | A class can inherit only one abstract class |
| No instance fields                         | Can contain fields                          |
| Commonly used with Dependency Injection    | Used when sharing common implementation     |

---

# Common Interview Questions

### 1. Can an interface have a constructor?

**No.**

Interfaces cannot be instantiated.

---

### 2. Can an interface have fields?

**No.**

Interfaces cannot have instance fields.

---

### 3. Can a class implement multiple interfaces?

**Yes.**

```csharp
class Employee : IPrintable, ISavable
{
}
```

---

### 4. Can an interface inherit another interface?

**Yes.**

```csharp
public interface IA
{
    void MethodA();
}

public interface IB : IA
{
    void MethodB();
}
```

---

### 5. Why do we program against interfaces?

Because it reduces coupling. The calling code depends on the contract instead of a specific implementation, making it easier to replace implementations, unit test, and maintain the application.

---

### 6. What is Interface Segregation Principle (ISP)?

One of the SOLID principles:

> Clients should not be forced to depend on methods they do not use.

Instead of one large interface:

```csharp
interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}
```

Prefer smaller, focused interfaces:

```csharp
interface IWork
{
    void Work();
}

interface IEat
{
    void Eat();
}
```

---

# Real-Time Examples

Interfaces are widely used for:

- Repository Pattern (`IRepository`)
- Service Layer (`IOrderService`)
- Logging (`ILogger`)
- Payment Gateways (`IPaymentGateway`)
- Notification Services (`IEmailService`, `ISmsService`)
- Authentication Providers
- Dependency Injection in ASP.NET Core

---

# Interview Answer (2 Minutes)

> An interface in C# defines a contract that implementing classes must follow. It specifies what operations are available without defining how they are implemented. Interfaces promote abstraction, loose coupling, testability, and flexibility. They are heavily used in ASP.NET Core for dependency injection, repository patterns, service layers, logging, and external integrations. A class can implement multiple interfaces, making interfaces ideal for defining capabilities without enforcing inheritance.
