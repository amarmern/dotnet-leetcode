using System;
using System.Threading;
public delegate void TaskCompletedCallback(string message);

public class Worker
{
    public event TaskCompletedCallback TaskCompleted;
    public void StartWork(string taskName)
    {
        Thread thread = new Thread(() =>
        {
            Console.WriteLine($"{taskName} started");
            // Simulate long running work
            Thread.Sleep(6000);
            Console.WriteLine($"{taskName} completed");
            // Trigger callback event
            TaskCompleted?.Invoke(
                $"{taskName} result received"
            );
        });
        thread.Start();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Worker worker = new Worker();
        // Subscribe callback event
        worker.TaskCompleted += OnTaskCompleted;
        // Start two tasks (two threads)
        worker.StartWork("Payment Processing");
        worker.StartWork("Email Notification");
        Console.WriteLine("Main thread continues...");
        Console.ReadLine();
    }
    // Callback method
    static void OnTaskCompleted(string message)
    {
        Console.WriteLine(
            $"Callback received: {message}"
        );
    }
}

/*
Main thread continues...
Email Notification started
Payment Processing started
Email Notification completed
Payment Processing completed
Callback received: Payment Processing result received
Callback received: Email Notification result received
Time limit exceeded
*/