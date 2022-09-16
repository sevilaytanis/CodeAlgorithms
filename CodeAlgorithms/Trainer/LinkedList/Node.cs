using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.LinkedList
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    class LinkedList
    {
        Node head;

        public LinkedList(Node head)
        {
            this.head = head;
        }

        void AddToEnd(int data)
        {
            Node n = new Node(data);

            if (head == null)
            {
                head = n;
            }
            else
            {
                Node curr = head;
                while (curr.next != null)
                {
                    curr = curr.next;
                }

                curr.next = n;
            }
        }

        void AddNodeToStart(int data)
        {
            Node newData = new Node(data);
            newData.next = head;
            head = newData;
        }

        void AddNodeAfter(int insertAfter, int data)
        {
            Node curr = head;
            while (curr != null)
            {
                if (curr.data == insertAfter)
                {
                    Node newData = new Node(data);
                    newData.next = curr.next;
                    curr.next = newData;
                    break;
                }
                curr = curr.next;
            }
        }

        public Node DeleteNodeEnd()
        {
            Node curr = head;

            if (curr == null || curr.next == null)
            {
                head = null;
                return curr;
            }
            while (curr.next != null)
            {
                curr = curr.next;
            }
            curr = null;

            return curr;
        }
        public Node DeleteNodeStart()
        {

            if (head != null)
            {
                Node deleteNode = head;
                head = head.next;
                return deleteNode;
            }
            return null;
        }

        public Node DeleteNodeAfter(int data)
        {
            Node curr = head;
            while (curr != null)
            {
                if (curr.next.data == data)
                {
                    Node toDelete = curr.next;
                    curr.next = toDelete.next;
                    break;

                }
                curr = curr.next;
            }

            return null;
        }
    }
}
