using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.LinkedList
{
    public class NodeRandom
    {
        public int data;
        public NodeRandom next;
        public NodeRandom random;

        public NodeRandom(int data)
        {
            this.data = data;
            this.next = null;
            this.random = null;
        }
    }
}
