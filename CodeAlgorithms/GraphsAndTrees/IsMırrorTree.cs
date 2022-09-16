using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.GraphsAndTrees
{
    public static class IsMırrorTree
    {

        public static bool isSymmetric(TreeNode root)
        {
            return isMirror(root, root);
        }

        public static bool isMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;
            return (t1.item == t2.item)
                && isMirror(t1.right, t2.left)

                && isMirror(t1.left, t2.right);
        }

        public static void Test()
        {
       
        }
    }
}