using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "programmmingg";
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (var ch in str)
            {
                dict[ch] = dict.ContainsKey(ch) ? dict[ch] + 1 : 1;
            }

            foreach (var item in dict)
            {
                if (item.Value > 1)
                    Console.WriteLine($"{item.Key} : {item.Value}");
            }


        }
    }
}