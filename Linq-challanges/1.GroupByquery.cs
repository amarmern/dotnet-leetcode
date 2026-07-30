using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linqchallanges
{
    public class GroupByquery
    {
        public static void Main(string[] args)
        {
            List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve", "Frank" };

            var groupedNames = names.GroupBy(name => name.Length);

            foreach (var group in groupedNames)
            {
                Console.WriteLine($"Names with length {group.Key}:");
                foreach (var name in group)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
            }
        }
    }
}