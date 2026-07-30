using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string str = "programming";

        Dictionary<char, int> dict = new Dictionary<char, int>();

        foreach (char ch in str)
        {
            //dict[ch] = dict.ContainsKey(ch) ? dict[ch]++ : 1;
            if (dict.ContainsKey(ch))
                dict[ch]++;
            else
                dict[ch] = 1;
        }

        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}