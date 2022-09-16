﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.LinkedtList
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _next, Node _random)
        {
            val = _val;
            next = _next;
            random = _random;
        }
    };

    public static class _1CopyLinkRandomPointer
    {
        public static void print(Node start)
        {
            Node ptr = start;
            while (ptr != null)
            {
                if (ptr.random != null)
                    Console.WriteLine(ptr.random.val);
                ptr = ptr.next;

            }
        }

        public static Node CopyRandomList(Node head)
        {

            if (head == null)
            {
                return null;
            }

            // Creating a new weaved list of original and copied nodes.
            Node ptr = head;
            while (ptr != null)
            {

                // Cloned node
                Node newNode = new Node(ptr.val);

                // Inserting the cloned node just next to the original node.
                // If A->B->C is the original linked list,
                // Linked list after weaving cloned nodes would be A->A'->B->B'->C->C'
                newNode.next = ptr.next;
                ptr.next = newNode;
                ptr = newNode.next;
            }

            ptr = head;

            // Now link the random pointers of the new nodes created.
            // Iterate the newly created list and use the original nodes' random pointers,
            // to assign references to random pointers for cloned nodes.
            while (ptr != null)
            {
                ptr.next.random = (ptr.random != null) ? ptr.random.next : null;
                ptr = ptr.next.next;
            }

            // Unweave the linked list to get back the original linked list and the cloned list.
            // i.e. A->A'->B->B'->C->C' would be broken to A->B->C and A'->B'->C'
            Node ptr_old_list = head; // A->B->C
            Node ptr_new_list = head.next; // A'->B'->C'
            Node head_old = head.next;
            while (ptr_old_list != null)
            {
                ptr_old_list.next = ptr_old_list.next.next;
                ptr_new_list.next = (ptr_new_list.next != null) ? ptr_new_list.next.next : null;
                ptr_old_list = ptr_old_list.next;
                ptr_new_list = ptr_new_list.next;
            }
            return head_old;
        }

        public static void Test()
        {
            Node start = new Node { val = 7 };
            start.next = new Node { val = 13 };
            start.next.next = new Node { val = 11 };
            start.next.next.next = new Node { val = 10 };
            start.next.next.next.next = new Node { val = 1 };

            start.next.random = start;
            start.next.next.random = start.next;

            print(start);
            var result = CopyRandomList(start);
             print(result);
        }

    }
}
