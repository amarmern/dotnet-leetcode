using System;
using System.Threading.Tasks;
public delegate void TaskCompleted(string message);
class Processor
{
    public event TaskCompleted Completed;
    public async Task ProcessAsync(string name)
    {
        await Task.Run(async () =>
        {
            Console.WriteLine($"{name} started");
            await Task.Delay(3000);
            Console.WriteLine($"{name} completed");
        });
        Completed?.Invoke($"{name} finished");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Run().GetAwaiter().GetResult();
    }
    static async Task Run()
    {
        Processor processor = new Processor();
        processor.Completed += message =>
        {
            Console.WriteLine($"Callback received: {message}");
        };
        Task t1 = processor.ProcessAsync("Payment");
        Task t2 = processor.ProcessAsync("Notification");
        await Task.WhenAll(t1, t2);
        Console.WriteLine("All tasks completed");
        Console.ReadLine();
    }
}

/*
Payment started
Notification started
Payment completed
Callback received: Payment finished
Notification completed
Callback received: Notification finished
All tasks completed
Time limit exceeded
*/