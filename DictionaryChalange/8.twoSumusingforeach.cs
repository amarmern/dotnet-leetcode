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
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            Dictionary<int, int> dict = new Dictionary<int, int>();


            foreach (var num in nums)
            {
                var diff = target - num;

                if (dict.ContainsKey(diff))
                {
                    Console.WriteLine($"{dict[diff]}, {num}");
                }
                else
                {
                    dict[num] = num;
                }
            }
        }

    }
}