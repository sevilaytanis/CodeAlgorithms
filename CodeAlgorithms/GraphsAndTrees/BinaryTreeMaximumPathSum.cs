using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.GraphsAndTrees
{
    public class BinaryTreeMaximumPathSum
    {
        int max_sum = int.MinValue;

        public int maxPathSum(TreeNode root)
        {
            postOrder(root);
            return max_sum;
        }

        public int postOrder(TreeNode root)
        {
            if (root == null) return 0;
            int left = Math.Max(postOrder(root.left),0);
            int right = Math.Max (postOrder(root.right),0);
            max_sum = Math.Max(max_sum, left + right + root.item);
            return Math.Max(left,right)+root.item;

        }
       
    }
}
