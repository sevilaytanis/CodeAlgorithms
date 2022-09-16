using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.Tree
{
    public static class General2
    {

        public static void main()
        {

            TreeNode root = new TreeNode(6);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(0);
            root.left.right = new TreeNode(4);

            root.right = new TreeNode(2);
            root.right.right = new TreeNode(0);
            root.right.left = new TreeNode(4);
            root.right.left.left = new TreeNode(4);
            root.right.left.left.left = new TreeNode(4);
            root.right.left.left.left.left = new TreeNode(4);

            TreeNode root3 = new TreeNode(6);
            root3.right = new TreeNode(2);
            root3.right.right = new TreeNode(0);
            root3.right.left = new TreeNode(4);


            TreeNode root2 = new TreeNode(3);
            root2.right = new TreeNode(20);
            root2.right.right = new TreeNode(8);
            root2.left = new TreeNode(9);
            root2.left.left = new TreeNode(15);
            root2.left.right = new TreeNode(7);

            //   root2.left.left = new TreeNode(6);

            int[] intList = { -10, -3, 0, 5, 9 };
            List<int> paths = new List<int>();

            TreeNode tree = new TreeNode(5);
            tree.left = new TreeNode(2);
            tree.left.left = new TreeNode(6);
            tree.left.left.right = new TreeNode(6);
            tree.left.left.right.right = new TreeNode(6);
            tree.left.left.right.right.right = new TreeNode(6);
            tree.left.left.right.right.right.right = new TreeNode(6);
            tree.left.left.right.right.right.right.right = new TreeNode(6);
            tree.left.left.right.right.right.right.right.right = new TreeNode(6);


            TreeNode root4 = new TreeNode(1);
            root4.left = new TreeNode(2);
            root4.right = new TreeNode(3);
            root4.left.right = new TreeNode(4);

            TreeNode root5 = new TreeNode(3);
            root5.right = new TreeNode(20);
            root5.left = new TreeNode(9);
            root5.right.right = new TreeNode(7);
            root5.right.left = new TreeNode(15);


            Dictionary<int, int> list = new Dictionary<int, int>();

            var res = PathSum2(root5, 12, new List<List<int>>(), new List<int>());

            // Console.WriteLine(res);
        }

        public static void InorderTraversal(TreeNode root)
        {
            if (root == null)
                return;

            InorderTraversal(root.left);
            Console.WriteLine(root.data);
            InorderTraversal(root.right);


        }

        public static bool SameTree(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return true;

            if (root1 == null || root2 == null)
                return false;

            if (root1.data != root2.data)
                return false;

            return root1.data == root2.data && SameTree(root1.left, root2.left) && SameTree(root1.right, root2.right);
        }

        public static bool SymetricTree(TreeNode root)
        {
            if (root == null)
                return true;

            return sym(root.left, root.right);


        }

        public static bool sym(TreeNode root1, TreeNode root2)

        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null || root2 == null)
                return false;

            return root1.data == root2.data && sym(root1.left, root2.right) && sym(root1.right, root2.left);
        }

        public static int MaximumDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return 1 + Math.Max(MaximumDepth(root.left), MaximumDepth(root.right));
            return 1 + Math.Max(MaximumDepth(root.left), MaximumDepth(root.right));

        }

        public static int MinDepth(TreeNode root)
        {
            int sum = int.MaxValue;

            if (root == null)
                return 0;

            return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
        }

        public static TreeNode SortedArrayToBinary(int[] sortedArray)
        {

            if (sortedArray == null || sortedArray.Length == 0)
                return null;

            return Construct(sortedArray, 0, sortedArray.Length - 1);
        }

        public static TreeNode Construct(int[] sortedArray, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;

            TreeNode root = new TreeNode(sortedArray[mid]);

            root.left = Construct(sortedArray, start, mid - 1);
            root.right = Construct(sortedArray, mid + 1, end);

            return null;

        }

        public static bool BalancedTree(TreeNode root)
        {
            int left = 0;
            int right = 0;
            if (root == null)
                return true;


            left = MaximumDepth(root.left);
            right = MaximumDepth(root.right);

            return Math.Abs(left - right) <= 1 && BalancedTree(root.left) && BalancedTree(root.right);
        }

        public static bool PathSum(TreeNode root, int target)
        {
            if (root == null)
                return false;

            int subsum = target - root.data;

            if (subsum == 0 && root.left == null && root.right == null)
                return true;



            return PathSum(root.left, subsum) || PathSum(root.left, subsum);

        }

        public static void PreORderTraversal(TreeNode root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.data);
            PreORderTraversal(root.left);
            PreORderTraversal(root.right);

        }

        public static void PostOrderTraversal(TreeNode root)
        {
            if (root == null)
                return;

            PreORderTraversal(root.left);
            PreORderTraversal(root.right);

            Console.WriteLine(root.data);

        }

        public static void InvertTree(TreeNode root)
        {
            if (root == null)
                return;

            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertTree(root.left);
            InvertTree(root.right);

        }


        public static TreeNode LowestCommonAncestor(TreeNode root, int v1, int v2)
        {

            if (root == null)
                return root;

            if (root.data > v1 && root.data > v2)
                LowestCommonAncestor(root.left, v1, v2);

            else if (root.data < v1 && root.data < v2)
                LowestCommonAncestor(root.right, v1, v2);

            return root;


        }

        public static void BSTPaths(TreeNode root, List<int> paths)
        {
            if (root == null)
                return;

            if (paths == null)
                paths = new List<int>();

            paths.Add(root.data);

            if (root.left == null && root.right == null)
            {
                foreach (int i in paths)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                BSTPaths(root.left, paths);
                BSTPaths(root.right, paths);
            }



        }

        public static List<int> SumOfLeftLeaves(TreeNode root, List<int> sum)
        {
            if (sum == null)
            {
                sum = new List<int>();
            }
            if (root == null || root.left == null)
                return sum;


            if (root.left.left == null && root.left.right == null)
                sum.Add(root.left.data);

            SumOfLeftLeaves(root.left, sum);
            SumOfLeftLeaves(root.right, sum);

            return sum;

        }

        public static int SumofLeftLeaves2(TreeNode root)
        {
            int res = 0;

            if (root != null)
            {

                if (root.left != null && root.left.left == null && root.left.right == null)
                {
                    res += root.left.data;
                }
                else
                {
                    res = res + SumofLeftLeaves2(root.left);

                }
                res = res + SumofLeftLeaves2(root.right);


            }
            return res;

        }

        public static Dictionary<int, int> FindMode(TreeNode root, Dictionary<int, int> modeList)
        {
            if (modeList == null)
                modeList = new Dictionary<int, int>();

            if (root != null)
            {

                if (modeList.ContainsKey(root.data))
                {
                    modeList[root.data] = modeList[root.data] + 1;
                }
                else
                {
                    modeList.Add(root.data, 0);
                }

                FindMode(root.left, modeList);
                FindMode(root.right, modeList);

            }


            return modeList;
        }

        public static int fibonacci(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            return fibonacci(n - 1) + fibonacci(n - 1);

        }

        public static int MinAbsValue(TreeNode root, int minValue)
        {
            if (root == null)
                return minValue;

            if (root.left != null)
            {
                minValue = Math.Min(Math.Abs(root.left.data - root.data), minValue);
            }
            if (root.right != null)
            {
                minValue = Math.Min(Math.Abs(root.right.data - root.data), minValue);
            }

            if (root.right != null && root.left != null)
            {
                minValue = Math.Min(Math.Abs(root.right.data - root.left.data), minValue);
            }

            MinAbsValue(root.left, minValue);
            MinAbsValue(root.right, minValue);

            return minValue;

        }

        public static int DepthMax(TreeNode root)
        {
            if (root == null)
                return 0;
            return 1 + Math.Max(DepthMax(root.left), DepthMax(root.right));
        }
        public static int DiameterOfTree(TreeNode root)
        {
            int maxValue = int.MinValue;
            int left = 0, right = 0;

            if (root == null)
                return 0;

            maxValue = Math.Max(maxValue, (DepthMax(root.left) + DepthMax(root.right)));

            return Math.Max(maxValue, Math.Max(DiameterOfTree(root.left), DiameterOfTree(root.right)));
        }

        public static bool isSame(TreeNode root1, TreeNode root2)
        {

            if (root1 == null && root2 == null)
                return true;

            if (root1 == null || root2 == null)
                return false;

            if (root1.data != root2.data)
                return false;

            return isSame(root1.left, root2.left) && isSame(root1.right, root2.right);
        }
        public static bool SubTreeOfAnother(TreeNode root1, TreeNode rootSub)
        {
            if (root1 == null)
                return false;

            if (isSame(root1, rootSub))
                return true;

            return SubTreeOfAnother(root1.left, rootSub) || SubTreeOfAnother(root1.right, rootSub);
        }

        public static List<string> ConstructStringFromBinaryTree(TreeNode root, List<string> result)
        {
            if (root == null)
                return result;

            result.Add(root.data.ToString());


            if (root.left != null)
            {
                result.Add("(");
                ConstructStringFromBinaryTree(root.left, result);
                result.Add(")");

            }

            if (root.right != null)
            {
                result.Add("(");
                ConstructStringFromBinaryTree(root.right, result);

                result.Add(")");
            }
            return result;
        }

        public static void mergeTwoBST(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return;

            if (root1 == null)
            {
                root1 = new TreeNode(root2.data);
            }
            else if (root2 != null)
            {
                root1.data = root1.data + root2.data;
            }

            if (root2.left != null)
                mergeTwoBST(root1.left, root2.left);

            if (root2.right != null)
                mergeTwoBST(root1.right, root2.right);
        }

        public static void averageOfLeaves(TreeNode root, Dictionary<int, int> nodes)
        {
            Queue<TreeNode> nodelist = new Queue<TreeNode>();
            int level = 0;

            nodelist.Enqueue(root);
            nodes.Add(root.data, level);

            while (nodelist.Count() > 0)
            {
                var current = nodelist.Dequeue();
                Console.WriteLine(current);

                if (nodes.ContainsKey(current.data))
                {
                    level = nodes[current.data] + 1;
                }

                if (current.left != null)
                {
                    nodelist.Enqueue(current.left);
                    nodes.Add(current.left.data, level);
                }
                if (current.right != null)
                {
                    nodelist.Enqueue(current.right);
                    nodes.Add(current.right.data, level);

                }

            }

        }

        public static bool isExists(TreeNode root, int remainder)
        {

            if (root == null)
                return false;

            if (root.data == remainder)
                return true;

            return isExists(root.left, remainder) || isExists(root.right, remainder);
        }
        public static bool twoSum5(TreeNode root, int target)
        {
            if (root == null)
                return false;

            int remainder = target - root.data;

            if (isExists(root, remainder))
                return true;

            return twoSum5(root.left, target) || twoSum5(root.right, target);
        }

        public static int SecondMinmum(TreeNode root)
        {
            int min = root.data;

            if (root.left.data > min)
                return root.left.data;
            else if (root.right.data > min)
                return root.right.data;
            else
                return -1;


        }

        public static int JewelsandStones()
        {

            return 0;
        }

        public static int MininmumDistance(TreeNode root, int distance)
        {
            int temp = 0;
            if (root == null)
                return distance;

            if (root.left != null)
            {
                temp = root.data - root.left.data;
                distance = Math.Min(temp, distance);

            }
            if (root.right != null)
            {
                temp = root.right.data - root.data;
                distance = Math.Min(temp, distance);
            }

            return Math.Min(MininmumDistance(root.left, distance), MininmumDistance(root.right, distance));
        }

        public static bool ValidateBinarySearchTree(TreeNode root)
        {
            if (root == null)
                return true;

            if (root.left != null)
            {
                if (root.left.data > root.data)
                    return false;

            }
            if (root.right != null)
            {

                if (root.right.data < root.data)
                    return false;
            }

            return ValidateBinarySearchTree(root.left) && ValidateBinarySearchTree(root.right);

        }


        public static void RecoverBinarySearchTree(TreeNode root)
        {
            if (root == null)
                return;

            if (root.right != null)
            {
                if (root.data > root.right.data)
                {
                    TreeNode temp = new TreeNode(root.right.data);

                    root.right.data = root.data;
                    root = temp;

                }
            }
            if (root.left != null)
            {
                if (root.data < root.left.data)
                {
                    TreeNode temp = new TreeNode(root.left.data);

                    root.left.data = root.data;
                    root = temp;

                }
            }

            RecoverBinarySearchTree(root.left);
            RecoverBinarySearchTree(root.right);
        }


        public static void BinaryTreeLevelOrderTraversal(TreeNode root, List<int> list)
        {

            if (root == null)
                return;

            if (list == null)
                list = new List<int>();


            list.Add(root.data);

            BinaryTreeLevelOrderTraversal(root.left, list);

            BinaryTreeLevelOrderTraversal(root.right, list);
        }

        public static void BSTZizZagLevelOrderTraversal(TreeNode root, int side, int level)
        {

            if (root == null)
                return;
            side = side * -1;


            if (side == 1)
            {
                BSTZizZagLevelOrderTraversal(root.left, side, level + 1);
                BSTZizZagLevelOrderTraversal(root.right, side, level + 1);

            }
            else
            {
                BSTZizZagLevelOrderTraversal(root.right, side, level + 1);
                BSTZizZagLevelOrderTraversal(root.left, side, level + 1);

            }

            Console.WriteLine(root.data + "   level:  " + level);
        }

        public static void ConstructBSTPreAndInorder(int[] preorder, int[] inorder)
        {
            TreeNode orderedTree;
            TreeNode head = new TreeNode(preorder[0]);
            orderedTree = head;

            while (preorder.Count() == 0)
            {
                while (inorder.Count() == 0)
                {

                }
            }



        }

        public static void BinaryTreeLevelOrderTraversal2(TreeNode root, int level)
        {
            if (root == null)
                return;

            Console.WriteLine(root.data + "   level:  " + level);

            BinaryTreeLevelOrderTraversal2(root.left, level + 1);

            BinaryTreeLevelOrderTraversal2(root.right, level + 1);

        }

        public static List<List<int>> PathSum2(TreeNode root, int target, List<List<int>> pathList, List<int> current)
        {

            if (root == null)
                return null;

            current.Add(root.data);

            if (root.left == null && root.right == null && root.data == target)
            {
                pathList.Add(current);
                current = new List<int>();
                return pathList;
            }

            PathSum2(root.left, target - root.data, pathList, current);
            PathSum2(root.right, target - root.data, pathList, current);


            return pathList;

        }

        public static 
    }
}
