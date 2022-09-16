using CodeAlgorithms.Trainer.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.Recursion
{
    public static class Iteration
    {

        //Print linkedlist order
        //factorial
        //when you need to use loop
        public static void printReversedLinkedListRecusrsive(Node head)
        {
            if (head == null) return;
            printReversedLinkedListRecusrsive(head.next);
            Console.WriteLine(head.data);
        }

        public static void printReversedLinkedListIterative(Node head)
        {
            Stack<Node> s = new Stack<Node>();
            while(head!=null)
            {
                s.Push(head);
                head = head.next;
            }
            while(s.Count>0)
            {
                Console.WriteLine(s.Pop());

            }
        }

    }
}
