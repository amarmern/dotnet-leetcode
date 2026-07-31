/*
Same method behaves differently for different objects.

There are two types.
Compile-time Polymorphism

(Method Overloading)

*/
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

//Runtime Polymorphism

//(Method Overriding)

public class Animal
{
    public virtual void Speak()
    {
        Console.WriteLine("Animal");
    }
}

public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Dog");
    }
}
//usage
class Program
{
    static void Main()
    {
        Animal animal = new Dog();

        animal.Speak();
    }
}
