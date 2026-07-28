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