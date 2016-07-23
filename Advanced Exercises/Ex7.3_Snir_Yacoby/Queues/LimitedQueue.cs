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
        private Queue<T> queue = new Queue<T>();
        private SemaphoreSlim semaphore;

        public LimitedQueue(int limit)
        {
            semaphore = new SemaphoreSlim(limit);
        }

        public void Enqueue(T item)
        {
            semaphore.Wait();
            queue.Enqueue(item);
        }

        public T Dequeue()
        {
            T item = default(T);
            if(queue.Count > 0)
            {
                item = queue.Dequeue();
            }

            semaphore.Release();

            return item;
        }
    }
}
