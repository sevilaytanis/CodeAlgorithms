using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.Tree
{
    public class DFSAndBFS
    {
        public static void DFSSearch(TreeNode root)
        {
            if (root == null)
                Console.WriteLine("empty");

            Stack<TreeNode> nodeStack = new Stack<TreeNode>();

            nodeStack.Push(root);

            while (nodeStack.Count() > 0)
            {
                TreeNode current = nodeStack.Pop();

                Console.WriteLine(current.data);

                if (current.left != null)
                {
                    nodeStack.Push(current.left);
                }
                if (current.right != null)
                {
                    nodeStack.Push(current.right);
                }

            }
        }

        public static void DFSSearchRecursive(TreeNode root)
        {
            if (root == null)
            {

            }
            Console.WriteLine(root);

            DFSSearchRecursive(root.left);
            DFSSearchRecursive(root.right);

        }

        public static void BFS(TreeNode root)
        {
            if (root == null)
            {
                Console.WriteLine("empty");
            }

            Queue<TreeNode> bfsList = new Queue<TreeNode>();

            bfsList.Enqueue(root);

            while (bfsList.Count > 0)
            {
                TreeNode current = bfsList.Dequeue();
                Console.WriteLine(current);

                if (current.left != null)
                {
                    bfsList.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    bfsList.Enqueue(current.right);

                }
            }
        }

        public static bool Exists(TreeNode root, TreeNode existNode)
        {
            if (root == null)
                return false;

            Queue<TreeNode> nodelist = new Queue<TreeNode>();
            nodelist.Enqueue(root);

            while (nodelist.Count > 0)
            {
                TreeNode current = nodelist.Dequeue();
                if (current == existNode)
                    return true;

                if (current.left != null)
                {
                    nodelist.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    nodelist.Enqueue(current.right);
                }

            }

            return false;
        }

        public static bool ExistsRecursive(TreeNode root, TreeNode existsNode)
        {
            if (root == null)
                return false;

            if (root == existsNode)
                return true;

            ExistsRecursive(root.left, existsNode);
            ExistsRecursive(root.right, existsNode);

            return false;

        }

        public static int SumOfTree(TreeNode root)
        {
            if (root == null)
                return 0;
            int sum = 0;

            Queue<TreeNode> nodeList = new Queue<TreeNode>();
            nodeList.Enqueue(root);

            while (nodeList.Count > 0)
            {
                TreeNode curr = nodeList.Dequeue();
                sum = sum + curr.data;

                if (root.left != null)
                    nodeList.Enqueue(root.left);
                if (root.right != null)
                    nodeList.Enqueue(root.right);
            }
            return 0;
        }

        public int sum = 0;
        public static int SumOfTreeRecursive(TreeNode root)
        {
            if (root == null)
                return 0;


            return root.data + SumOfTreeRecursive(root.left) + SumOfTreeRecursive(root.right);
        }


        public static int TreeMinValue(TreeNode root)
        {

            if (root == null)
                return 0;

            int smallest = int.MaxValue;
            Stack<TreeNode> nodelist = new Stack<TreeNode>();
            nodelist.Push(root);

            while (nodelist.Count > 0)
            {
                TreeNode current = nodelist.Pop();

                if (current.data < smallest)
                {
                    smallest = current.data;
                }

                if (root.left != null)
                {
                    nodelist.Push(root.left);
                }
                if (root.right != null)
                {
                    nodelist.Push(root.left);

                }
            }



            return smallest;
        }

        public static int TreeMinValueRecursive(TreeNode root)
        {
            if (root == null)
                return int.MaxValue;

            int lastleft = TreeMinValueRecursive(root.left);
            int lastRight = TreeMinValueRecursive(root.right);

            return Math.Min(Math.Min(lastleft, lastRight), root.data);
        }


        public static int MAxSumPathOfTree(TreeNode root)
        {
            if (root == null)
                return int.MinValue;

            if (root.left == null && root.right == null)
                return root.data;

            int leftSum = MAxSumPathOfTree(root.left);
            int rightSum = MAxSumPathOfTree(root.right);
            int result = Math.Max(leftSum, rightSum);

            return result + root.data;
        }

        public static int MAxSumPathCount(TreeNode root)
        {
            if (root == null)
                return 0;

            if (root.left == null && root.right == null)
                return 0;

            int leftSum = MAxSumPathOfTree(root.left);
            int rightSum = MAxSumPathOfTree(root.right);
            int result = 1;

            return result + 1;
        }
    }

}
