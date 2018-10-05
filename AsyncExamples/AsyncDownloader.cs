using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExamples
{
    public class AsyncDownloader : IAsyncDataSource
    {
        public async Task<List<int>> GetLotsOfDataAsync(int numberOfObjects)
        {
            return await Task.Run(() => GenerateList(numberOfObjects)); 
            //return await Task.Factory.StartNew<List<int>>(() => GenerateList(numberOfObjects));
            //return GenerateList(numberOfObjects);
        }

        private List<int> GenerateList(int numberOfObjects)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"[Thread {threadId}] [Task 2] Another task started");
            //throw new ArgumentOutOfRangeException()
            var listToBeReturned = new List<int>();

            for(int i=0; i < numberOfObjects; i++)
            {
                listToBeReturned.Add(i);
                Console.WriteLine($"[Thread {threadId}] [Task 2] Adding element: {i}");
                Thread.Sleep(500);
            }

            Console.WriteLine($"[Thread {threadId}] [Task 2] Task finished");

            return listToBeReturned;
        }
    }
}
