using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string str = "Hello World";
        Dictionary<char, int> dict = new Dictionary<char, int>();

        foreach (char ch in str.ToLower())
        {
            if ("aeiou".Contains(ch))
            {
                dict[ch] = dict.ContainsKey(ch) ? dict[ch] + 1 : 1;
            }
        }
        foreach (var item in dict)
            Console.WriteLine($"{item.Key}:{item.Value}");
    }
}