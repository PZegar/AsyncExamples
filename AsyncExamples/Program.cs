using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var downloader = new AsyncDownloader();
            var printer = new AsyncPrinter(downloader);

            var printingTask = printer.PrintDataAsync();
            printingTask.ContinueWith(ServePrintTaskFinished);

            Console.ReadKey();
        }

        private static void ServePrintTaskFinished(Task printTask)
        {
            if (printTask.Status == TaskStatus.Faulted)
            {
                Console.WriteLine($"Eror in side task, exception message: {printTask.Exception.Message}");
            }
        }
    }
}
