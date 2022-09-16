using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.GraphsAndTrees
{
    public static class ValidateBinarySearchTree
    {
        // We use Integer instead of int as it supports a null value.
        private static int? prev;

        public static bool isValidBST(TreeNode root)
        {
            prev = null;
            return inorder(root);
        }

        private static bool inorder(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            if (!inorder(root.left))
            {
                return false;
            }
            if (prev != null && root.item <= prev)
            {
                return false;
            }
            prev = root.item;
            return inorder(root.right);
        }

        public static void Test()
        {
            TraversalTree BST = new TraversalTree();
            BST.Insert(30);
            BST.Insert(35);
            BST.Insert(57);
            BST.Insert(15);
            BST.Insert(88);
            BST.Insert(49);
            BST.Insert(89);
            BST.Insert(77);
            BST.Insert(67);
            BST.Insert(98);
            BST.Insert(91);

            var response = isValidBST(BST.root);

            Console.WriteLine(response);
        }


    }
}
