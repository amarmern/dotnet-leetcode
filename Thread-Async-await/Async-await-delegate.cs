/*

1. ConfigureAwait(false) ?

ConfigureAwait(false) tells the awaiter:

“After the awaited operation completes, I don't need to resume on the original synchronization context.”

It is commonly used in library code to avoid unnecessary context switching.

public async Task<string> GetDataAsync()
{
    var data = await GetFromDatabaseAsync()
                    .ConfigureAwait(false);

    return data;
}

a. Does ConfigureAwait(false) make the operation faster?

Not necessarily.

It can avoid context capture/restoration, but the main purpose is context behavior, not magically making async operations faster.

2. Task.WhenAll vs Task.WhenAny??

WhenAll: waits until all tasks complete.

WhenAny:  It returns when the first task completes.

a. Does WhenAny cancel the remaining tasks??
Ans: No.

You need cancellation explicitly.

3. Task.Run

Task.Run is a simpler API designed for common thread-pool work.
Important interview point

Don't use Task.Run just to make naturally asynchronous I/O asynchronous.
Bad:

await Task.Run(() => database.GetDataAsync());

If the database API is already asynchronous:

await database.GetDataAsync();

is preferred.

4. Task vs Thread
Thread :
Represents an actual OS thread.

var thread = new Thread(() =>
{
    DoWork();
});

thread.Start();

Task :
Represents an asynchronous operation/work item.
var task = Task.Run(() => DoWork());

await task;

Note: A Task doesn't necessarily mean a new thread.

** This is a very important interview statement.

For I/O:

await httpClient.GetAsync(url);

there doesn't need to be a thread sitting blocked while the network operation is happening.

5. async Task vs async void

Why? async Task:

await ProcessAsync();

allows:

awaiting
exception propagation
composition
testing

async void cannot be awaited.

Main valid use case

Event handlers:

private async void Button_Click(...)
{
    await ProcessAsync();
}


6. .Result / .Wait() and Deadlocks

Code
public string GetData()
{
    return GetDataAsync().Result;
}

Potential problem:

Blocking async code.

Classic ASP.NET / UI applications can produce deadlocks because the async continuation may need the synchronization context that the blocked thread is holding.

Prefer:

public async Task<string> GetDataAsync()
{
    return await GetDataFromServerAsync();
}

and:

var result = await GetDataAsync();
Interview one-liner

“Don't synchronously block on asynchronous code using .Result or .Wait(); propagate async all the way using await.”

7. CancellationToken??
Question

How do you cancel an async operation?
CancellationToken doesn't forcibly kill a thread.

It is generally cooperative cancellation.

8. Exception Handling with Task.WhenAll ???

onsider:

var tasks = new[]
{
    Task1Async(),
    Task2Async(),
    Task3Async()
};

try
{
    await Task.WhenAll(tasks);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

Question: What happens if multiple tasks fail?

Ans: 
WhenAll completes as faulted if one or more tasks fail.

The exception observed through await is not simply something you should assume represents every failure.

If you want to inspect every task:

foreach (var task in tasks)
{
    if (task.IsFaulted)
    {
        Console.WriteLine(task.Exception);
    }
}

9. Partial Failure with WhenAll

Very important system-design scenario.

Suppose:

var customerTask = GetCustomerAsync();
var orderTask = GetOrdersAsync();
var paymentTask = GetPaymentsAsync();

await Task.WhenAll(
    customerTask,
    orderTask,
    paymentTask);

Suppose:

Customer ✓
Orders   ✓
Payments ✗

The WhenAll task is faulted.

But that doesn't mean the successful operations magically disappear.

You need to decide your application behavior.

For example:

Customer Service ✓
Order Service    ✓
Payment Service  ✗
                  ↓
             Partial failure
                  ↓
          Retry / fallback / error

This becomes especially important in microservices.

10. Retry + Timeout + Cancellation ?/

A senior-level interviewer may ask:

“How would you call an external API safely?”

Request
   ↓
Timeout
   ↓
Retry
   ↓
Cancellation
   ↓
External API

Example using a cancellation token:

public async Task<string> CallApiAsync(
    CancellationToken token)
{
    using var timeout =
        new CancellationTokenSource(
            TimeSpan.FromSeconds(5));

    using var linked =
        CancellationTokenSource.CreateLinkedTokenSource(
            token,
            timeout.Token);

    return await httpClient.GetStringAsync(
        "https://example.com",
        linked.Token);
}

11. IEnumerable vs IQueryable ???

Ans:
Interview statement

“IQueryable allows the query provider, such as EF Core, to translate the expression and execute it at the data source, whereas IEnumerable operates over objects in memory.”

12. Deferred Execution ??

Deferred execution means that a LINQ query is not evaluated at the point where it is defined. Instead, the execution of the expression is delayed until its realized values are actually required or enumerated. When you write a deferred LINQ query, the query variable merely stores the commands or logic of the query—not the actual results.

Deferred Execution (Lazy):
[Data Source] ---> [Define Query (Where)] ---> (No execution occurs yet) ---> [foreach Loop] ---> [Results Evaluated]
                                                                                                 
Immediate Execution (Greedy):
[Data Source] ---> [Define Query + .ToList()] ---> [Query Executes Immediately] 

13. AsNoTracking() ??

var customers = await db.Customers
    .AsNoTracking()
    .ToListAsync();

What does it do?

EF Core doesn't track the returned entities for changes.

Useful for read-only queries.


14. First() vs FirstOrDefault() vs Single() ??

Suppose:

var customer = customers.First();
First()

Returns first item.

If nothing exists:

InvalidOperationException
FirstOrDefault()
var customer = customers.FirstOrDefault();

If nothing exists:

null

for reference types.

Single()
var customer = customers.Single();

Expected exactly one item.

If:

0 items → exception
2 items → exception
Very important interview distinction

Use Single() when the business rule says:

“There must be exactly one.”

Use FirstOrDefault() when:

“I need at most one and zero is acceptable.”


15. What happens when you call an async method?
var task = GetDataAsync();

Console.WriteLine("Hello");

var result = await task;

Understand:

Call async method
       ↓
Starts operation
       ↓
Returns Task
       ↓
Caller continues
       ↓
await
       ↓
Resume when operation completes

16. Async I/O vs CPU-bound work??
I/O-bound

Examples:

Database
HTTP
File I/O

Prefer:

await GetDataAsync();
CPU-bound

Examples:

image processing
large calculations
compression

Potentially:

await Task.Run(() => Calculate());

But use Task.Run deliberately; don't use it as a generic “make async” wrapper.

17. Task.Run inside ASP.NET Core??
Should I use Task.Run in a controller???

Interviewer might ask:

"I have Customer, Order and Payment services. I call all three using Task.WhenAll. Order service fails. What happens?"

Task vs Thread vs Task.Run

Remember this table:

Concept	Meaning
Thread	Actual execution thread
Task	Represents an asynchronous operation
Task.Run()	Schedules work on ThreadPool
async	Enables asynchronous method composition
await	Asynchronously waits for a Task

How can improve the entity framework performance

*/











