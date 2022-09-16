using CodeAlgorithms.Algorithms.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Algorithms
{
    class TraversalTree
    {
        public Node root;
        public TraversalTree()
        {
            root = null;
        }
        public Node ReturnRoot()
        {
            return root;
        }
        public void Insert(int id)
        {
            Node newNode = new Node();
            newNode.item = id;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
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
        public void Preorder(Node Root)
        {
            if (Root != null)
            {
                Console.Write(Root.item + " ");
                Preorder(Root.left);
                Preorder(Root.right);
          

            }
        }
        public void Inorder(Node Root)
        {
            if (Root != null)
            {
                Inorder(Root.left);
                Console.Write(Root.item + " ");
                Inorder(Root.right);
            }
        }
        public void Postorder(Node Root)
        {
            if (Root != null)
            {
                Postorder(Root.left);
                Postorder(Root.right);
                Console.Write(Root.item + " ");
            }
        }

        public static void TestTraversalTree()
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
            Console.WriteLine("Inorder Traversal : ");
            BST.Inorder(BST.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Preorder Traversal : ");
            BST.Preorder(BST.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Postorder Traversal : ");
            BST.Postorder(BST.ReturnRoot());
            Console.WriteLine(" ");
            Console.ReadLine();
        }
    }
}
