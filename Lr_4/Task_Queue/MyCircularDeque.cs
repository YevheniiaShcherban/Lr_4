using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_4.Task_Queue
{
    internal class MyCircularDeque
    {
        private int[] deque;
        private int front;
        private int rear;
        private int size;
        public MyCircularDeque(int k)
        {
            deque = new int[k];
            front = -1;
            rear = -1;
            size = k;
        }
        public bool InsertFront(int value)
        {
            if (IsFull()) { return false; }
            if (IsEmpty())
            {
                front = 0;
                rear = 0;
            }
            else { front = (front - 1 + size) % size; }
            deque[front] = value;
            return true;
        }
        public bool InsertLast(int value)
        {
            if (IsFull()) { return false; }
            if (IsEmpty())
            {
                front = 0;
                rear = 0;
            }
            else { rear = (rear + 1) % size; }
            deque[rear] = value;
            return true;
        }
        public bool DeleteFront()
        {
            if (IsEmpty()){ return false; }
            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else { front = (front + 1) % size; }
            return true;
        }
        public bool DeleteLast()
        {
            if (IsEmpty()) { return false; }
            if (front == rear)
            {
                front = -1;
                rear = -1;
            }
            else { rear = (rear - 1 + size) % size; }
            return true;
        }
        public int GetFront() { return IsEmpty() ? -1 : deque[front]; }
        public int GetRear() { return IsEmpty() ? -1 : deque[(rear - 1 + size) % size]; }
        public bool IsEmpty() { return front == -1; }
        public bool IsFull() { return (rear + 1) % size == front; }
    }
}
