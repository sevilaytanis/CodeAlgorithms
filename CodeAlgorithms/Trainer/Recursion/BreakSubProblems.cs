using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlgorithms.Trainer.Recursion
{
    //fibonacci
    //towers of Hanoi
    public static class BreakSubProblems
    {
        public static int fibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;
            return fibonacci(n - 1) + fibonacci(n - 2);
        }

    }
}
