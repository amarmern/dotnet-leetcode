using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = 5;
            long factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            Console.WriteLine($"Factorial of {number} = {factorial}");
        }
    }
}

// using while loop

class Program
{
    static void Main()
    {
        int number = 5;
        long factorial = 1;

        while (number > 0)
        {
            factorial *= number;
            number--;
        }

        Console.WriteLine(factorial);
    }
}

// using recursive function

class Program
{
    static long Factorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        return n * Factorial(n - 1);
    }

    static void Main()
    {
        int number = 5;

        Console.WriteLine(Factorial(number));
    }
}