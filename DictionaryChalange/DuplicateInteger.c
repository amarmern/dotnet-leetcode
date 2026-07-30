using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] arr = {1,2,3,2,4,5,3};

        Dictionary<int,int> dict = new Dictionary<int,int>();

        foreach(int num in arr)
        {
            dict[num] = dict.ContainsKey(num) ? dict[num] + 1 : 1;
        }

        foreach(var item in dict)
        {
            if(item.Value > 1)
                Console.WriteLine($"{item.Key}-{item.Value}");
        }
    }
}