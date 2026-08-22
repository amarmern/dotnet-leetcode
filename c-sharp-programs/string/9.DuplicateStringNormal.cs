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
			string str = "csharpcorner";
			string result = "";

			for (int i = 0; i < str.Length; i++)
			{
				bool isExist = false;
				for (int j = 0; j < result.Length; j++)
				{
					if (str[i] == result[j])
					{
						isExist = true;
						break;
					}
				}
				if (!isExist)
				{
					result += str[i];
				}
			}
			Console.WriteLine(result);
		}

	}
}