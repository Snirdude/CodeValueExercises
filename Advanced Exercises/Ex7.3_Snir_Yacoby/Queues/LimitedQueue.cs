using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class LimitedQueue<T>
    {
        private Queue<T> queue;
        private SemaphoreSlim semaphore;

        public LimitedQueue(int limit)
        {
            semaphore = new SemaphoreSlim(limit);
        }

        public void Enqueue(T item)
        {
            semaphore.Wait();
            queue.Enqueue(item);
            semaphore.Release();
        }

        public T Dequeue()
        {
            semaphore.Wait();
            return queue.Dequeue();
            semaphore.Release();
        }
    }
}
