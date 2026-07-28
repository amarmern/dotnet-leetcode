using System;
public delegate void MyDelegate();
class Program
{
    static void Hello()
    {
        Console.WriteLine("Hello World");
    }

    static void Main()
    {
        MyDelegate del = Hello;
        del();      // Invoke delegate
    }
}