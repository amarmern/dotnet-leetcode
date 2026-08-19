using System;

public delegate int OperationDelegate(int x, int y);
public class Program
{
    static int Add(int a, int b) => a + b;
    static int MultiPly(int a, int b) => a * b;

    public static void Main(string[] args)
    {
        OperationDelegate del = Add;
        Console.WriteLine($"Addition = {del(5, 3)}");
        del = MultiPly;
        Console.WriteLine($"MultiPly = {del(5, 3)}");
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