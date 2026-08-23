using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 2, 4, 5, 3 };

        HashSet<int> unique = new HashSet<int>();

        foreach (int num in arr)
        {
            if (unique.Add(num))
            {
                Console.Write(num + " ");
            }
        }

    }
}