//Implicit Conversion Example
using System;
class Datatypeconversion
{
    public static void Main()
    {
        int i = 100;

        // float is bigger datatype than int. So, no loss of
        // data and exceptions. Hence implicit conversion
        float f = i;

        Console.WriteLine(f);
    }
}

//Explicit Conversion Example
//using System;
class Program
{
    public static void Main()
    {
        float f = 100.25F;

        // Cannot implicitly convert float to int.
        // Fractional part will be lost. Float is a
        // bigger datatype than int, so there is
        // also a possiblity of overflow exception
        // int i = f;

        // Use explicit conversion using cast () operator
        int i = (int)f;

        // OR use Convert class
        // int i = Convert.ToInt32(f);

        Console.WriteLine(i);
    }
}