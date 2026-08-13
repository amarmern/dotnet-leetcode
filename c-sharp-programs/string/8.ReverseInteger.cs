using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = 12345;
            int revese = 0;
            while (number > 0)
            {
                int didgit = number % 10;
                revese = revese * 10 + didgit;
                number = number / 10;
            }
            Console.WriteLine(revese);
        }
    }



}