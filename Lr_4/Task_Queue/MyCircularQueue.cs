using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_4.Task_Queue
{
    internal class MyCircularQueue
    {
        private int[] queue;
        private int front;
        private int rear;
        private int capacity;
        public MyCircularQueue(int k)
        {
            queue = new int[k];
            front = -1;
            rear = -1;
            capacity = k;
        }
        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;

            if (IsEmpty())
            {
                front = 0;
                rear = 0;
            }
            else { rear = (rear + 1) % capacity; }
            queue[rear] = value;
            return true;
        }
        public bool DeQueue()
        {
            if (IsEmpty()) { return false; }
            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else { front = (front + 1) % capacity; }
            return true;
        }
        public int Front() { return IsEmpty() ? -1 : queue[front]; }
        public int Rear() { return IsEmpty() ? -1 : queue[rear]; }
        public bool IsEmpty() { return front == -1; }
        public bool IsFull() { return (rear + 1) % capacity == front; }
    }
}
