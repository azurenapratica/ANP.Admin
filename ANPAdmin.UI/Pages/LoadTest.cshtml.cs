using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ANPAdmin.UI.Pages
{
    public class LoadTestModel : PageModel
    {
        static volatile int currentExecutionCount = 0;

        public void OnGet()
        {
            List<Task<long>> taskList = new List<Task<long>>();
            var timer = new Timer(Print, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            for (int i = 0; i < 1000; i++)
            {
                taskList.Add(DoMagic());
            }

            Task.WaitAll(taskList.ToArray());

            timer.Change(Timeout.Infinite, Timeout.Infinite);
            timer = null;

            //to check that we have all the threads executed
        }

        static void Print(object state)
        {
            Console.WriteLine(currentExecutionCount);
        }

        static async Task<long> DoMagic()
        {
            return await Task.Factory.StartNew(() =>
            {
                Interlocked.Increment(ref currentExecutionCount);
                //place your code here
                Thread.Sleep(TimeSpan.FromMilliseconds(1000));
                Interlocked.Decrement(ref currentExecutionCount);
                return 4;
            }
            //this thing should give a hint to scheduller to use new threads and not scheduled
            , TaskCreationOptions.LongRunning
            );
        }
    }
}
