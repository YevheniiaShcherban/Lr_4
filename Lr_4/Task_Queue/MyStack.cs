using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_4.Task_Queue
{
    internal class MyStack
    {
        Queue<int> queueIn;
        Queue<int> queueOut;
        public MyStack()
        {
            queueIn = new Queue<int>();
            queueOut = new Queue<int>();
        }
        public void Push(int x) { queueIn.Enqueue(x); }
        public int Pop()
        {
            while (queueIn.Count > 1) { queueOut.Enqueue(queueIn.Dequeue()); }
            int res = queueIn.Dequeue();
            while (queueOut.Count > 0) { queueIn.Enqueue(queueOut.Dequeue()); }
            return res;
        }
        public int Top()
        {
            while (queueIn.Count > 1) { queueOut.Enqueue(queueIn.Dequeue()); }
            int res = queueIn.Dequeue();
            while (queueOut.Count > 0) { queueIn.Enqueue(queueOut.Dequeue()); }
            queueIn.Enqueue(res);
            return res;
        }
        public bool Empty() { return queueIn.Count == 0; }
    }
}
