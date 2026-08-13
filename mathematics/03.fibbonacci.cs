using System;

class Program
{
    static void Main()
    {
        int a = 0, b = 1;

        Console.Write(a + " " + b + " ");

        for (int i = 2; i < 10; i++)
        {
            int c = a + b;

            Console.Write(c + " ");

            a = b;
            b = c;
        }
    }
}

//using recursive

class Program
{
    static int Fibonacci(int n)
    {
        if (n == 0)
            return 0;

        if (n == 1)
            return 1;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    static void Main()
    {
        int n = 10;

        for (int i = 0; i < n; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }
    }
}