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
            int[] numbers = { 1, 2, 3, 2, 4, 5, 1, 5, 5 };
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int item in numbers)
            {
                dict[item] = dict.ContainsKey(item) ? dict[item] + 1 : 1;
            }
            foreach (var item in dict)
            {
                if (item.Value > 1)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}