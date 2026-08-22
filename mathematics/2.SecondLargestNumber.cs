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
            int[] arr = { 3, 10, 7, 5, 12, 11, 25, 2 };
            int largest = 0;
            int secondLargest = 0;

            foreach (int num in arr)
            {
                if (num > largest)
                {
                    secondLargest = largest;
                    largest = num;
                }
                else if (num > secondLargest && num < largest)
                {
                    secondLargest = num;
                }

            }
            Console.WriteLine(secondLargest);
        }

    }
}