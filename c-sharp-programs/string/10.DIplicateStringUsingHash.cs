using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string str = "csharpcorner";
        HashSet<char> seen = new HashSet<char>();
        string result = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (seen.Add(str[i]))
            {
                result += str[i];
            }
        }
        Console.WriteLine(result);
    }
}