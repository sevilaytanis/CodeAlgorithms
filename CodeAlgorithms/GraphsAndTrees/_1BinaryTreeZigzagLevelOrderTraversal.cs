using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.GraphsAndTrees
{


    public class TreeNode
    {
        public int item;
        public TreeNode root;
        public TreeNode left;
        public TreeNode right;
        public TreeNode() { }
        public TreeNode(int x) { item = x; }

    }

    class TraversalTree
    {
        public TreeNode root;
        public TraversalTree()
        {
            root = null;
        }
        public TreeNode ReturnRoot()
        {
            return root;
        }
        public void Insert(int id)
        {
            TreeNode newNode = new TreeNode();
            newNode.item = id;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (id < current.item)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }
            }
        }
        public void Preorder(TreeNode Root)
        {
            if (Root != null)
            {
                Console.Write(Root.item + " ");
                Preorder(Root.left);
                Preorder(Root.right);


            }
        }
        public void Inorder(TreeNode Root)
        {
            if (Root != null)
            {
                Inorder(Root.left);
                Console.Write(Root.item + " ");
                Inorder(Root.right);
            }
        }
        public void Postorder(TreeNode Root)
        {
            if (Root != null)
            {
                Postorder(Root.left);
                Postorder(Root.right);
                Console.Write(Root.item + " ");
            }
        }

        /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */

        public List<List<int>> zigzagLevelOrder(TreeNode root)
        {
            List<List<int>> results = new List<List<int>>();
            if (root == null)
                return results;
            Stack<TreeNode> sp1 = new Stack<TreeNode>(); //left to right
            Stack<TreeNode> sp2 = new Stack<TreeNode>(); //right to left
            sp1.Push(root);

            List<int> list = new List<int>();

            while (sp1.Count > 0 || sp2.Count > 0)
            {
                while (sp1.Count > 0)
                {
                    TreeNode n = sp1.Pop();
                    list.Add(n.item);
                    if (n.left != null)
                    {
                        sp2.Push(n.left);
                    }
                    if (n.right != null)
                    {
                        sp2.Push(n.right);
                    }
                    if (list.Count > 0)
                    {
                        results.Add(new List<int>(list));
                        list.Clear();
                    }
                }

                while (sp2.Count > 0)
                {
                    TreeNode n = sp2.Pop();
                    list.Add(n.item);
                    if (n.right != null)
                    {
                        sp1.Push(n.right);
                    }
                    if (n.left != null)
                    {
                        sp1.Push(n.left);
                    }
                    if (list.Count > 0)
                    {
                        results.Add(new List<int>(list));
                        list.Clear();
                    }
                }

            }



            return results;
        }


        public static void Test()
        {
            TraversalTree BST = new TraversalTree();
            BST.Insert(30);
            BST.Insert(35);
            BST.Insert(57);
            BST.Insert(15);
            BST.Insert(63);
            BST.Insert(49);
            BST.Insert(89);
            BST.Insert(77);
            BST.Insert(67);
            BST.Insert(98);
            BST.Insert(91);

            var result = BST.zigzagLevelOrder(BST.root);
            Console.WriteLine("Zigzag Traversal : ");
            foreach (var res in result)
            {
                foreach (var r in res)
                {
                    Console.Write(r.ToString() + " ");
                }
                Console.WriteLine();
            }
            //Console.WriteLine("Inorder Traversal : ");
            //BST.Inorder(BST.ReturnRoot());
            //Console.WriteLine(" ");
            //Console.WriteLine();
            //Console.WriteLine("Preorder Traversal : ");
            //BST.Preorder(BST.ReturnRoot());
            //Console.WriteLine(" ");
            //Console.WriteLine();
            //Console.WriteLine("Postorder Traversal : ");
            //BST.Postorder(BST.ReturnRoot());
            //Console.WriteLine(" ");
            //Console.ReadLine();
        }
    }
}
