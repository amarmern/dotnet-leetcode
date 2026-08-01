S – Single Responsibility Principle (SRP)
A class should have only one reason to change.
Instead of creating one class that handles business logic, database operations, and email notifications, split these responsibilities into separate classes.

public class EmployeeService
{
public void CalculateSalary() { }
}

public class EmployeeRepository
{
public void Save(Employee employee) { }
}

public class EmailService
{
public void SendEmail(Employee employee) { }
}
✅ Easier to maintain, test, and modify.

🔹 O – Open/Closed Principle (OCP)
Software should be open for extension but closed for modification.
Instead of modifying existing code whenever a new payment method is added, create a new implementation.
public interface IPayment
{
void Pay();
}

public class CardPayment : IPayment
{
public void Pay() { }
}

public class UpiPayment : IPayment
{
public void Pay() { }
}
✅ Add new payment types without changing existing code.

🔹 L – Liskov Substitution Principle (LSP)
Derived classes should be replaceable with their base class without changing application behavior.
public abstract class Bird
{
public abstract void Move();
}

public class Sparrow : Bird
{
public override void Move()
{
Console.WriteLine("Flying");
}
}

public class Penguin : Bird
{
public override void Move()
{
Console.WriteLine("Swimming");
}
}
✅ Every derived class behaves correctly when used as its base type.

🔹 I – Interface Segregation Principle (ISP)
Don't force classes to implement methods they don't need.
public interface IWork
{
void Work();
}

public interface IEat
{
void Eat();
}

public class Robot : IWork
{
public void Work() { }
}
✅ Small, focused interfaces make code cleaner and easier to maintain.

🔹 D – Dependency Inversion Principle (DIP)
Depend on abstractions, not concrete implementations.
public interface ILogger
{
void Log(string message);
}

public class SqlLogger : ILogger
{
public void Log(string message) { }
}

public class UserService
{
private readonly ILogger \_logger;

    public UserService(ILogger logger)
    {
        _logger = logger;
    }

}
Register using Dependency Injection:
builder.Services.AddScoped<ILogger, SqlLogger>();
builder.Services.AddScoped<UserService>();
