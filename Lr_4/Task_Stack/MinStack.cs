using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_4.Task_Stack
{
    internal class MinStack
    {
        private Stack<int> stack;
        private Stack<int> minStack;
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }
        public void Push(int val)
        {
            stack.Push(val);
            if (minStack.Count == 0 || val <= minStack.Peek()) { minStack.Push(val); }
        }
        public void Pop()
        {
            if (stack.Peek() == minStack.Peek()) { minStack.Pop(); }
            stack.Pop();
        }
        public int Top() { return stack.Peek(); }
        public int GetMin() { return minStack.Peek(); }
    }
}
