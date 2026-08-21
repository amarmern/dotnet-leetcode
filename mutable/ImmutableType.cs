using System;

namespace HelloWorld
{
    // Fixed: 'sealed class' order and added 'public'
    public sealed class Person
    {
        public string Name { get; }
        public int Age { get; }

        // Fixed: Added 'int' data type to the 'age' parameter
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Used the constructor to pass values because Name and Age are read-only
            Person p1 = new Person("Amrendra", 30);

            // Removed 'p1.Name = "Bob"' because these properties cannot be changed after creation.

            Console.WriteLine($"Name: {p1.Name}, Age: {p1.Age}");
        }
    }
}