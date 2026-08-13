using System;

public delegate int Calculate(int a, int b);

class Program
{
    static int Add(int x, int y)
    {
        return x + y;
    }

    static void Main()
    {
        Calculate calc = Add;

        int result = calc(10, 20);

        Console.WriteLine(result);
    }
}

// Multi Cast delegate


public delegate void Notify();

class Program
{
    static void SMS()
    {
        Console.WriteLine("SMS Sent");
    }

    static void Email()
    {
        Console.WriteLine("Email Sent");
    }

    static void Main()
    {
        Notify notify = SMS;
        notify += Email;

        notify();
    }
}