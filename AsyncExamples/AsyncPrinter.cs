using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExamples
{
    internal class AsyncPrinter
    {
        private readonly IAsyncDataSource _dataSource;

        public AsyncPrinter(IAsyncDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task PrintDataAsync()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"[Thread {threadId}] [Task 1] Print Async started");
            //throw new ArgumentNullException();
            var asyncDownloader = _dataSource;

            Console.WriteLine($"[Thread {threadId}] [Task 1] Starting another thread");

            var asyncWork = asyncDownloader.GetLotsOfDataAsync(5);

            Console.WriteLine($"[Thread {threadId}] [Task 1] Doing some additional work in Task 1");

            Thread.Sleep(1500);

            Console.WriteLine($"[Thread {threadId}] [Task 1] Additional work finished after 1.5s in Task 1");

            PrintData(await asyncWork);

            Console.WriteLine($"[Thread {threadId}] [Task 1] Print Async Finished");
        }

        private static void PrintData(IEnumerable<int> data)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"[Thread {threadId}] [Task 1] Downloaded data: ");
            foreach (var element in data)
                Console.Write($"{element} ");

            Console.Write("\n");
        }
    }
}
