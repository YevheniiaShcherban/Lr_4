﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_4.Task_Stack
{
    internal class MyQueue
    {
        private Stack<int> stackIn;
        private Stack<int> stackOut;
        public MyQueue()
        {
            stackIn = new Stack<int>();
            stackOut = new Stack<int>();
        }
        public void Push(int x) { stackIn.Push(x); }
        public int Pop()
        {
            if (stackOut.Count == 0) { while (stackIn.Count > 0) { stackOut.Push(stackIn.Pop()); } }
            return stackOut.Pop();
        }
        public int Peek()
        {
            if (stackOut.Count == 0)  { while (stackIn.Count > 0) { stackOut.Push(stackIn.Pop()); } }
            return stackOut.Peek();
        }
        public bool Empty() { return stackIn.Count == 0 && stackOut.Count == 0; }
    }
}
