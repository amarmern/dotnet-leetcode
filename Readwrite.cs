using System;

class ReadWrite
{
    static void Main()
    {
        Console.WriteLine("Please Enter Name");
        string Title = "Mr";
        string userName = Console.ReadLine();
        //Console.WriteLine("Hello" + " "+userName);
        Console.WriteLine("Hello {0} {1}" ,  Title,userName);
    }
}