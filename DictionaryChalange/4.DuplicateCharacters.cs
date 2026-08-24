using System;
using System.Collections.Generic;

class DuplicateCharacters
{
    static void Main()
    {
        string str = "programming";

        Dictionary<char, int> dict = new Dictionary<char, int>();

        foreach (char ch in str)
        {
            dict[ch] = dict.ContainsKey(ch) ? dict[ch] + 1 : 1;
        }

        foreach (var item in dict)
        {
            if (item.Value > 1)
                Console.WriteLine(item.Key);
        }
    }
}
//o/p:
// r
// g
// m