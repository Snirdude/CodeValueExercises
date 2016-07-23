using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            LimitedQueue<int> queue = new LimitedQueue<int>(1);
            Task.Run(() =>
            {
                queue.Enqueue(1);
                Console.WriteLine(1);
            });
            Task.Run(() =>
            {
                queue.Enqueue(2);
                Console.WriteLine(2);
            });
            Task.Run(() =>
            {
                queue.Enqueue(3);
                Console.WriteLine(3);
            });
            Task.Run(() =>
            {
                Thread.Sleep(3000);
                queue.Dequeue();
                Thread.Sleep(3000);
                queue.Dequeue();
            });

            Console.ReadLine();
        }
    }
}
