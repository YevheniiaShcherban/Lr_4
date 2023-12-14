using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_4.Task_Stack
{
    internal class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        public void PrintTree(TreeNode root)
        {
            if (root == null) { return; }
            PrintTree(root.left);
            Console.Write(root.val + " ");
            PrintTree(root.right);
        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            InorderTraversal(root, res);
            return res;
        }
        public void InorderTraversal(TreeNode root, List<int> res)
        {
            if (root == null) { return; }
            InorderTraversal(root.left, res);
            res.Add(root.val);
            InorderTraversal(root.right, res);
        }
    }
}
