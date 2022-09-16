using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Design
{


    public class LeastRecentlyUsedCache
    {

        class DLinkedNode
        {
            public int key;
            public int value;
            public DLinkedNode prev;
            public DLinkedNode next;
        }

        private void addNode(DLinkedNode node)
        {
            /**
             * Always add the new node right after head.
             */
            node.prev = head;
            node.next = head.next;

            head.next.prev = node;
            head.next = node;
        }

        private void removeNode(DLinkedNode node)
        {
            /**
             * Remove an existing node from the linked list.
             */
            DLinkedNode prev = node.prev;
            DLinkedNode next = node.next;

            prev.next = next;
            next.prev = prev;
        }

        private void moveToHead(DLinkedNode node)
        {
            /**
             * Move certain node in between to the head.
             */
            removeNode(node);
            addNode(node);
        }

        private DLinkedNode popTail()
        {
            /**
             * Pop the current tail.
             */
            DLinkedNode res = tail.prev;
            removeNode(res);
            return res;
        }

        private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
        private int size;
        private int capacity;
        private DLinkedNode head, tail;

        public LeastRecentlyUsedCache(int capacity)
        {
            this.size = 0;
            this.capacity = capacity;

            head = new DLinkedNode();
            // head.prev = null;

            tail = new DLinkedNode();
            // tail.next = null;

            head.next = tail;
            tail.prev = head;
        }

        public int get(int key)
        {
            DLinkedNode node = cache[key];
            if (node == null) return -1;

            // move the accessed node to the head;
            moveToHead(node);

            return node.value;
        }

        public void put(int key, int value)
        {
            //DLinkedNode node = cache[key];

            if ( cache.Count==0 || !cache.ContainsKey(key))
            {
                DLinkedNode newNode = new DLinkedNode();
                newNode.key = key;
                newNode.value = value;

                cache.Add(key, newNode);
                addNode(newNode);

                ++size;

                if (size > capacity)
                {
                    // pop the tail
                    DLinkedNode tail = popTail();
                    cache.Remove(tail.key);
                    --size;
                }
            }
            else
            {
                DLinkedNode node = cache[key];
                // update the value.
                node.value = value;
                moveToHead(node);
            }
        }
        public static void Test()
        {
            LeastRecentlyUsedCache cache = new LeastRecentlyUsedCache(20);
            cache.put(1, 3);
            cache.put(4, 6);
            cache.get(1);
            
        }
    }


}