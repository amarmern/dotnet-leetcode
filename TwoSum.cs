using System;
using System.Collections.Generic;

public class Program
{
    public static int[] TwoSum(int[] nums, int target)
    {
        // your code here
        Dictionary<int, int> dict = new Dictionary<int, int>();


        for (int i = 0; i < nums.Length; i++)
        {
            int secondNumber = target - nums[i];

            if (dict.ContainsKey(secondNumber))
            {
                Console.WriteLine($"{dict[secondNumber]}, {i}");
            }
            dict[nums[i]] = i;
        }


        return Array.Empty<int>();
    }

    public static void Main()
    {
        Console.WriteLine("Testing your code...");
        bool passing = true;

        var result1 = string.Join(",", TwoSum(new[] { 2, 7, 11, 15 }, 9));
        if (result1 != "0,1")
        {
            passing = false;
            Console.WriteLine("Tests failed, got \"[" + result1 + "]\" for input [2,7,11,15] target 9, expected \"[0,1]\"");
        }

        var result2 = string.Join(",", TwoSum(new[] { 3, 2, 4 }, 6));
        if (result2 != "1,2")
        {
            passing = false;
            Console.WriteLine("Tests failed, got \"[" + result2 + "]\" for input [3,2,4] target 6, expected \"[1,2]\"");
        }

        var result3 = string.Join(",", TwoSum(new[] { 3, 3 }, 6));
        if (result3 != "0,1")
        {
            passing = false;
            Console.WriteLine("Tests failed, got \"[" + result3 + "]\" for input [3,3] target 6, expected \"[0,1]\"");
        }

        if (passing)
            Console.WriteLine("All tests passed!");
    }
}
