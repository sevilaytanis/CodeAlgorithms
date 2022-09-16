using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Algorithms
{
    public static class MergeSortedList
    {
        public static void TestMergeSortedList()
        {
            List<int> arr1 = new List<int> { 1, 3, 5, 6 };
            List<int> arr2 = new List<int> { 2, 4, 6, 20, 34 };

            LinkedListNode<int> head1 = new LinkedListNode<int>(arr1[0]);
            LinkedListNode<int> head2 = new LinkedListNode<int>(arr2[0]);

            LinkedListNode<int> newHead = MergeList(head1, head2);

            //buraya çalış listenin devamı gelsin
            for (LinkedListNode<int> node = newHead; node != null; node = node.Next)
            {
                Console.WriteLine(node.Value);
            }
            // LinkedList<int>().;

        }

        public static LinkedListNode<int> MergeList(LinkedListNode<int> node1, LinkedListNode<int> node2)
        {
            if (node1 == null)
            {
                return node2;
            }
            else if (node2 == null)
            {
                return node1;
            }

            LinkedListNode<int> mergedHead = null;
            if (node1.Value <= node2.Value)
            {
                mergedHead = node1;
                node1 = node1.Next;
            }
            else
            {
                mergedHead = node2;
                node2 = node2.Next;
            }

            LinkedListNode<int> mergedTail = mergedHead;

            while (node1 != null && node2 != null)
            {
                LinkedListNode<int> temp = null;
                if (node1.Value <= node2.Value)
                {
                    temp = node1;
                    node1 = node1.Next;
                }
                else
                {
                    temp = node2;
                    node2 = node2.Next;
                }

                // mergedTail.Next = temp;
                mergedTail.List.AddLast(temp);
                mergedTail = temp;
            }

            if (node1 != null)
            {
                // mergedTail = node1;
                mergedTail.List.AddLast(node1);

            }
            else if (node2 != null)
            {
                //mergedTail.Next = node2;
                mergedTail.List.AddLast(node2);
            }

            return mergedHead;
        }
    }
}



//using CodeAlgorithms.Algorithms.Objects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CodeAlgorithms.Algorithms
//{
//    public static class LinkedArbitraryPointer
//    {
//        public static void MergeSortedList(LinkedListNode<string> first, LinkedListNode<string> second)
//        {
//            // We would be always adding nodes from the second list to the first one  
//            // If second node head data is more than first one exchange it  
//            if (Convert.ToInt32(first.Next.Value.ToString())
//                    > Convert.ToInt32(second.Value.ToString()))
//            {
//                LinkedListNode<string> t = first;
//                first = second;
//                second = t;
//            }
//            LinkedListNode<string> head = first; //Assign head to first node  
//                                                 //We need to assign head to first because first will continuosly be changing and so we want to store the beginning of list in head.  
//            while ((first.Next != null) && (second != null))
//            {
//                if (Convert.ToInt32(first.Next.Value.ToString())
//                    < Convert.ToInt32(second.Value.ToString()))
//                {
//                    first = first.Next; //Iterate over the first node  
//                }
//                else
//                {
//                    LinkedListNode<string> n = first.Next;
//                    LinkedListNode<string> t = second.Next;
//                    first.Next.ValueRef = second.ValueRef;
//                    second.Next.ValueRef = n.ValueRef;
//                    first = first.Next;
//                    second = t;
//                }

//                Console.WriteLine("current-> " + first.Value);
//            }
//            if (first.Next == null) // Means there are still some elements in second  
//                first.Next.ValueRef = second.ValueRef;
//        }

//        public static void TestLinkedArbitraryPointer()
//        {
//            LinkedList<string> l1 = new LinkedList<string>();
//            l1.AddLast(new LinkedListNode<string>("1"));
//            l1.AddLast(new LinkedListNode<string>("2"));
//            l1.AddLast(new LinkedListNode<string>("3"));
//            l1.AddLast(new LinkedListNode<string>("4"));
//            l1.AddLast(new LinkedListNode<string>("5"));
//            l1.AddLast(new LinkedListNode<string>("8"));
//            l1.AddLast(new LinkedListNode<string>("100"));
//            l1.AddLast(new LinkedListNode<string>("120"));


//            LinkedList<string> l2 = new LinkedList<string>();
//            l2.AddLast(new LinkedListNode<string>("10"));
//            l2.AddLast(new LinkedListNode<string>("30"));
//            l2.AddLast(new LinkedListNode<string>("34"));
//            LinkedList<string> list = new LinkedList<string>();


//            MergeSortedList(l1.First, l2.First);
//            //list.PrintNodes();
//            Console.ReadLine();
//        }
//    }


//}
