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
            string str = "madam";
            string result = "";

            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }
            if (result == str)
            {
                Console.WriteLine("Palindrome");
            }
            else
            {
                Console.WriteLine("Not a Palindrome");
            }
        }
    }
}