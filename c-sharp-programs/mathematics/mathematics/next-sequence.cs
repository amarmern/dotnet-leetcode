using System;

class Program
{
    static void Main()
    {
        int number = 0;

        for (int i = 1; i <= 6; i++)
        {
            number = number * 10 + 2;
            Console.Write(number + " ");
        }
    }
}