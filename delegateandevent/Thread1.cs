using System;
using System.Threading;

class Program
{
     static void Main()
    {
        Thread thread1 = new Thread(printNumber);
        Thread thread2 = new Thread(printLetter);
		thread1.Start();
        thread2.Start();
    }
    static void printNumber(){
		for(int i =0; i< 5; i++){
			Console.WriteLine(i);
		}
	}
	static void printLetter(){
		for(char ch = 'A'; ch <='E' ; ch++)
		{
			Console.WriteLine(ch);
		}
	}

}