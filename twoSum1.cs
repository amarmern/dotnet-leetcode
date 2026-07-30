using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];

            if (dict.ContainsKey(diff))
            {
                Console.WriteLine($"{dict[diff]}, {i}");
                return;
            }

            dict[nums[i]] = i;
        }
    }
}