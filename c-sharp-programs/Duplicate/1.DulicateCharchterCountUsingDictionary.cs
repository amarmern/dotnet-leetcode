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
            string str = "programmmingg";


            for (int i = 0; i < str.Length; i++)
            {
                bool isVisited = false;
                for (int k = 0; k < i; k++)
                {
                    if (str[i] == str[k])
                    {
                        isVisited = true;
                        break;
                    }

                }
                if (isVisited)
                    continue;
                int count = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    Console.WriteLine($"{str[i]} : {count}");
                }
            }
        }
    }
}

///r : 2
//g : 2
//m : 2