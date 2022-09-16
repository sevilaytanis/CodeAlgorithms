using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.GraphsAndTrees
{
    public class BinaryTreeLevelOrderTraversal
    {
        public static IList<IList<int>> levels = new List<IList<int>>();

        public static void helper(TreeNode node, int level)
        {

            levels[level].Add(node.item);

            if (node.left != null)
                helper(node.left, level + 1);
            if (node.right != null)
                helper(node.right, level + 1);

        }

        public static IList<IList<int>> levelOrder(TreeNode root)
        {

            if (root == null)
                return levels;
            helper(root, 0);
            return levels;
        }
    }
}
