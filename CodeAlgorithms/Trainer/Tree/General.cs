using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.Tree
{
    public static class General
    {
        public static void main()
        {

            TreeNode root = new TreeNode(6);

            root.left = new TreeNode(2);
            root.left.left = new TreeNode(0);
            root.left.right = new TreeNode(4);
            root.left.right.left = new TreeNode(3);
            root.left.right.right = new TreeNode(5);
            root.right = new TreeNode(8);
            root.right.left = new TreeNode(7);
            root.right.right = new TreeNode(9);


            TreeNode root2 = new TreeNode(1);
            root2.right = new TreeNode(48);
            root2.left = new TreeNode(0);
            root2.right.right = new TreeNode(49);
            root2.right.left = new TreeNode(12);

            //   root2.left.left = new TreeNode(6);

            int[] intList = { -10, -3, 0, 5, 9 };
            List<int> paths = new List<int>();
            subRoot(root, root2);


            // Console.WriteLine(res);
        }
        public static void printInOrder(TreeNode root)
        {
            if (root == null)
                Console.WriteLine("Empty");
            Stack<TreeNode> nodeList = new Stack<TreeNode>();
            nodeList.Push(root);

            while (nodeList.Count > 0)
            {
                TreeNode curr = nodeList.Pop();
                Console.WriteLine(curr.data);

                if (root.left != null)
                    nodeList.Push(root.left);
                if (root.right != null)
                    nodeList.Push(root.right);
            }
        }

        public static void printInOrderRecursive(TreeNode root)
        {
            if (root == null)
                return;

            printInOrderRecursive(root.left);
            Console.WriteLine(root.data);
            printInOrderRecursive(root.right);



        }

        public static bool symetricTree(TreeNode root1)
        {
            if (root1 == null)
                return false;


            return sameTree(root1.left, root1.right);
        }

        public static bool sameTree(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return true;

            if (root1 == null || root2 == null)
                return false;


            return root1.data == root2.data && sameTree(root1.left, root2.left) && sameTree(root1.right, root2.right);

        }

        public static int MAxDepthOfTreeCount(TreeNode root)
        {
            if (root == null)
                return 0;


            int leftSum = MAxDepthOfTreeCount(root.left);
            int rightSum = MAxDepthOfTreeCount(root.right);
            int result = Math.Max(leftSum, rightSum);

            return result + 1;
        }

        public static void preORder(TreeNode root)
        {
            if (root == null)
            {
                Console.WriteLine("");
                return;
            }

            Console.WriteLine(root.data);
            preORder(root.left);
            preORder(root.right);

        }


        public static void postORder(TreeNode root)
        {
            if (root == null)
            {
                Console.WriteLine("");
                return;
            }

            preORder(root.left);
            preORder(root.right);

            Console.WriteLine(root.data);

        }


        public static TreeNode sortedArrayToBST(int[] nodelist, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            TreeNode root = new TreeNode(nodelist[mid]);

            root.left = sortedArrayToBST(nodelist, start, mid - 1);
            root.right = sortedArrayToBST(nodelist, mid + 1, end);


            return root;
        }

        public static void ArrayToTree(int[] nodelist)
        {
            if (nodelist.Count() == 0)
                return;

            int length = nodelist.Length;

            TreeNode root = sortedArrayToBST(nodelist, 0, length - 1);

            preORder(root);

        }

        public static bool IsBalanceTree(TreeNode root)
        {
            if (root == null)
                return true;

            int depthLeft = MAxDepthOfTreeCount(root.left);
            int depthRight = MAxDepthOfTreeCount(root.right);

            int result = depthLeft - depthRight;

            if (Math.Abs(result) <= 1)
                return true;
            return false;
        }

        public static int MinDepthOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + Math.Min(MinDepthOfBinaryTree(root.left), MinDepthOfBinaryTree(root.right));

        }

        public static bool TargetSumPath(TreeNode root, int targetSum)
        {


            if (root == null)
                return false;

            bool ans = false;
            int subsum = targetSum - root.data;

            if (subsum == 0 && root.left == null && root.right == null)
                return true;


            return TargetSumPath(root.left, targetSum - root.data) || TargetSumPath(root.right, targetSum - root.data);


        }

        public static TreeNode InvertBinaryTree(TreeNode root)
        {
            if (root == null)
                return null;

            var temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertBinaryTree(root.left);
            InvertBinaryTree(root.right);

            return root;

        }

        public static int LowestCommonAncestor(TreeNode root, int left, int right)
        {
            Queue<TreeNode> nodelist = new Queue<TreeNode>();
            int smallest = int.MaxValue;
            bool leftFound = false, rigthFound = false;

            if (root == null)
                return 0;

            nodelist.Enqueue(root);
            smallest = root.data;
            while (nodelist.Count() > 0)
            {
                var curr = nodelist.Dequeue();


                if (curr.data < smallest && curr.data != right && curr.data != left)
                    smallest = curr.data;

                if (curr.data == left)
                    leftFound = true;
                if (curr.data == right)
                    rigthFound = true;

                if (leftFound && rigthFound)
                    return smallest;

                if (curr.left != null)
                    nodelist.Enqueue(curr.left);
                if (curr.right != null)
                    nodelist.Enqueue(curr.right);
            }

            return 0;
        }

        public static void PrintPAths(List<int> paths)
        {
            Console.WriteLine("****");

            foreach (int p in paths)
            {
                Console.WriteLine(p);
            }
        }

        public static void BinaryTreePAths(TreeNode root, List<int> paths)
        {

            if (root == null)
                return;

            paths.Add(root.data);

            if (root.left == null && root.right == null)
            {
                PrintPAths(paths);
                paths = new List<int>();

            }



            BinaryTreePAths(root.left, paths);
            BinaryTreePAths(root.right, paths);
        }

        public static bool IsLeaves(TreeNode node)
        {

            if (node == null)
                return false;
            if (node.left == null && node.right == null)
                return true;

            return false;
        }

        public static int BinaryTreeLeftChildSum(TreeNode root)
        {
            int res = 0;

            if (root != null)
            {

                if (IsLeaves(root.left))
                {
                    res = res + root.left.data;

                }
                else
                {
                    res = res + BinaryTreeLeftChildSum(root.left);
                }
                res = res + BinaryTreeLeftChildSum(root.right);
            }
            return res;
        }

        static List<int> modes = new List<int>();

        public static List<int> treeToList(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null)
                return new List<int>();

            result.Add(root.data);

            treeToList(root.left);
            treeToList(root.right);

            return result;


        }
        public static void FindModeinBST(TreeNode root)
        {
            var myList = treeToList(root);

            foreach (int i in myList)
            {

            }

            return;
        }

        public static int CalculateFibonacci(int n)
        {

            if (n == 0 || n == 1)
                return n;

            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }


        public static List<int> GetInorderTree(TreeNode root, List<int> orderList)
        {



            if (root == null)
                return orderList;

            GetInorderTree(root.left, orderList);
            orderList.Add(root.data);

            GetInorderTree(root.right, orderList);


            return orderList;
        }
        public static int MinimumAbsValues(TreeNode node)
        {
            List<int> orderList = new List<int>();
            GetInorderTree(node, orderList);
            int minValue = int.MaxValue;

            for (int i = 0; i < orderList.Count() - 2; i++)
            {
                if (Math.Abs(orderList[i + 1] - orderList[i]) < minValue)
                    minValue = orderList[i + 1] - orderList[i];
            }


            return minValue;

        }

        public static int depthMAx(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = depthMAx(root.left);
            int right = depthMAx(root.right);

            return 1 + Math.Max(left, right);
        }
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            int max = int.MinValue;
            int left = 0, right = 0;

            if (root == null)
                return 0;

            if (root.left != null)
                left = depthMAx(root.left);

            if (root.right != null)
                right = depthMAx(root.right);

            max = Math.Max(max, left + right);

            return Math.Max(left, right) + 1;

        }

        public static List<int> res = new List<int>();

        public static List<int> treeToString(TreeNode root)
        {
            string sum = "";

            if (root == null)
                return new List<int>();


            treeToString(root.left);
            sum = sum + root.data.ToString();
            res.Add(root.data);
            treeToString(root.right);


            return res;

        }
        public static void subRoot(TreeNode root, TreeNode subroot)
        {
            string substring = "", mainstring = "";
            var res3 = treeToString(subroot);
            res = new List<int>();
            var res2 = treeToString(root);

        }

        public static bool isSubtree(TreeNode root, TreeNode subroot)
        {
            if (root == null) return false;

            if (isSame(root, subroot))
            {
                return true;
            }
            return isSubtree(root.left, subroot) || isSubtree(root.right, subroot);
        }

        public static bool isSame(TreeNode root, TreeNode subroot)
        {
            if (root == null && subroot == null) return true;
            if (root == null || subroot == null) return true;

            if (root != subroot)
            {
                return false;
            }
            return isSame(root.left, subroot.left) && isSame(root.right, subroot.right);
        }


        public static TreeNode mergeTwoTree(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)
                return root2;
            if (root2 == null)
                return root1;

            root1= new TreeNode(root1.data + root2.data);
            root1.left = mergeTwoTree(root1.left, root2.left);
            root1.right = mergeTwoTree(root1.right, root2.right);

            return root1;
        }
    }



}
