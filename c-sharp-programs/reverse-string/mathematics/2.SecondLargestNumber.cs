using System;

class Program
{
    static int SecondLargest(int[] arr)
    {
        if (arr.Length < 2)
            throw new Exception("Array should contain at least two elements.");

        int largest = int.MinValue;
        int secondLargest = int.MinValue;

        foreach (int num in arr)
        {
            if (num > largest)
            {
                secondLargest = largest;
                largest = num;
            }
            else if (num > secondLargest && num != largest)
            {
                secondLargest = num;
            }
        }

        return secondLargest;
    }

    static void Main()
    {
        int[] arr = { 3, 10, 7, 5, 12, 11, 25, 2 };

        Console.WriteLine("Second Largest = " + SecondLargest(arr));
    }
}

// using Linq



class Program
{
    static void Main()
    {
        int[] arr = { 3, 10, 7, 5, 12, 11, 25, 2 };

        int secondLargest = arr.Distinct()
                               .OrderByDescending(x => x)
                               .Skip(1)
                               .First();

        Console.WriteLine(secondLargest);
    }
}