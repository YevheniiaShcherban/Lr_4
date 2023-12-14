using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_4.Task_Queue
{
    internal class RecentCounter
    {
        private Queue<int> queue;
        private int t;
        public RecentCounter()
        {
            queue = new Queue<int>();
            t = 0;
        }
        public int Ping(int t)
        {
            while (queue.Count > 0 && queue.Peek() < t - 3000) { queue.Dequeue(); }
            queue.Enqueue(t);
            return queue.Count;
        }
    }
}
