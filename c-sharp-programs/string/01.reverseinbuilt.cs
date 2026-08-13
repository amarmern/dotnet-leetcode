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
            string str = "hello";
            char[] ch = str.ToCharArray();
            Array.Reverse(ch);
            Console.WriteLine(new string(ch));
        }
    }
}