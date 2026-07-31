using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "Hello";
            char[] chars = str.ToCharArray();
            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                char temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;
                left++;
                right--;
            }
            Console.WriteLine(new string(chars));
        }
    }
}