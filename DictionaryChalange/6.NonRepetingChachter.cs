using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryChalange
{
    public class NonRepetingCharacter
    {
        public static void Main(string[] args)
        {
            string str = "programming";

            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var ch in str)
            {
                dict[ch] = dict.ContainsKey(ch) ? dict[ch] + 1 : 1;

            }

            foreach (char ch in str)
            {
                if (dict[ch] == 1)
                {
                    Console.WriteLine(ch);
                    break;
                }
            }

        }
    }
}