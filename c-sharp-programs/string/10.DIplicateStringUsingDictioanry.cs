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
            string str = "csharpcorner";
            Dictionary<char, bool> dict = new Dictionary<char, bool>();
            string result = "";
            foreach (var ch in str)
            {
                if (!dict.ContainsKey(ch))
                {
                    dict[ch] = true;
                    result += ch;
                }
            }
            Console.WriteLine(result);
        }

    }
}