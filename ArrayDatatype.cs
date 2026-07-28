using System;

class ArrayDatatype
{
    static void Main()
    {
        int [] evenNumber = new int[3];
        evenNumber[0] =1;
        evenNumber[1] =2;
        evenNumber[2] =3;
        //evenNumber[3] =4;
        Console.WriteLine(evenNumber); //System.IndexOutOfRangeException
        for(int i =0; i < evenNumber.Length; i++)
        {
             Console.WriteLine(evenNumber[i]);
        }
    }
}