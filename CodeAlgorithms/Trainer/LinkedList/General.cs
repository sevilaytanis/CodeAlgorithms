using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.LinkedList
{
    public static class GeneralLink
    {

        public static void MainMethod()
        {
            List<Node> nodeList = new List<Node>();

            Node head1 = new Node(7);
            Node curr = head1;
            curr.next = new Node(2);
            curr = curr.next;
            curr.next = new Node(4);
            curr = curr.next;
            curr.next = new Node(3);
            curr = curr.next;
            curr.next = new Node(5);
            curr = curr.next;
            curr.next = new Node(6);
            curr = curr.next;
            curr.next = new Node(7);
            curr = curr.next;
            curr.next = new Node(8);
            curr = curr.next;
            curr.next = new Node(9);
            curr = curr.next;
            curr.next = new Node(10);
            curr = curr.next;

            nodeList.Add(head1);


            Node head2 = new Node(5);
            Node curr2 = head2;
            curr2.next = new Node(6);
            curr2 = curr2.next;
            curr2.next = new Node(4);
            curr2 = curr2.next;
            nodeList.Add(head2);


            Node head3 = new Node(2);
            Node curr3 = head3;
            curr3.next = new Node(6);
            curr3 = curr3.next;
            nodeList.Add(head3);




            var res = SplitLinkedListParts(head1, 3);

            Console.WriteLine(res);


        }

        public static Node MergeTwoSortedList(Node head1, Node head2)
        {


            Node data1 = head1;
            Node data2 = head2;

            Node head3 = null;
            Node current = null;

            while (data1.next != null || data2.next != null)
            {

                if (data1.data <= data2.data)
                {
                    if (head3 == null)
                    {
                        head3 = head1;
                        current = head3;
                        data1 = data1.next;
                        continue;
                    }
                    current.next = data2;
                    current = current.next;

                    data1 = data1.next;
                }
                else
                {
                    if (head3 == null)
                    {
                        head3 = head2;
                        current = head3;
                        data2 = data2.next;
                        continue;
                    }
                    current.next = data2;
                    current = current.next;

                    data2 = data2.next;
                }


            }
            return head3;
        }

        public static Node MergekSortedList(List<Node> nodeList)
        {
            Queue<Int32> minHeap = new Queue<int>();

            Node resultHead = null;
            foreach (var currList in nodeList)
            {
                var headCurr = currList;
                while (headCurr != null)
                {
                    minHeap.Enqueue(headCurr.data);
                    headCurr = headCurr.next;
                }
            }

            Node dummy = new Node(-1);
            Node head = dummy;

            while (minHeap != null)
            {
                head.next = new Node(minHeap.Dequeue());
                head = head.next;
            }

            return dummy.next;

        }

        public static Node MergekSortedListDevideAndConquer(List<Node> nodeList)
        {

            if (nodeList.Count() == 0)
            {
                return null;
            }
            int count = 1;
            while (count < nodeList.Count)
            {
                for (int i = 0; i < nodeList.Count; i = i + count * 2)
                {
                    nodeList[i] = MergeTwoSortedList(nodeList[i], nodeList[i + count]);

                }
                count *= 2;
            }

            return nodeList[0];
        }

        public static Node SwapNodesInPair(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Node temp = new Node(-1);
            temp.next = head;
            Node curr = temp;

            while (curr.next != null && curr.next.next != null)
            {
                Node firstNode = curr.next;
                Node secondNode = curr.next.next;
                firstNode.next = secondNode.next;
                curr.next = secondNode;
                curr.next.next = firstNode;
                curr = curr.next.next;
            }


            return temp.next;

        }

        public static Node SwapNodesInPair2(Node head)
        {
            if (head == null)
                return null;


            Node temp = new Node(-1);
            temp.next = head;
            Node current = temp;

            while (current.next != null && current.next.next != null)
            {
                //1,4,5  ==  4,1,5
                Node firstNode = current.next;
                Node secondNode = current.next.next;
                firstNode.next = secondNode.next;
                // firstNode: 1-5
                current.next = secondNode;
                current.next.next = firstNode;
                current = current.next.next;
            }


            return temp.next;

        }

        public static Node RotateList(Node head, int round)
        {
            Node current = head;
            Node prevNode = new Node(-1);

            while (current != null && round > 0)
            {
                if (current.next == null)
                {
                    Node tail = current;
                    tail.next = head;
                    head = tail;
                    prevNode.next = null;
                    current = head;
                    round--;
                }
                prevNode = current;
                if (round != 0)
                    current = current.next;

            }
            return current;

        }

        public static Node RemoveDuplicates(Node head)
        {
            Node current = head;
            Node nextNode = new Node(-1);
            Node prevNode = new Node(-1);

            while (current != null && current.next != null)
            {
                if (current.data == current.next.data)
                {
                    nextNode = current.next.next;
                    if (nextNode == null)
                    {
                        current.next = null;
                        break;
                    }
                    current.next = nextNode;
                }

                else
                {
                    current = current.next;
                }

            }
            return head;

        }

        public static Node RemoveDuplicates2(Node head)
        {
            Node dummy = new Node(-1);
            dummy.next = head;

            Node prevNode = new Node(-1);
            prevNode = dummy;

            while (head != null)
            {
                if (head.next != null && head.data == head.next.data)
                {
                    while (head.next != null && head.data == head.next.data)
                    {
                        head = head.next;
                    }

                    prevNode.next = head.next;
                }
                else
                {
                    prevNode = prevNode.next;
                }
                head = head.next;

            }
            return dummy.next;

        }

        public static Node PartionList(Node head, int limit)
        {
            Node beforeHead = new Node(-1);
            Node beforeList = beforeHead;

            Node afterHead = new Node(-1);
            Node afterList = afterHead;

            if (head == null)
                return null;

            Node current = head;

            while (current != null)
            {
                if (current.data < limit)
                {
                    beforeList.next = current;
                    beforeList = beforeList.next;
                }
                else
                {
                    afterList.next = current;
                    afterList = afterList.next;

                }

                current = current.next;
            }
            afterList.next = null;
            beforeList.next = afterHead.next;

            return beforeHead.next;
        }

        public static Node ReverseList2(Node head, int left, int right)
        {
            int step = 1;
            Node current = head;

            Node middleNodeHead = new Node(-1);
            Node middleNodeList = middleNodeHead;

            Node newNodeHead = new Node(-1);
            Node newNodeList = newNodeHead;

            while (current != null)
            {

                if (step >= left && step <= right)
                {
                    middleNodeHead = new Node(current.data);
                    middleNodeHead.next = middleNodeList;
                    middleNodeList = middleNodeHead;
                }
                else if (step > right)
                {
                    middleNodeList.next = current;
                    middleNodeList = middleNodeList.next;
                }
                else
                {
                    newNodeList.next = current;
                    newNodeList = newNodeList.next;
                }

                step++;

                current = current.next;
            }

            middleNodeList.next = null;
            newNodeList.next = middleNodeList;


            return newNodeList.next;

        }

        public static bool HasCycle(Node head)
        {
            HashSet<Node> list = new HashSet<Node>();
            while (head != null)
            {
                if (list.Contains(head))
                { return true; }

                list.Add(head);

                head = head.next;
            }
            return false;
        }

        public static Node IntersectionOfTwoLinkedList(Node head1, Node head2)
        {
            HashSet<Node> nodelist = new HashSet<Node>();
            while (head1 != null)
            {
                nodelist.Add(head1);
                head1 = head1.next;
            }

            while (head2 != null)
            {
                if (nodelist.Contains(head2))
                {
                    return head2;
                }
                head2 = head2.next;
            }


            return null;
        }

        public static Node IntersectionOfTwoLinkedList1Point(Node head1, Node head2)
        {
            if (head1 == null || head2 == null)
                return null;

            Node ptr1 = head1;
            Node ptr2 = head2;


            while (ptr1 != ptr2)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;

                if (ptr1 == ptr2)
                    return ptr1;

                if (ptr1 == null)
                    ptr1 = head1;

                if (ptr2 == null)
                    ptr2 = head2;

            }
            return null;
        }

        public static Node RemoveLinkedListElement(Node head1, int removedData)
        {

            Node current = head1;

            while (current != null && current.next != null)
            {
                if (current.next.data == removedData)
                {
                    if (current.next.next == null)
                    {
                        current.next = null;
                    }
                    else
                    {
                        current.next = current.next.next;
                    }
                }
                current = current.next;
            }

            return head1;
        }

        public static Node ReverseLinkedList(Node head)
        {
            Node current = head;

            Node reverseList = new Node(-1);

            while (current != null)
            {

                Node newData = new Node(current.data);
                newData.next = reverseList;
                reverseList = newData;
                if (reverseList.next.data == -1)
                {
                    reverseList.next = null;
                }


                current = current.next;
            }

            return reverseList;
        }


        public static Node ReverseHalfLinkedList(Node head)
        {
            Node prev = null;
            Node curr = head;

            while (curr != null)
            {
                Node nex = curr.next;

                curr.next = prev;
                prev = curr;
                curr = nex;

            }

            return prev;
        }

        public static Node FirstHalfLinkedList(Node head)
        {
            Node fast = head;
            Node slow = head;

            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }
        public static bool PalindromeLinkedList(Node head)
        {
            if (head == null)
                return false;

            Node firstList = FirstHalfLinkedList(head);
            Node secondList = ReverseHalfLinkedList(firstList.next);

            Node p1 = head;
            Node p2 = secondList;
            while (p1 != null && p2 != null)
            {
                if (p1.data != p2.data)
                    return false;
                p1 = p1.next;
                p2 = p2.next;
            }
            return true;
        }

        public static Node DeleteNodeInLinkedList(Node head, int deletedNode)
        {
            Node curr = head;

            while (curr.next != null)
            {
                Node prev = curr;
                if (curr.next.data == deletedNode)
                {
                    prev.next = curr.next.next;
                    curr = prev;
                }
                curr = curr.next;

            }
            return head;
        }

        //public static bool checkDiagonal(int[,] mat, int i, int j, int N, int M)
        //{
        //    int res = mat[i, j];

        //    while (++i < N && ++j < M)
        //    {
        //        if (mat[i, j] != res)
        //            return false;

        //    }
        //    return true;
        //}
        //public static bool ToeplizMatrix()
        //{
        //    int[,] array2D = new int[,] { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };

        //    int row = array2D.GetLength(0);
        //    int column = array2D.GetLength(1);
        //    int j = row;

        //    for (int i = column-1; i >= 0; i--)
        //    {
        //        if (!checkDiagonal(array2D, 0, i, row, column))
        //            return false;

        //    }

        //    for (int i = row-1; i >= 0; i--)
        //    {
        //        if (!checkDiagonal(array2D, i, 0, row, column))
        //            return false;

        //    }

        //    return true;
        //}

        public static bool CheckDiagonal(int[,] mat, int currow, int curcolumn)
        {

            int row = mat.GetLength(0);
            int column = mat.GetLength(1);
            int res = mat[currow, curcolumn];

            while (curcolumn++ < column && currow++ < row)
            {
                if (mat[currow, curcolumn] != res)
                    return false;
            }
            return false;
        }
        public static bool ToeplizMatrix()
        {
            int[,] array2D = new int[,] { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            int row = array2D.GetLength(0);
            int column = array2D.GetLength(1);

            for (int i = column - 1; i >= 0; i--)
            {
                if (!CheckDiagonal(array2D, i, 0))
                {
                    return false;
                }
            }


            for (int i = row - 1; i >= 0; i--)
            {
                if (!CheckDiagonal(array2D, 0, i))
                {
                    return false;
                }
            }



            return false;

        }

        public static Node ReorderLinkedList(Node head)
        {
            Node curr = head;
            Node start = new Node(-1);
            Node endHead = new Node(-1);
            Node end = endHead;
            int step = 0;

            while (curr != null)
            {
                Node newData = new Node(curr.data);
                newData.next = start;
                start = newData;

                step = step + 1;
                curr = curr.next;
            }

            while (head != null && step / 2 > 0)
            {
                end.next = head;
                end = end.next;
                head = head.next;

                end.next = start;
                end = end.next;
                start = start.next;

                step--;
            }
            end.next = null;
            return endHead.next;
        }

        public static Node InsertionSortList(Node head)
        {
            Node current = head;

            while (current != null && current.next != null)
            {
                Node prev = current;
                current = current.next;


                if (current.next.data > current.next.next.data)
                {
                    Node deletedNode = current.next;

                    current.next = current.next.next;
                    current = head;

                    while (current.next != null)
                    {
                        if (current.next.data < deletedNode.data)
                        {
                            deletedNode.next = current.next;
                            current.next = deletedNode;
                        }
                        current = current.next;
                    }


                }
                current = current.next;


            }

            return head;

        }

        public static Node OddEvenLinkedList(Node head)
        {
            Node curr = head;

            Node oddhead = new Node(-1);
            Node oddList = oddhead;

            Node evenHead = new Node(-1);
            Node evenList = evenHead;

            while (curr != null)
            {

                oddList.next = curr;
                oddList = oddList.next;



                if (curr.next != null)
                {
                    evenList.next = curr.next;
                    evenList = evenList.next;
                }

                if (curr.next == null || curr.next.next == null)
                    break;
                curr = curr.next.next;

            }
            oddList.next = evenHead.next;

            return oddhead.next;

        }


        public static Node ReverseLinkedList2(Node head)
        {
            Node prev = null;

            while (head != null)
            {
                Node nextNode = head.next;
                head.next = prev;
                prev = head;
                head = nextNode;
            }

            return prev;
        }
        public static Node AddTwoLinkedList(Node head1, Node head2)
        {
            Node headResult = new Node(-1);
            Node result = headResult;

            Node reverseHead1 = ReverseLinkedList2(head1);
            Node reverseHead2 = ReverseLinkedList2(head2);

            int nodeValue = 0;
            int remainder = 0;

            while (reverseHead1 != null || reverseHead2 != null)
            {
                int head1val = 0;
                int head2val = 0;
                if (reverseHead1 == null)
                {
                    head1val = 0;
                }
                else
                {
                    head1val = reverseHead1.data;
                    reverseHead1 = reverseHead1.next;
                }

                if (reverseHead2 == null)
                {
                    head2val = 0;
                }
                else
                {
                    head2val = reverseHead2.data;
                    reverseHead2 = reverseHead2.next;

                }

                int total = head1val + head2val;
                nodeValue = total % 10;

                Node newNode = new Node(nodeValue + remainder);
                result.next = newNode;
                remainder = total / 10;

                result = result.next;

            }




            return headResult.next;
        }

        public static int LengthOfLinkedList(Node head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.next;
            }
            return count;
        }
        public static List<List<int>> SplitLinkedListParts(Node head, int k)
        {
            List<List<int>> nodelist = new List<List<int>>();

            int length = LengthOfLinkedList(head);
            int arrayLength = length / k;
            int remainder = length % k;

            while (k > 0 && head != null)
            {
                int listsize = arrayLength + remainder;
                List<int> currentLsit = new List<int>();

                while (listsize > 0 && head != null)
                {
                    currentLsit.Add(head.data);
                    head = head.next;
                    listsize--;

                }

                nodelist.Add(currentLsit);
                if (remainder > 0)
                    remainder--;
                k--;
            }

            return nodelist;
        }

    }

}
