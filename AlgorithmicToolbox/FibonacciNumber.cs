using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicToolbox
{
    class FibonacciNumber
    {
        public static int FibonacciNaive(int n)
        {
            if (n <= 1) return n;
            return FibonacciNaive(n - 1) + FibonacciNaive(n - 2);
        }
        public static int FibonacciFast (int n)
        {
            int a = 1;
            int b = 1;
            for (int i = 3; i <= n; i++)
            {
                int c = a + b;// compute next fibonacci number
                a = b;
                b = c;
            }
            return b;
        }
    }
}
