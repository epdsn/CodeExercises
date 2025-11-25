using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exercises
{
    public class AsyncExamples
    {

        public async Task RunTimerExampleAsync(CancellationToken cancellationToken)
        { 
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            var timerInterval = TimeSpan.FromMilliseconds(500);
            var longOperationDuration = TimeSpan.FromSeconds(5);

            // Prints a tick every interval until cancelled.
            var timerTask = Task.Run(async () =>
            {
                int tick = 0;
                try
                {
                    while (!linkedCts.Token.IsCancellationRequested)
                    {
                        await Task.Delay(timerInterval, linkedCts.Token);
                        Console.WriteLine($"Tick {++tick} at {DateTime.Now:HH:mm:ss.fff}");
                    }
                }
                catch (OperationCanceledException) { }
            }, linkedCts.Token);

            // Simulate a long running operation
            var longTask = Task.Delay(longOperationDuration);


            try
            {
                Console.WriteLine("Starting operation...");
                await longTask;
                Console.WriteLine("Long operation completed.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Long operation was cancelled.");
            }
            finally
            {
                linkedCts.Cancel();
                try { 
                    await timerTask; 
                } 
                catch 
                { 
                    // ignore timertaks handles cancellation
                }
            }


        }

        public async Task RunConcurrentExampleAsync(CancellationToken cancellationToken)
        { 
            var task1 = Task.Run(async () => 
            { 
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken); 
                Console.WriteLine("Task 1 finished"); return "Result 1"; 
            }, cancellationToken);

            var task2 = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
                Console.WriteLine("Task 2 finished");
                return "Result 2";
            }, cancellationToken);


            var task3 = Task.Run(async () => 
            { 
                await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken); 
                Console.WriteLine("Task 3 finished"); 
                return "Result 3"; 
            }, cancellationToken);

            try
            {

                var first = await Task.WhenAny(task1, task2, task3);
                Console.WriteLine($"First completed task result (when available): {(first is Task<string> ts ? ts.Result : "(no result)")}");

                Console.WriteLine("Starting concurrent task...");
                await Task.WhenAll(task1, task2, task3);
                Console.WriteLine("All tasks complete");

                Console.WriteLine($"Result; {task1.Result}, {task2.Result}, {task3.Result}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Concurrent operation was canceled.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"One or more tasks failed: {e.Message}");

                foreach (var t in new[] { task1, task2, task3 })
                {
                    if (t.IsFaulted) Console.WriteLine($"Task faulted: {t.Exception?.Flatten().InnerExceptions.Count} inner exceptions");
                }
            }

        }
        
    }
}