using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lr_4.Task_Stack;
using Lr_4.Task_Queue;

namespace Lr_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Валідні дужки
            string str = "(){]}";
            Console.Write($"Task 1 \n{str}\n");
            bool result = IsProperBrackets(str);
            Console.WriteLine(result);
            //Обхід бінарного дерева в порядку (Inorder Traversal)
            TreeNode root = new TreeNode(1);
            root.left = null;
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            Console.Write($"Task 2 \n");
            root.PrintTree(root);
            IList<int> res = root.InorderTraversal(root);
            Console.WriteLine($"\n" + string.Join(", ", res));
            //Мінімальний стек
            MinStack minStack = new MinStack();
            Console.Write($"Task 3 \n");
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Console.WriteLine("Min element: " + minStack.GetMin());
            minStack.Pop();
            Console.Write("Top element: " + minStack.Top() + "\n");
            Console.WriteLine("Min element: " + minStack.GetMin());
            //Реалізуйте чергу використовуючи стеки
            Console.Write($"Task 4 \n");
            MyQueue queue = new MyQueue();
            queue.Push(1);
            queue.Push(2);
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Pop());
            Console.WriteLine(queue.Empty());
            //Декодувати рядок
            str = "3[a]2[bc]";
            Console.Write($"Task 5\n{str} \n");
            string Result = DecodeString(str);
            Console.WriteLine(Result);
            //Оцініть зворотну польську нотацію
            string[] Str = { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"};
            Console.Write($"Task 6 \n" + string.Join(", ", Str) + "\n");
            int Res = EvalRPN(Str);
            Console.WriteLine(Res);
            //Найдовші дійсні дужки
            str = ")()())";
            Console.Write($"Task 7 \n{str}\n");
            Res = LongestValidBrackets(str);
            Console.WriteLine(Res);


            //------------------------------------------------------------------------------


            //Перший унікальний символ у рядку
            str = "loveleopard";
            Console.Write($"\n\nTask 1 \n{str}\n");
            Res = FirstUniqChar(str);
            Console.WriteLine(Res);
            //Реалізація стека за допомогою черг
            Console.Write($"Task 2\n");
            MyStack myStack = new MyStack();
            myStack.Push(1);
            myStack.Push(2);
            Console.WriteLine("Top element: " + myStack.Top());
            Console.WriteLine("Pop element: " + myStack.Pop());
            Console.WriteLine("Is empty: " + myStack.Empty());
            //Кількість останніх викликів
            Console.Write($"Task 3\n");
            RecentCounter recentCounter = new RecentCounter();
            int result1 = recentCounter.Ping(1);
            int result2 = recentCounter.Ping(100);
            int result3 = recentCounter.Ping(3001);
            int result4 = recentCounter.Ping(3002);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);
            //Дизайн замкнутої двубічної черги (Deque)
            Console.Write($"Task 3\n");
            MyCircularDeque myCircularDeque = new MyCircularDeque(3);
            Console.WriteLine(myCircularDeque.InsertLast(1));
            Console.WriteLine(myCircularDeque.InsertFront(2));
            Console.WriteLine(myCircularDeque.InsertFront(3));
            Console.WriteLine(myCircularDeque.InsertFront(4));
            Console.WriteLine(myCircularDeque.GetRear());
            Console.WriteLine(myCircularDeque.IsFull());
            Console.WriteLine(myCircularDeque.DeleteLast());
            Console.WriteLine(myCircularDeque.InsertFront(4));
            Console.WriteLine(myCircularDeque.GetFront());
            //Дизайн замкнутої черги
            Console.Write($"Task 4\n");
            MyCircularQueue myCircularQueue = new MyCircularQueue(3);
            Console.WriteLine(myCircularQueue.EnQueue(1));
            Console.WriteLine(myCircularQueue.EnQueue(2));
            Console.WriteLine(myCircularQueue.EnQueue(3));
            Console.WriteLine(myCircularQueue.EnQueue(4));
            Console.WriteLine(myCircularQueue.Rear());
            Console.WriteLine(myCircularQueue.IsFull());
            Console.WriteLine(myCircularQueue.DeQueue());
            Console.WriteLine(myCircularQueue.EnQueue(4));
            Console.WriteLine(myCircularQueue.Rear());
            //Штампування послідовності 
            string stamp = "abc";
            string target = "ababc";
            Console.Write($"Task 5\nStamp = {stamp}\nTarget = {target}");
            List<int> resultT = MovesToStamp(stamp, target);
            Console.Write($"\n" + string.Join(", ", resultT) + "\n");
            //Максимум плаваючого вікна
            Console.Write($"Task 6");  
            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;
            Console.Write($"\n" + string.Join(", ", nums) + "\n" + "K = "+ k );
            int[] maxWindow = MaxSlidingWindow(nums, k);
            Console.Write($"\n" + string.Join(", ", maxWindow) + "\n");
            //Обмежена сума підпослідовності
            Console.Write($"Task 7");
            nums = new int[] { 10, 2, -10, 5, 20 };
            k = 2;
            Console.Write($"\n" + string.Join(", ", nums) + "\n" + "K = " + k + "\n");
            Res = MaxSubArraySum(nums, k);
            Console.WriteLine(Res);
        }
        //Валідні дужки
        static bool IsProperBrackets(string s)
        {
            Dictionary<char, char> pairs = new Dictionary<char, char>() {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'}
        };
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (pairs.ContainsKey(c)) { stack.Push(pairs[c]); }
                else { if (stack.Count == 0 || stack.Pop() != c) { return false; } }
            }
            return stack.Count == 0;
        }
        //Декодувати рядок
        static string DecodeString(string s)
        {
            Stack<int> countStack = new Stack<int>();
            Stack<StringBuilder> stringStack = new Stack<StringBuilder>();
            StringBuilder currentString = new StringBuilder();
            int count = 0;
            foreach (char ch in s)
            {
                if (char.IsDigit(ch)) { count = count * 10 + (ch - '0'); }
                else if (ch == '[')
                {
                    countStack.Push(count);
                    stringStack.Push(currentString);
                    currentString = new StringBuilder();
                    count = 0;
                }
                else if (ch == ']')
                {
                    int repeatCount = countStack.Pop();
                    StringBuilder decodedString = new StringBuilder();
                    for (int i = 0; i < repeatCount; i++)
                    {
                        decodedString.Append(currentString);
                    }
                    currentString = stringStack.Pop().Append(decodedString);
                }
                else { currentString.Append(ch); }
            }
            return currentString.ToString();
        }
        //Оцініть зворотну польську нотацію
        static int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            foreach (string token in tokens)
            {
                if (IsOperator(token))
                {
                    int right = stack.Pop();
                    int left = stack.Pop();
                    stack.Push(EvaluateOperation(token, left, right));
                }
                else { stack.Push(int.Parse(token)); }
            }
            return stack.Pop();
        }
        static bool IsOperator(string token) { return token == "+" || token == "-" || token == "*" || token == "/"; }
        static int EvaluateOperation(string token, int left, int right)
        {
            switch (token)
            {
                case "+": { return left + right; }
                case "-": { return left - right; }
                case "*": { return left * right; }
                case "/": { return left / right; }
                default:{ throw new ArgumentException("Invalid operator: " + token); }
            }
        }
        //Найдовші дійсні дужки
        static int LongestValidBrackets(string s)
        {
            Stack<int> stack = new Stack<int>();
            int maxLength = 0;
            int start = -1;
            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];
                if (currentChar == '(')
                {
                    stack.Push(i);
                    if (start == -1) { start = i; }
                }
                else if (currentChar == ')')
                {
                    if (stack.Count == 0) { start = -1; }
                    else
                    {
                        stack.Pop();
                        if (stack.Count == 0) { maxLength = Math.Max(maxLength, i - start + 1); }
                        else { maxLength = Math.Max(maxLength, i - stack.Peek()); }
                    }
                }
            }
            return maxLength;
        }


        //------------------------------------------------------------------------------


        //Перший унікальний символ у рядку
        static int FirstUniqChar(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (charCount.ContainsKey(c)) { charCount[c]++; }
                else { charCount[c] = 1; }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (charCount[s[i]] == 1) { return i; }
            }
            return -1;
        }
        //Штампування послідовності
        static List<int> MovesToStamp(string stamp, string target)
        {
            int n = stamp.Length, m = target.Length;
            List<int> result = new List<int>();
            bool[] vis = new bool[m];
            int count = 0;
            while (count != m)
            {
                bool flag = true;
                for (int i = 0; i <= m - n; i++)
                {
                    if (!vis[i] && IsEqual(i, stamp, target))
                    {
                        result.Add(i);
                        count += Replace(i, ref target, n);
                        vis[i] = true;
                        flag = false;
                    }
                    if (count == m) { break; }
                }
                if (flag) { return new List<int>(); }
            }
            result.Reverse();
            return result;
        }
        static bool IsEqual(int i, string stamp, string target)
        {
            for (int j = 0; j < stamp.Length; j++)
            {
                if (target[j + i] != '?' && target[j + i] != stamp[j]) { return false; }
            }
            return true;
        }
        static int Replace(int i, ref string target, int n)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (target[i + j] != '?')
                {
                    target = target.Remove(i + j, 1).Insert(i + j, "?");
                    count++;
                }
            }
            return count;
        }
        //Максимум плаваючого вікна
        static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) { return new int[0]; }
            List<int> result = new List<int>();
            LinkedList<int> window = new LinkedList<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (window.Count > 0 && window.First.Value < i - k + 1) { window.RemoveFirst(); }
                while (window.Count > 0 && nums[window.Last.Value] < nums[i]) { window.RemoveLast(); }
                window.AddLast(i);
                if (i >= k - 1) { result.Add(nums[window.First.Value]); }
            }
            return result.ToArray();
        }
        //Обмежена сума підпослідовності
        public static int MaxSubArraySum(int[] nums, int k)
        {
            int n = nums.Length;
            int[] temp = new int[n];
            int maxSum = nums[0];
            for (int i = 0; i < n; i++)
            {
                temp[i] = nums[i];
                for (int j = i - 1; j >= 0 && i - j <= k; j--) { temp[i] = Math.Max(temp[i], temp[j] + nums[i]); }
                maxSum = Math.Max(maxSum, temp[i]);
            }
            return maxSum;
        }
    }
}
