using System;

class Program
{
    static void Main()
    {
        string str = "programming";

        for (int i = 0; i < str.Length; i++)
        {
            bool alreadyCounted = false;

            for (int k = 0; k < i; k++)
            {
                if (str[i] == str[k])
                {
                    alreadyCounted = true;
                    break;
                }
            }

            if (alreadyCounted)
                continue;

            int count = 0;

            for (int j = 0; j < str.Length; j++)
            {
                if (str[i] == str[j])
                    count++;
            }

            if (count > 1)
            {
                Console.WriteLine(str[i] + " : " + count);
            }
        }
    }
}
