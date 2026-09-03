static async Task Main()
{
    A();
    B();
}

static async Task A()
{
    await Task.Delay(2000);
    Console.WriteLine("Method A Called");
}

static async Task B()
{
    Console.WriteLine("Method B Called");
}

//output: Method B Called

/*
How to fix it

Option 1 — Sequential
static async Task Main()
{
    await A();
    await B();
}

Output:

Method A Called
Method B Called

Because B waits for A.

Option 2 — Run both concurrently

If A and B are independent:

static async Task Main()
{
    Task taskA = A();
    Task taskB = B();

    await Task.WhenAll(taskA, taskB);
}

Output:

Method B Called
Method A Called

This is usually the answer I'd give in an interview if they ask:

"I want both methods to execute, but I don't want B to wait for A."

what if ConfigureAwait(false)?

await A().ConfigureAwait(false);
await B().ConfigureAwait(false);
///
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await A().ConfigureAwait(false);;
        await B().ConfigureAwait(false);;
    }

    static async Task A()
    {
        await Task.Delay(2000);

        Console.WriteLine("Method A Called");
    }

    static async Task B()
    {
        Console.WriteLine("Method B Called");
    }
}

Method A Called
Method B Called



