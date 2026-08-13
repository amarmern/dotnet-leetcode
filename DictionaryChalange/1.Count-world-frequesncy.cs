using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string sentence = "this is csharp";
        Dictionary<string, int> dict = new Dictionary<string, int>();

        foreach (var word in sentence.Split(' '))
        {
            dict[word] = dict.ContainsKey(word) ? dict[word] + 1 : 1;
        }

        foreach (var item in dict)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}