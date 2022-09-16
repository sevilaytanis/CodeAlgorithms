using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.Tree
{
    public class TreeNode
    {
        public TreeNode left, right;

        public int data;


        public TreeNode(int data)
        {
            this.data = data;
        }

        public void Insert(int value)
        {
            if (value <= data)
            {
                if (left == null)
                {
                    left = new TreeNode(value);
                }
                else
                {
                    left.Insert(value);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new TreeNode(data);
                }
                else
                {
                    right.Insert(data);
                }
            }

        }

        //inorder traversal
        public bool Contains(int value)
        {
            if (value == data)
            {
                return true;
            }
            else if (value < data)
            {
                if (left == null)
                {
                    return false;
                }
                else
                {
                    return left.Contains(value);
                }
            }
            else
            {
                if (right == null)
                {
                    return false;
                }
                else
                {
                    return right.Contains(value);
                }
            }

        }




        // inorder: root-left-rigth (print order)
        //preorder: root-
        //postorder:
        public void printOrder()
        {
            if (left != null)
            {
                left.printOrder();
            }
            Console.WriteLine(data);

            if (right != null)
            {
                right.printOrder();
            }
        }

    }
}
