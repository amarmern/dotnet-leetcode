//ref

//The variable must be initialized before passing.

void Increment(ref int x)
{
    x++;
}

int number = 5;

Increment(ref number);

Console.WriteLine(number);

//6

//out
//The caller doesn't need to initialize the variable, but the called method must 
// assign it.

void GetValues(out int x)
{
    x = 100;
}

int number;

GetValues(out number);

Console.WriteLine(number);
//100

//in
//Passes by reference but is read-only.

void Print(in int x)
{
    Console.WriteLine(x);

    // x++; // Compile-time error
}

| Keyword | Must initialize before call? | Can modify inside method? |
| ------- | ---------------------------- | ------------------------- |
| ref     | Yes                          | Yes                       |
| out     | No                           | Yes (must assign)         |
| in      | Yes                          | No                        |


//const vs readonly vs static readonly

// const
// Compile-time constant.
// Value must be known at compile time.
// Implicitly static.

public const double PI = 3.14159;
// Note: You cannot assign it in a constructor.


// readonly
// Can be assigned:
// At declaration, or
// In the constructor.

public class Employee
{
    public readonly int Id;
    public Employee(int id)
    {
        Id = id;
    }
}


//static readonly
//Shared by all instances and assigned only once.
public class Config
{
    public static readonly string ConnectionString;

    static Config()
    {
        ConnectionString = "Server=localhost;";
    }
}


//comparsion

| Feature | const             | readonly                      | static readonly         |
| ---------------------------   | -------------     | ----------------------        | ----------------------- |
| Compile - time constant | ✅                   | ❌                      | ❌                       |
| Assigned in constructor | ❌                | ✅                        | Only static constructor |
| Per object value              | ❌                | ✅                        | ❌                       |
| Shared across all instances   | ✅                | ❌                        | ✅                       |
| Best use                      | PI, MaxLength     | Object-specific values        | Global configuration    |


